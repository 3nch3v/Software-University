import { getUserToken } from '../lib.js';

export const settings = {
    host: ''
};

async function request(url, options) {
    try {
        const response = await fetch(url, options);

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

    const token = getUserToken();
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(url, getOptions());
}

export async function post(url, data) {
    return await request(url, getOptions('POST', data));
}

export async function put(url, data) {
    return await request(url, getOptions('PUT', data));
}

export async function del(url) {
    return await request(url, getOptions('DELETE'));
}

export async function login(email, password) {
    const user = { 
        email, 
        password 
    };

    const result = await post(settings.host + '/users/login', user);

    const userData = {
        id: result._id,
        token: result.accessToken,
        email: result.email
    };

    sessionStorage.setItem('userData', JSON.stringify(userData));

    return result;
}

export async function register(email, password) {
    const user = { 
        email, 
        password 
    };

    const result = await post(settings.host + '/users/register', user);

    const userData = {
        id: result._id,
        token: result.accessToken,
        email: result.email
    };

    sessionStorage.setItem('userData', JSON.stringify(userData));

    return result;
}

export async function logout() {
    const result = await get(settings.host + '/users/logout');
    sessionStorage.removeItem('userData');
}