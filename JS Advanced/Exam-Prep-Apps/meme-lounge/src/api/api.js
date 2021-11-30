import {  getUserData, setUserData, clearUserData } from '../lib.js';

export const settings = {
    host: ''
};

async function request(url, options) {
    try {
        const response = await fetch(settings.host + url, options);

        if (response.ok != true) {
            if(response.status == 403) {
                sessionStorage.removeItem('userData');
            }

            const error = await response.json();
            throw new Error(error.message);
        }

        if(response.status == 204) {
            return response;
        }

        const data = await response.json();
        return data;

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

function getOptions(method = 'GET', body) {
    const options = {
        method,
        headers: {}
    };

    if (body != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    const userData = getUserData();
    
    if (userData) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function get(url) {
    return request(url, getOptions());
}

export async function post(url, data) {
    return request(url, getOptions('POST', data));
}

export async function put(url, data) {
    return request(url, getOptions('PUT', data));
}

export async function del(url) {
    return request(url, getOptions('DELETE'));
}

export async function login(email, password) {
    const user = { 
        email, 
        password 
    };

    const result = await post('/users/login', user);

    const userData = {
        id: result._id,
        token: result.accessToken,
        email: result.email,
        username: result.username,
        gender: result.gender
    };

    setUserData(userData);
    
    return result;
}

export async function register(username, email, password, gender) {
    const user = {
        username, 
        email, 
        password,
        gender
    };

    const result = await post('/users/register', user);

    const userData = {
        id: result._id,
        token: result.accessToken,
        email: result.email,
        username: result.username,
        gender: result.gender
    };

    setUserData(userData);

    return result;
}

export function logout() {
    get('/users/logout');
    clearUserData();
}