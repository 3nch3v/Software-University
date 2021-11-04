import { checkAuthentication } from './checkAuthentication.js';
import { request } from './postRequest.js';

window.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.querySelector('#login-view form');
    loginForm.addEventListener('submit', onLogin);
    checkAuthentication();
})

async function onLogin(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/login';

    const form = new FormData(event.target);
    const email = form.get('email');
    const password = form.get('password');

    const userInput = {
        email: email,
        password: password,
    }

    try {
        const data = await request(url, userInput);
        
        const userData = {
            username: data.username,
            email: data.email,
            id: data._id,
            token: data.accessToken
        }

        sessionStorage.setItem('userData', JSON.stringify(userData)); //localStorage or
        window.location.replace("/src/index.html");

    } catch(error) {
        alert(error.message)
    }
}