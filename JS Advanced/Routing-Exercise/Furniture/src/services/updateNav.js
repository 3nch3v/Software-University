import { getUser } from './userAuthN.js';

export function updateNav() {
    const user = getUser();
    const userBtns = document.querySelector('#user');
    const guestBtns = document.querySelector('#guest');

    if (user) {
        userBtns.style.display = 'inline-block';
        guestBtns.style.display = 'none';
    } else {
        userBtns.style.display = 'none';
        guestBtns.style.display = 'inline-block';
    }
}