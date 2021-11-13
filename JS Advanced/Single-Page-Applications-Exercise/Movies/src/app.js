import { showHome } from './home.js';
import { showRegister } from './register.js';
import { showLogin } from './login.js';
import { logout } from './logout.js';

const nav = document.querySelector('nav');
nav.addEventListener('click', navigate);

showHome();

const router = {
    'logoutBtn': logout,
    'loginBtn': showLogin,
    'registerBtn': showRegister,
    'moviesBtn': showHome
};

function navigate(event) {
    const currTarget = event.target;

    if(currTarget.tagName == 'A' 
      && router[currTarget.id] != undefined) {
        const show = router[currTarget.id];
        show();
    }
}