function solve(input) {
    let carsData = new Map();

    for (const line of input) {
        let [brand, model, quantity] = line.split(' | ');

        if (!carsData.has(brand)) {
            carsData.set(brand, new Map());
        }

        let brandModels = carsData.get(brand);
        
        if (!brandModels.has(model)) {
            brandModels.set(model, 0);
        }

        brandModels.set(model, brandModels.get(model) + Number(quantity));
    }

    for (const brand of carsData.keys()) {
        console.log(brand);
        
        let brandModels = carsData.get(brand);
        
        for (const model of brandModels.keys()) {
            console.log(`###${model} -> ${brandModels.get(model)}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
       'Audi | Q6 | 100',
       'BMW | X5 | 1000',
       'BMW | X6 | 100',
       'Citroen | C4 | 123',
       'Volga | GAZ-24 | 1000000',
       'Lada | Niva | 1000000',
       'Lada | Jigula | 1000000',
       'Citroen | C4 | 22',
       'Citroen | C5 | 10']
);