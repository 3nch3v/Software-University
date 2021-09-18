//1.	Fruit

function calculatePrice(fruit, weight, price){
    let weightInKg = weight / 1000;
    let money = price * weightInKg;
    console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

//calculatePrice('apple', 1563, 2.35);

//2.	Greatest Common Divisor - GCD

function gcd(firstNumber, secondNumber){
    while(secondNumber != 0){
        const temp = secondNumber;
        secondNumber = firstNumber % secondNumber;
        firstNumber = temp;
    }

    console.log(firstNumber);
}

//gcd(15, 5);

//3.	Same Numbers

function sameNums(number){
    let numberAsStr = number.toString();
    let isSame = true;
    let sum = 0;

    for(let i = 0; i < numberAsStr.length; i++){
        if(numberAsStr[i] != numberAsStr[i + 1] 
            && i != numberAsStr.length - 1){
            isSame = false;
        }
        
        sum += Number(numberAsStr[i]);
    }

    console.log(isTrue);
    console.log(sum);
}

//sameNums(1234);

//4.	Previous Day

function getPreviousDay(year, month, day){
    let dateAsStr = `${year}-${month}-${day}`;
    let date = new Date(dateAsStr);
    date.setDate(day - 1);

    console.log(`${date.getFullYear()}-${Number(date.getMonth() + 1)}-${date.getDate()}`);
}

//getPreviousDay(2016, 9, 30);
//getPreviousDay(2016, 10, 1);

//5.	Time to Walk

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

//6.	Road Radar

function roadRader(speed, zone){
    let zoneSpeedLimit = 0;

    switch(zone){
        case 'motorway': zoneSpeedLimit = 130; break;
        case 'interstate': zoneSpeedLimit = 90;  break;
        case 'city': zoneSpeedLimit = 50; break;
        case 'residential': zoneSpeedLimit = 20; break;
        default: return 'Invalide zone';
    }

    let limitDifference = speed - zoneSpeedLimit;

    if(limitDifference <= 0){
        console.log(`Driving ${speed} km/h in a ${zoneSpeedLimit} zone`);
    }else{
        let status = '';

        if (limitDifference <= 20){
            status = 'speeding';
        }else if(limitDifference > 20 && limitDifference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }

        console.log(`The speed is ${limitDifference} km/h faster than the allowed speed of ${zoneSpeedLimit} - ${status}`);
    }
}

//roadRader(40, 'city')
//roadRader(21, 'residential')
//roadRader(120, 'interstate')
//roadRader(200, 'motorway')

//7.	Cooking by Numbers

function cooking(number, firstCommand, secondCommand, thirdCommand, fourthCommand, fifthCommand){
    let result = Number(number);
    const commands = [firstCommand, secondCommand, thirdCommand, fourthCommand, fifthCommand];

    commands.forEach(cmd => {
        switch(cmd){
            case 'dice': result = Math.sqrt(result); break;
            case 'spice': result += 1; break;
            case 'chop': result /= 2; break;
            case 'bake': result *= 3; break;
            case 'fillet': result *= 0.8; break;
            default: return 'Invalid command!';
        }

        console.log(result);
    });
}

//cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop')
//cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet')


//8.	Validity Checker

function solve(firstArr, secondArr, thirdArr, fourtgArr) {
    let x1 = Number(firstArr);
    let y1 = Number(secondArr);
    let x2 = Number(thirdArr);
    let y2 = Number(fourtgArr);
 
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

//solve(2, 1, 1, 1)
//solve(3, 0, 0, 4)

//9.	*Words Uppercase

function words(input){
    let result = input
    .toUpperCase()
    .split(/[\W]+/)
    .filter(x => x.length > 0);

    console.log(result.join(', '));
}

//words('Hi, how are you?');