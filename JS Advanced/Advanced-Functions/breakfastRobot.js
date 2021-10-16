function solution() {
    let recipes = {
        apple : {carbohydrate : 1, flavour : 2},
        lemonade  : {carbohydrate : 10, flavour : 20},
        burger  : {carbohydrate : 5, fat: 7, flavour : 3},
        eggs : {protein: 5, fat : 1, flavour : 1},
        turkey : {protein: 10, carbohydrate : 10, fat: 10, flavour : 10} 
    }

    let availability = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    }

    function controller(input) {
        let [command, item, qty] = input.split(' ');
        let quantity = Number(qty)

        if(command === 'restock') {
            availability[item] += quantity;
            return 'Success';
        } else if(command === 'prepare') {
            let ingredients =  recipes[item];
            let usedIngredients = {};
            
            for (const [ingredient, neededQty] of Object.entries(ingredients)) {              
                if(availability[ingredient] < neededQty * quantity){
                    return `Error: not enough ${ingredient} in stock`;
                }
                
                usedIngredients[ingredient] = neededQty * quantity;
            }

            for (const [ingredient, usedQty] of Object.entries(usedIngredients)) {              
                availability[ingredient] -= usedQty;
            }

            return 'Success';
        } else {
            return `protein=${availability.protein} carbohydrate=${availability.carbohydrate} fat=${availability.fat} flavour=${availability.flavour}`;
        }
    };

    return controller;
}

let manager = solution (); 
// console.log(manager('restock flavour 50 '))
// console.log(manager('prepare lemonade 4 '))
// console.log(manager('restock carbohydrate 10'))
// console.log(manager('restock flavour 10'))
// console.log(manager('prepare apple 1'))
// console.log(manager('restock fat 10'))
// console.log(manager('prepare burger 1'))
// console.log(manager('report'))

console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));
