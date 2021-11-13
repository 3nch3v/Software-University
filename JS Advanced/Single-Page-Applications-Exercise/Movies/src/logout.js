import { getUser } from "./getUser.js";
import { request } from "./makeRequest.js";
import { showLogin } from "./login.js";

export async function logout() {
    const url = 'http://localhost:3030/users/logout';
    
    const welcome = document.querySelector('#welcome');
    const logoutBtn = document.querySelector('#logoutBtn');
    const loginBtn = document.querySelector('#loginBtn');
    const registerBtn = document.querySelector('#registerBtn');

    try {
        const user = getUser();

        if(user == null) {
            throw new Error('You are currently not logged.');
        }

        const isLoggedOut = await request(url, 'GET', null, user.token, true)

        if(!isLoggedOut) {
            throw new Error('Invalid request.');
        }
    
        sessionStorage.clear();

        welcome.style.display  = 'none';
        logoutBtn.style.display  = 'none';
        loginBtn.style.display  = 'block';
        registerBtn.style.display  = 'block';

        showLogin();
     
    } catch(error) {
        alert(error.message);
        console.error(error.message);
    }
}

