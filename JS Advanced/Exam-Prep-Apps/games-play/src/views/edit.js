import { html, edit, getById } from '../lib.js';

const editTemp = (game, onSubmit) => html`
    <section id="edit-page" class="auth">
            <form id="edit" @submit=${onSubmit}>
                <div class="container">
                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" .value="${game.title}">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" .value="${game.category}">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" .value="${game.maxLevel}">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" .value="${game.imageUrl}">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary" .value="${game.summary}"></textarea>
                    <input class="btn submit" type="submit" value="Edit Game">
                </div>
            </form>
        </section>
`;

export async function editPage(ctx) {
    const gameId = ctx.params.id;
    const game = await getById(gameId);

    ctx.render(editTemp(game, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);

        const title = form.get('title');
        const category = form.get('category');
        const maxLevel = form.get('maxLevel');
        const imageUrl = form.get('imageUrl');
        const summary = form.get('summary');

        if(title == '' 
          || category == '' 
          || imageUrl == '' 
          || maxLevel == '' 
          || summary == '') {
            alert('Please select a titlefill in all fields.');
            return;
        }

        const game = {
            title,
            category,
            maxLevel,
            imageUrl,
            summary
        }
        
        await edit(gameId, game);
        ctx.page.redirect(`/details/${gameId}`);
    }
}


