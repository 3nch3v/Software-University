import { loginView } from './views/login.js'
import { registerView } from './views/register.js'
import { page, render, logout, updateNav } from './lib.js';
import { catalogView } from './views/catalog.js'
import { detailsView } from './views/details.js'
import { createView } from './views/create.js'
import { editView } from './views/edit.js'
import { myFurnitureView } from './views/myFurniture.js'

const root = document.querySelector('main');
document.querySelector('#logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/login', loginView); 
page('/register', registerView);
page('/', catalogView);
page('/dashboard', catalogView);
page('/index.html', catalogView);
page('/create', createView);
page('/edit/:id', editView);
page('/details/:id', detailsView);
page('/my-furniture', myFurnitureView);

page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;
    next();
}

async function onLogout() {
    await logout();
    page.redirect('/dashboard');
}

