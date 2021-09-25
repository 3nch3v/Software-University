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

