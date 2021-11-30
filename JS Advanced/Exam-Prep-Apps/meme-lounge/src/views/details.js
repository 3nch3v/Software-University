import { html, getUserData, getById, deleteById } from '../lib.js';

const detailsTemp = (meme, isOwner, onDelete) => html`
    <section id="meme-details">
        <h1>Meme Title: ${meme.title}
        </h1>
        <div class="meme-details">
            <div class="meme-img">
                <img alt="meme-alt" src="${meme.imageUrl}">
            </div>
            <div class="meme-description">
                <h2>Meme Description</h2>
                <p>${meme.description}</p>

                ${isOwner ? html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
                                <button @click=${onDelete} class="button danger">Delete</button>
                            `
                        : null }
            </div>
        </div>
    </section>
`;

export async function detailsPage(ctx) {
    const memeId = ctx.params.id;
    const userData = getUserData();

    const meme = await getById(memeId);
    const isOwner = meme._ownerId === userData?.id;

    ctx.render(detailsTemp(meme, isOwner, onDelete));

    async function onDelete() {
        await deleteById(memeId);
        ctx.page.redirect('/memes');
    }
}