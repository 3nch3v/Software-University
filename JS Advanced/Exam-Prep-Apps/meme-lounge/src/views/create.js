import { html, create, displayError } from '../lib.js';

const createTemp = (onSubmit) => html`
    <section id="create-meme">
        <form id="create-form" @submit=${onSubmit}>
            <div class="container">
                <h1>Create Meme</h1>
                <label for="title">Title</label>
                <input id="title" type="text" placeholder="Enter Title" name="title">
                <label for="description">Description</label>
                <textarea id="description" placeholder="Enter Description" name="description"></textarea>
                <label for="imageUrl">Meme Image</label>
                <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
                <input type="submit" class="registerbtn button" value="Create Meme">
            </div>
        </form>
    </section>
`;

export function createPage(ctx) {

    ctx.render(createTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);

        const title = form.get('title');
        const description = form.get('description');
        const imageUrl = form.get('imageUrl');

        if(title == '' || description == '' || imageUrl == '') {
            displayError('Please fill in all fields.');
            return;
        }

        const meme = {
            title,
            description,
            imageUrl
        }
        
        await create(meme);
        ctx.page.redirect('/memes');
    }
}