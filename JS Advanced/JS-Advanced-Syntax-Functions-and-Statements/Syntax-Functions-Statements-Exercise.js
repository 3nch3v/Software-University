//Exercise: Syntax, Functions and Statements
// 1.) 

function buyFruirs(fruit, weight, price){
    let money = (weight / 1000) * price;
    console.log(`I need $${money.toFixed(2)} to buy ${(weight/ 1000).toFixed(2)} kilograms ${fruit}.`);
}

buyFruirs('orange', 2500, 1.80);

// 2.) 

function greatestCommenDevisor(firstNum, secondNum){
    let smallestNum = firstNum > secondNum ? secondNum : firstNum;
    let greatestDevisor = 1;
    for (let i = 1; i <= smallestNum; i++) {
        if(firstNum % i == 0 && secondNum % i == 0){
            greatestDevisor = i;
        }
    }
    console.log(greatestDevisor);
}

greatestCommenDevisor(2154, 458);

// 3.)

function sameDigits(input) {
    input = String(input); 
    let result = true;
    let sum = 0;
 
    let firstDigit = input[0];
    for (let i = 0; i < input.length; i++) {
        sum += +input[i];
 
        if (input[i] !== firstDigit) {
            result = false;
        }
    }
 
    console.log(result);
    console.log(sum);
}

sameDigits('22222222')

// 4.)

function timeToWalk(steps, footprint , speed){
    let distance = steps * footprint;
    let additionalMinutes = Math.floor(distance / 500);
    let time = distance / (speed * 1000 / 60)

    let hours = Math.floor(time / 60);
    let minutes = Math.floor(time) + additionalMinutes;
    let seconds = time % 1 * 60;

    hours = hours > 9 ? hours : '0' + hours
    minutes = minutes > 9 ? minutes : '0' + minutes
    seconds = seconds > 9 ? seconds : '0' + seconds

    console.log(`${hours}:${minutes}:${seconds.toFixed(0)}`)
}

timeToWalk(2564, 0.70, 5.5)

// 5.)

function roadRader(speed, zone){
    let limitDifference = 0;
    let zoneSpeedLimit = 0;

    switch(zone){
        case 'motorway': limitDifference = speed < 130 ? 0 : (speed - 130); break;
        case 'interstate': limitDifference = speed < 90 ? 0 : (speed - 90);; break;
        case 'city': limitDifference = speed < 50 ? 0 : (speed - 50); break;
        case 'residential': limitDifference = speed < 20 ? 0 : (speed - 20); break;
        default: return 'Invalide zone';
    }

    switch(zone){
        case 'motorway': zoneSpeedLimit = 130; break;
        case 'interstate': zoneSpeedLimit = 90;  break;
        case 'city': zoneSpeedLimit = 50; break;
        case 'residential': zoneSpeedLimit = 20; break;
        default: return 'Invalide zone';
    }

    if(limitDifference <= 0){
        console.log(`Driving ${speed} km/h in a ${zoneSpeedLimit} zone`);
    }
    else{
        let status = '';

        if (limitDifference <= 20){
            status = 'speeding';
        }
        else if(limitDifference > 20 && limitDifference <= 40){
            status = 'excessive speeding';
        }
        else{
            status = 'reckless driving';
        }

        console.log(`The speed is ${limitDifference} km/h faster than the allowed speed of ${zoneSpeedLimit} - ${status}`);
    }

}

roadRader(200, 'motorway');

// 6.)

function cookingByNumbers(number, command1, command2, command3, command4, command5){
    let num = Number(number);
    let commands = [command1, command2, command3, command4, command5];
    commands.forEach(element => {
        switch(element){
            case 'dice': num = Math.sqrt(num); break;
            case 'spice': num += 1; break;
            case 'chop': num /= 2; break;
            case 'bake': num *= 3; break;
            case 'fillet': num *= 0.8; break;
            default: return 'Invalid command!'
        }

        console.log(num);
    });
   
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');


// 7.)

function solve(arr) {
    let x1 = Number(arr[0]);
    let y1 = Number(arr[1]);
    let x2 = Number(arr[2]);
    let y2 = Number(arr[3]);
 
    function distance(x1, y1, x2, y2) {
        let distH = x1 - x2;
        let distY = y1 - y2;
        return Math.sqrt(distH**2 + distY**2);
    }
 
    if (Number.isInteger(distance(x1, y1, 0, 0))) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
 
    if (Number.isInteger(distance(x2, y2, 0, 0))) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }
 
    if (Number.isInteger(distance(x1, y1, x2, y2))) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

solve([2, 1, 1, 1])

// 8.)

function words(input){
    let result = input
    .toUpperCase()
    .split(/[\W]+/)
    .filter(x => x.length > 0);

    console.log(result.join(', '));
}

words('Hi, how are you?');