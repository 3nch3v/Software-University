import { showSection } from './dom.js';
import { request } from './makeRequest.js';
import { showHome } from './home.js';

const minPasswordLength = 6;
const signUpSection = document.querySelector('#form-sign-up');
const signUpForm = signUpSection.querySelector('form');
signUpSection.remove();

export function showRegister() {
    showSection(signUpSection);
    signUpForm.addEventListener('submit', registerUser);
}

async function registerUser(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/users/register';

    const form = new FormData(signUpForm);
    const email = form.get('email').trim();
    const password = form.get('password').trim();
    const repeatPassword = form.get('repeatPassword').trim();
    
    if(email === '' || password === '') {
        alert('Please fill out all required fields.');
        return;
    }

    if(password.length < minPasswordLength) {
        alert('Password length should be minimun 6 characters.');
        return;
    }

    if(password !== repeatPassword) {
        alert('Password doesn\'t match.');
        return;
    }

    signUpForm.reset();
    
    try {
        const userInput = {
            email: email,
            password: password,
        };
    
        const data = await request(url, 'POST', userInput);

        const userData = {
            email: data.email,
            id: data._id,
            token: data.accessToken,
        }

        sessionStorage.setItem('userData', JSON.stringify(userData));
        showHome();

    } catch(error) {
        alert(error.message)
        console.error(error.message);
    }
}