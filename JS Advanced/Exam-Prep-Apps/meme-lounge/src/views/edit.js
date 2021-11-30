import { html, edit, getById, displayError } from '../lib.js';

const editTemp = (meme, onSubmit) => html`
    <section id="edit-meme">
            <form id="edit-form" @submit=${onSubmit}>
                <h1>Edit Meme</h1>
                <div class="container">
                    <label for="title">Title</label>
                    <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
                    <label for="description">Description</label>
                    <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}></textarea>
                    <label for="imageUrl">Image Url</label>
                    <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
                    <input type="submit" class="registerbtn button" value="Edit Meme">
                </div>
            </form>
        </section>
`;

export async function editPage(ctx) {
    const memeId = ctx.params.id;
    const meme = await getById(memeId);

    ctx.render(editTemp(meme, onSubmit));

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
        
        await edit(memeId, meme);
        ctx.page.redirect(`/details/${memeId}`);
    }
}


