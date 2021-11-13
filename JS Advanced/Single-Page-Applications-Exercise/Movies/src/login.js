import { createHtmlElement, showSection } from './dom.js'
import { showHome } from './home.js';
import { request } from './makeRequest.js';

const loginFormSection = document.querySelector('#form-login');
const loginForm = loginFormSection.querySelector('form');
loginFormSection.remove();

export function showLogin() {
    showSection(loginFormSection);
    loginForm.querySelector('button').addEventListener('click', onLogin);
}

async function onLogin(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/login';

    try {
        const form = new FormData(loginForm);
        const email = form.get('email').trim();
        const password = form.get('password').trim();
        loginForm.reset();
        const userInput = {
            email: email,
            password: password,
        }
    
        const data = await request(url, 'POST', userInput);
        
        const userData = {
            username: data.username,
            email: data.email,
            id: data._id,
            token: data.accessToken
        };

        sessionStorage.setItem('userData', JSON.stringify(userData));
        showHome();

    } catch(err) {
        alert(err.message);
        console.error(err.message);
    }
}