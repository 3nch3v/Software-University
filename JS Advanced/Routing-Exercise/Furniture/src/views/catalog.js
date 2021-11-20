import {html, until, getAll } from '../lib.js';
import itemCard from './common/itemCard.js'

const catalogTemp = (itemsPromise) => html`
<div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            ${until(itemsPromise, html`<p>Loading...</p>`)}
        </div>
    </div>
`;

export function catalogView(ctx) {
    ctx.render(catalogTemp(loadItems()));
    ctx.updateNav();
}

async function loadItems() {
    const data = await getAll();
    const items = data.map(itemCard)

    return items;
}