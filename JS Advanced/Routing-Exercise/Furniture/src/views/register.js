import { html, register } from '../lib.js';

const registerTemp = (onSubmit) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${onSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>
    </div>
`;

export function registerView(ctx) {
    ctx.render(registerTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const form = document.querySelector('form');
        const data = new FormData(form);
        const email = data.get('email');
        const password = data.get('password');
        const rePass = data.get('rePass');

        if(email == '' || password == '') {
            alert('Please fill out all required fields.');
            return;
        }
        if(password != rePass) {
            alert('Password doesn\'t match.');
            return;
        }

        await register(email, password);
        ctx.page.redirect('/');
    };
}