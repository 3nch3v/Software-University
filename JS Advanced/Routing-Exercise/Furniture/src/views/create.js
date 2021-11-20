import { html, create, validateItem } from '../lib.js';

const createTemp = (onSubmit, invalidFields) =>  html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Create New Furniture</h1>
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
                                                        : null}" id="new-make" type="text" name="make">
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('model') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-model" type="text" name="model">
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('year') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-year" type="number" name="year">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('description') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-description" type="text" name="description">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('price') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-price" type="number" name="price">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control ${invalidFields.length > 0 
                                                        ? (invalidFields.includes('image') ? 'is-invalid' : 'is-valid') 
                                                        : null}" id="new-image" type="text" name="img">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Create" />
                </div>
            </div>
        </form>
    </div>
`;

export function createView(ctx) {
    renderTpl();
    
    function renderTpl(invalidFields = []) {
        ctx.render(createTemp(onSubmit, invalidFields));
    }

    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);
        const data = validateItem(form);

        if(data.errors.length > 0) {
            return renderTpl(data.errors);
        }

        await create(data.item);
        ctx.page.redirect('/');
    }
}