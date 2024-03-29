import { html, login, displayError } from '../lib.js';

const loginTemp = (onSubmit) => html`
    <section id="login">
        <form id="login-form" @submit=${onSubmit}>
            <div class="container">
                <h1>Login</h1>
                <label for="email">Email</label>
                <input id="email" placeholder="Enter Email" name="email" type="text">
                <label for="password">Password</label>
                <input id="password" type="password" placeholder="Enter Password" name="password">
                <input type="submit" class="registerbtn button" value="Login">
                <div class="container signin">
                    <p>Dont have an account?<a href="/register">Sign up</a>.</p>
                </div>
            </div>
        </form>
    </section>
`;

export function loginPage(ctx) {
    ctx.render(loginTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);

        const email = form.get('email');
        const password = form.get('password');

        if(email == '' || password == '') {
            displayError('Please fill in your email and password.');
            return;
        }

        await login(email, password);
        ctx.updateNav();
        ctx.page.redirect('/memes');
    }
}