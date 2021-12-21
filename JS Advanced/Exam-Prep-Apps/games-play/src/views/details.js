import { html, getUserData, getById, deleteById, getComments,commentGame } from '../lib.js';

const detailsTemp = (game, comments, isLoggedInUser, isOwner, onDelete, onSubmit) => html`
    <section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">
            <div class="game-header">
                <img class="game-img" src="${game.imageUrl}" />
                <h1>${game.title}</h1>
                <span class="levels">${game.maxLevel}</span>
                <p class="type">${game.category}</p>
            </div>
            <p class="text">${game.summary}</p>


            <div class="details-comments">
                <h2>Comments:</h2>
                <ul>
                    ${comments.length > 0
                        ? comments.map(c => html`<li class="comment">
                                                <p>Content: ${c.comment}</p>
                                            </li>`)
                        : html`<p class="no-comment">No comments.</p>`
                    }  
                </ul>
            </div>


            ${isOwner 
                ? html`<div class="buttons">
                            <a href="/edit/${game._id}" class="button">Edit</a>
                            <a @click=${onDelete} href="#" class="button">Delete</a>
                        </div>`
                : null} 
        </div>

        ${isLoggedInUser && !isOwner
            ? html`
                <article class="create-comment">
                    <label>Add new comment:</label>
                    <form class="form" @submit=${onSubmit}>
                        <textarea name="comment" placeholder="Comment......"></textarea>
                        <input class="btn submit" type="submit" value="Add Comment">
                    </form>
                </article>
                `
            : null 
        }      
    </section>
`;

export async function detailsPage(ctx) {
    const gameId = ctx.params.id;
    
    const userData = getUserData();

    const [game, comments] = await Promise.all([
        getById(gameId), 
        getComments(gameId)
    ]);

    const isOwner = game._ownerId === userData?.id;
    const isLoggedInUser = userData != null;

    ctx.render(detailsTemp(game, comments, isLoggedInUser, isOwner, onDelete, onSubmit));

    async function onDelete() {
        await deleteById(gameId);
        ctx.page.redirect('/');
    }

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);
        const comment = form.get('comment');

        if(comment == '') {
            alert('Please comment.')
            return;
        }

        const commentData = {
            gameId,
            comment
        }

        await commentGame(commentData);

        event.target.reset();
        ctx.page.redirect(`/details/${gameId}`);
    }
}