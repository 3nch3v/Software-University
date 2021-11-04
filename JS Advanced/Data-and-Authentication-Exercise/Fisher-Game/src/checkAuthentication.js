export function checkAuthentication() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    const user = document.querySelector('#user');
    const guest = document.querySelector('#guest');
    const welcome = document.querySelector('.email span');
    const addBtn = document.querySelector('.add');

    if(userData == null) {
        user.style.display = 'none';
        guest.style.display = 'inline-block';
        welcome.textContent = 'guest';
        addBtn.disabled = true;
    } else {
        user.style.display = 'inline-block';
        guest.style.display = 'none';
        welcome.textContent = `${userData.email}`;
        addBtn.disabled = false;
    }
}