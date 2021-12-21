import { html, create } from '../lib.js';

const createTemp = (onSubmit) => html`
    <section id="create-page" class="auth">
            <form id="create" @submit=${onSubmit}>
                <div class="container">

                    <h1>Create Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" placeholder="Enter game title...">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" placeholder="Enter game category...">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary"></textarea>
                    <input class="btn submit" type="submit" value="Create Game">
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
        
        await create(game);
        ctx.page.redirect('/');
    }
}