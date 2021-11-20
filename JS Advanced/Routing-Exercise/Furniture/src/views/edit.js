import { html, editById, getById, validateItem } from '../lib.js';

const editTpl = (onSubmit, item, invalidFields) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${onSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('make') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-make" type="text" name="make" .value=${item.make}>
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('model') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-model" type="text" name="model" .value=${item.model}>
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('year') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-year" type="number" name="year" .value=${item.year}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('description') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-description" type="text" name="description" .value=${item.description}>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('price') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-price" type="number" name="price" .value=${item.price}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('image') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-image" type="text" name="img" .value=${item.img}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material" .value=${item.material}>
                    </div>
                    <input type="submit" class="btn btn-info" value="Edit" />
                </div>
            </div>
        </form>
    </div>
`;

export async function editView(ctx) {
    const id = ctx.params.id;
    const item = await getById(id);

    renderTpl(item);

    function renderTpl(item, invalidFields = []) {
        ctx.render(editTpl(onSubmit, item, invalidFields));
    };
    
    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);
        const data = validateItem(form);
        
        if(data.errors.length > 0) {
            return renderTpl(data.item, data.errors);
        }
        
        await editById(id, data.item);
        ctx.page.redirect(`/details/${id}`);
    };
}