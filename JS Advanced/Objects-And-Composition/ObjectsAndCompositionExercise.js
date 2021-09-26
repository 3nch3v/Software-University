//1.	Calorie Object

function calorieObject(arr){
    const obj = {};
    
    for(i = 0; i < arr.length - 1; i += 2){
        obj[arr[i]] = Number(arr[i + 1]);
    };

    return obj;
};

//console.log(calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));

//2.	Construction Crew

function constructionCrew(worker){
    if(worker.dizziness) {
        worker.levelOfHydrated += 0.1 * worker.weight * worker.experience;
        worker.dizziness = false;
    }

    return worker;
}

//console.log(constructionCrew({ weight: 95,
//                               experience: 3,
//                               levelOfHydrated: 0,
//                               dizziness: false }));

//3.	Car Factory

function carFactory(components) {
    const power = components.power;

    function getEngine(currPower) {
        if(currPower <= 90) {
            return { power: 90, volume: 1800 };
        } else if(currPower > 90 && power <= 120) {
            return { power: 120, volume: 2400 };
        } else {
            return { power: 200, volume: 3500 };
        }
    };

    const color = components.color;
    const type = components.carriage;

    let car = {
        model: components.model,
        engine: getEngine(power),
        carriage: { type: type,
                    color: color},
        wheels: new Array(4).fill(components.wheelsize % 2 === 0 ? components.wheelsize - 1 : components.wheelsize, 0, 4)
    };

    return car;
};

//console.log(
//carFactory({ model: 'Opel Vectra',
//power: 110,
//color: 'grey',
//carriage: 'coupe',
//wheelsize: 17 }
//));

//4.	Heroic Inventory

function heroe(args) {
    let heroes = [];

    args.forEach(el => {
        let currHeroe = {};
        let [name, level, items] = el.split(' / ');
        currHeroe.name = name;
        currHeroe.level = Number(level);
        currHeroe.items = items ? items.split(', ') : [];
        heroes.push(currHeroe);
    });

    return JSON.stringify(heroes);
};

//console.log(heroe(['Isacc / 25 / Apple, GravityGun',
//       'Derek / 12 / BarrelVest, DestructionSword',
//       'Hes / 1 / Desolator, Sentinel, Antara']));

//5.	Lowest Prices in Cities

function lowestPrice(input) {
    const products = {};         // Audi: { 'Sofia City': 100000, 'Mexico City': 100000 },

    for (const line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (!products.hasOwnProperty(product)) {
            products[product] = {};
        }
        products[product][town] = price;
    }

    for (const [product, townsData] of Object.entries(products)) {

        const townWithLowerPrice = Object.entries(townsData)
                                         .reduce(
                                             (acc, v) => acc[1] <= v[1] ? acc : v);
        
        const townName = townWithLowerPrice[0]; 
        const price = townWithLowerPrice[1];    
                        
        console.log(`${product} -> ${price} (${townName})`)
    }
}

function lowestPricesInCities(input) {
    const products = {};                // Audi: Map(2) { 'Sofia City' => 100000, 'Mexico City' => 100000 },

    for (const line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (!products.hasOwnProperty(product)) {
            products[product] = new Map();
        }

        products[product].set(town, price);
    }

    for (const [product, townsData] of Object.entries(products)) {
        const townWithLowerPrice = [...townsData]
                                        .reduce(
                                            (acc, v) => acc[1] <= v[1] ? acc : v); //'Sofia City' => 100000

        const townName = townWithLowerPrice[0]; 
        const price = townWithLowerPrice[1];    

        console.log(`${product} -> ${price} (${townName})`);
    }
}

//lowestPricesInCities([
//    'Sofia City | Audi | 100000',
//    'Sofia City | BMW | 100000', 
//    'Sofia City | Mitsubishi | 10000',
//    'Sofia City | Mercedes | 10000',
//    'Sofia City | NoOffenseToCarLoverss | 0',
//    'Mexico City | Audi | 1000',
//    'Mexico City | BMW | 99999',
//    'New York City | Mitsubishi | 10000',
//    'New York City | Mitsubishi | 1000',
//    'Mexico City | Audi | 100000',
//    'Washington City | Mercedes | 1000']
//);

//6.	Store Catalogue

function storeCatalogue(input) {
    let catalog = {};

    for (const product of input) {
        let [productName, productPrice] = product.split(' : ');
        productPrice = Number(productPrice);
        let index = productName.charAt(0);

        if(!catalog.hasOwnProperty(index)) {
            catalog[index] = {};
        }

        catalog[index][productName] = productPrice;
    }

    let sortedIndeces = Object.keys(catalog)
                              .sort((a, b) => a.localeCompare(b));

    for(const currIndex of sortedIndeces) {
        let currProducts = catalog[currIndex];

        const orderedProducts = Object.keys(currProducts)
                              .sort()
                              .reduce((obj, key) => { 
                                    obj[key] = currProducts[key]; 
                                    return obj;
                                  }, {});
        console.log(currIndex);
        for(const [productName, productPrice] of Object.entries(orderedProducts)) {
            console.log(`  ${productName}: ${productPrice}`);
        }
    }
};

//storeCatalogue(['Banana : 2',
//'Rubic\'s Cube : 5',
//'Raspberry P : 4999',
//'Rolex : 100000',
//'Rollon : 10',
//'Rali Car : 2000000',
//'Pesho : 0.000001',
//'Barrel : 10']
//);

//7.	Towns to JSON

function towns(input) {
    let result = [];

    for(let i = 1; i < input.length; i++) {
        let obj = {}; 

        const townData = input[i].split('|').filter(x => x != '');

        let townName = townData[0].trim();
        let townLatitude = Number(townData[1]).toFixed(2);
        let townLongitude = Number(townData[2]).toFixed(2);

        obj['Town'] = townName;
        obj['Latitude'] = Number(townLatitude);
        obj['Longitude'] = Number(townLongitude);

        result.push(obj)
    }

    console.log(JSON.stringify(result));
}

//towns(['| Town | Latitude | Longitude |',
//       '| Veliko Turnovo | 42.696552 | 23.32601 |',
//       '| Beijing | 39.913818 | 116.363625 |']);

//8.	Rectangle

function rectangle(width, height, color) {
    return {
        width: Number(width),
        height: Number(height),
        color: color.charAt(0).toUpperCase() + color.slice(1),
        calcArea: function() {
            return width * height;
        }
    };
}

//let rect = rectangle(4, 5, 'red');
//console.log(rect.width);
//console.log(rect.height);
//console.log(rect.color);
//console.log(rect.calcArea());

//10. Heroes

function solve() {
    function mage(name) {
        return {
            name,
            health: 100,
            mana : 100,
            cast: function(spell){
                this.mana  -= 1;
                console.log(`${name} cast ${spell}`)
            }
        }
    };

    function fighter(name) {
        return {
            name,
            health: 100,
            stamina: 100,
            fight: function() {
                this.stamina -= 1;
                console.log(`${name} slashes at the foe!`)
            }
        };
    };

    return { mage: mage, fighter: fighter }
};

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);

