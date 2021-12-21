import { page, render, logout, getUserData } from "./lib.js";

import { homePage } from "./views/home.js";
import { catalogPage } from "./views/catalog.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { detailsPage } from "./views/details.js";
import { createPage } from "./views/create.js";
import { editPage } from "./views/edit.js";


const root = document.querySelector("main");
document.querySelector("#logoutBtn").addEventListener("click", onLogout);


page(decorateContext);
page('/', homePage);
page('/catalog', catalogPage);
page('/login', loginPage);
page('/register', registerPage);
page('/details/:id', detailsPage);
page('/create', createPage);
page('/edit/:id', editPage);


updateNav();
page.start();

function decorateContext(ctx, next) {
  ctx.render = (content) => render(content, root);
  ctx.updateNav = updateNav;
  next();
}

function onLogout() {
    debugger;
  logout();
  updateNav();
  page.redirect("/");
}

function updateNav() {
    const userData = getUserData();

    const userBtns = document.querySelector('#user')
    const geustBtns = document.querySelector('#guest')

    if(userData) {
        userBtns.style.display = 'block';
        geustBtns.style.display = 'none';
    } else {
        userBtns.style.display = 'none';
        geustBtns.style.display = 'block';
    }
}

