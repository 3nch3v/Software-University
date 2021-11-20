export function validateItem(data) {
        const make = data.get('make');
        const model = data.get('model');
        const year = data.get('year');
        const description = data.get('description');
        const price = data.get('price');
        const img = data.get('img');
        const material = data.get('material');

        let errors = [];

        if(make.length < 4) {
            errors.push('make');
        }
        if(model.length < 4) {
            errors.push('model');
        }

        if (year == '' 
           || Number(year) < 1950 
           || Number(year) > 2050) {
            errors.push('year');
        }

        if (description.length <= 10) {
            errors.push('description');
        }

        if (price == '' ||  Number(price) < 0) {
            errors.push('price');
        } 

        if (img == '') {
            errors.push('image');
        }

        return {
            errors,
            item: {
                make, 
                model,
                year, 
                description,
                price,
                img,
                material
            }
        }
}