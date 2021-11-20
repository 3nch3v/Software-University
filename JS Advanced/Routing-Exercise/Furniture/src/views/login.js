import { html, login } from '../lib.js';

const loginTemp = (onSubmit) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Login User</h1>
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
                    <input type="submit" class="btn btn-primary" value="Login" />
                </div>
            </div>
        </form>
    </div>
`;

export function loginView(ctx) {
    ctx.render(loginTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
    
        const form = document.querySelector('form');
        const data = new FormData(form);
        const email = data.get('email');
        const password = data.get('password');

        if(email == '' || password == '') {
            alert('Please enter a valid email and password');
            return;
        }

        await login(email, password);
        ctx.page.redirect('/');
    };
}





