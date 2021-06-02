// Lab: Syntax, Functions and Statements
//1.)

function echo(input){
    let inputLength = input.length;
    console.log(inputLength);
    console.log(input);
}

echo('Hello, JavaScript!');

//2.)

function stringLength(firstString, secondString, thirdString){
    let lengthSum = firstString.length + secondString.length + thirdString.length;
    let avgLength = Math.floor(lengthSum / 3);

    console.log(lengthSum);
    console.log(avgLength);
}

stringLength('chocolate', 'ice cream', 'cake');

//3.)

function biggestNum(firstNum, secondNum, thirdNum){
    let biggestNum;
    if(firstNum > secondNum && firstNum > thirdNum)
    {
        biggestNum = firstNum;
    }
    else if(secondNum > firstNum && secondNum > thirdNum)
    {
        biggestNum = secondNum;
    }
    else
    {
        biggestNum = thirdNum;
    }

    console.log(`The largest number is ${biggestNum}.`);
}

biggestNum(2 ,22, 1);

//4.)

function circleArea(input){
    let typeOfInput = typeof(input);
    if(typeOfInput == 'number')
    {
        let area = Math.PI * Math.pow(input, 2);
        console.log(area.toFixed(2));
    }
    else
    {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfInput}.`);
    }
}

circleArea('no');
circleArea(5);

//5.)

function mathOperations(firstNum, secondNum, operator){
    let result;
    switch(operator)
    {
        case '+': result = firstNum + secondNum; break;
        case '-': result = firstNum - secondNum; break;
        case '*': result = firstNum * secondNum; break;
        case '/': result = firstNum / secondNum; break;
        case '%': result = firstNum % secondNum; break;
        case '**': result = firstNum ** secondNum; break;
        default: result = 'Invalid operator';
    }

    console.log(result);
}

mathOperations(2, 10, '+')

//6.)

function sumOfNumbers(fristNum, secondNum){
    let fristNumber = Number(fristNum);
    let secondNumber = Number(secondNum);
    let sum = 0;
    for(let i = fristNumber; i <= secondNumber; i++)
    {
        sum += i;
    }

    console.log(sum);
}

sumOfNumbers('-8', '20');


//7.)

function daysOfWeek(input){
    let result;

    switch(input) {
        case 'Monday': result = 1; break;
        case 'Tuesday': result = 2; break;
        case 'Wednesday': result = 3; break;
        case 'Thursday': result = 4; break;
        case 'Friday': result = 5; break;
        case 'Saturday': result = 6; break;
        case 'Sunday': result = 7; break;
        default: result = 'error';
    }

    console.log(result);
}

daysOfWeek('Monday')


//8.)

function squareOfStars(size){
    let row = '* '.repeat(size);

    for (let i = 0; i < size; i++) {
        console.log(row.trimEnd());
    }
}

squareOfStars(5);

//9.)

function aggregateElement(input){
    aggregate(input, 0, (a , b) => a + b);
    aggregate(input, 0, (a , b) => a + 1 / b);
    aggregate(input, '', (a , b) => a + b);

    function aggregate(arr, initialValue, func){
        let result = initialValue;

        for (let i = 0; i < arr.length; i++) {
            result = func(result, arr[i]); 
        }

        console.log(result);
    }
}

aggregateElement([2, 4, 8, 16])