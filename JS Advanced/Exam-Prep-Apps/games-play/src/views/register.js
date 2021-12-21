import { html, register } from '../lib.js';

const regsiterTemp = (onSubmit) => html`
    <section id="register-page" class="content auth">
        <form id="register" @submit=${onSubmit}>
            <div class="container">
                <div class="brand-logo"></div>
                <h1>Register</h1>

                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="maria@email.com">

                <label for="pass">Password:</label>
                <input type="password" name="password" id="register-password">

                <label for="con-pass">Confirm Password:</label>
                <input type="password" name="confirm-password" id="confirm-password">

                <input class="btn submit" type="submit" value="Register">

                <p class="field">
                    <span>If you already have profile click <a href="/login">here</a></span>
                </p>
            </div>
        </form>
    </section>
`;

export function registerPage(ctx) {
    ctx.render(regsiterTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        
        const form = new FormData(event.target);
        
        const email = form.get('email');
        const password = form.get('password');
        const confirmPassword = form.get('confirm-password');

        if(email == '' || password == '') {
            alert('Please fill in your email and password.');
            return;
        }

        if(password !== confirmPassword) {
            alert('Password doesn\'t.');
            return;
        }

        await register(email, password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}