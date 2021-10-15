function solve(input) {
    let juices = new Object();
    let bottles = new Object();

    input.forEach(jf => {
        const [juiceName, juiceQuantity] = jf.split(' => ');
        let juiceQuantityAsNumber = Number(juiceQuantity);
        
        if(!juices.hasOwnProperty(juiceName)) {
            juices[juiceName] = 0;
        }
        
        juices[juiceName] += juiceQuantityAsNumber;

        if(juices[juiceName] >= 1000) {
            let currBottles = Math.floor(juices[juiceName] / 1000);

            if(!bottles.hasOwnProperty(juiceName)){
                bottles[juiceName] = 0;
            }
            
            bottles[juiceName] += currBottles;

            juices[juiceName] = juices[juiceName] % 1000;
        }
    })

    for(const key in bottles) {
        console.log(`${key} => ${bottles[key]}`);
    }
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']);