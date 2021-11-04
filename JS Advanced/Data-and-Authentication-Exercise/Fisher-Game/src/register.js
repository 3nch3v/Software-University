import { checkAuthentication } from './checkAuthentication.js';
import { request } from './postRequest.js';

window.addEventListener('DOMContentLoaded', () => {
    const registerForm = document.querySelector('#register-view form');
    registerForm.addEventListener('submit', onRegister);
    checkAuthentication();
})

async function onRegister(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/register';

    const form = new FormData(event.target);
    const email = form.get('email').trim();
    const password = form.get('password').trim();
    const repeatPassword = form.get('rePass').trim();

    try {    
        if(email === '' 
          || password === '' 
          || repeatPassword === '') {
            throw new Error('Please fill out all fields.');
        }
        if(password !== repeatPassword) {
            throw new Error('Password confirmation doesn\'t match');
        }

        const userInput = {
            email: email,
            password: password,
        }

        const data = await request(url, userInput);

        const userData = {
            email: data.email,
            id: data._id,
            token: data.accessToken
        }

        sessionStorage.setItem('userData', JSON.stringify(userData));
        window.location.replace("/src/index.html");

    } catch(error) {
        alert(error.message)
    }
}
