import { html, getUserId, deleteById } from '../lib.js';
import { getById } from '../services/data.js';

const detailsTemp = (item, isOwner, onDelete) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${item.img} />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${item.make}</span></p>
                <p>Model: <span>${item.model}</span></p>
                <p>Year: <span>${item.year}</span></p>
                <p>Description: <span>${item.description}</span></p>
                <p>Price: <span>${item.price} $</span></p>
                <p>Material: <span>${item.material}</span></p>
                ${isOwner ? html`
                <div>
                    <a href="/edit/${item._id}" class="btn btn-info">Edit</a>
                    <a @click=${onDelete} class="btn btn-red">Delete</a>
                </div>` : null}
            </div>
        </div>
    </div>
`;

export async function detailsView(ctx) {
    const id = ctx.params.id;
    const userId = getUserId();
    const item = await getById(id);

    const isOwner = userId === item._ownerId;

    ctx.render(detailsTemp(item, isOwner, onDelete));

    async function onDelete(event) {
        event.preventDefault();

        var res = confirm("The item will be deleted. Please confirm.");
        
        if (res == true) {
            await deleteById(id);
            ctx.page.redirect('/');
        }
    }
}