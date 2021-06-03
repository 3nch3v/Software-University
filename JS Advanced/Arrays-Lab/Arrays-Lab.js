//1.	Even Position Element

function solve(arr){
    let result = [];
    for (let i = 0; i < arr.length; i+=2) { 
        result[i] = arr[i];
    }

    console.log(result.filter(x => x.length > 0).join(' '));
}

solve(['20', '30', '40', '50', '60'])

//2.	Last K Numbers Sequence

function elementsSum(sequenceLength, previusElementsSumCount){
    let result = [];
    result.length = sequenceLength;
    result[0] = 1;

    for (let i = 1; i < sequenceLength; i++) {
        let currNum= 0;
        if(i - previusElementsSumCount < 0){
            for (let j = 0; j < i; j++) {
                currNum += result[j];
            }
        }else{
            for (let j = i - previusElementsSumCount; j < i; j++) {
                currNum += result[j];
            }
        }

        result[i] = currNum;
    }

    return result;
}

//3.	Sum First Last

function sumFristLast(input){
    let sum = 0;
    if(input.length > 1){
        sum += Number(input.pop());
        sum += Number(input.shift());
        return sum;
    } else if(input.length == 1){
        return Number(input.pop());
    }
    else{
        return 0;
    }
}

sumFristLast(['20', '30', '40']);

//4.	Negative / Positive Numbers

function orderNumbers(input){
    let result = [];
    input.forEach(number => {
        if(number >= 0){
            result.push(number)
        }else{
            result.unshift(number);
        }
    });
    result.forEach(number => {
        console.log(number);
    });
}

orderNumbers([7, -2, 8, 9])


//5.	Smallest Two Numbers

function samllestNumbers(input){
    let smallestNumbers = input
                .sort((a ,b) => a -b)
                .slice(0, 2);
    console.log(smallestNumbers.join(' '))
}

samllestNumbers([3, 0, 10, 4, 7, 3])

//6.	Bigger Half

function biggerHalf(input){
    let partSize = Math.ceil(input.length / 2);
    let smallestNumbers = input
    .sort((a ,b) => a -b)
    .slice(input.length - partSize);

    return smallestNumbers;
}

biggerHalf([4, 7, 2, 5, 9]);

//7.	Piece of Pie

function pieceOfPie(input, start, end){
    let startIndex = input.indexOf(start);
    let endIndex = input.indexOf(end);
    let sub = input.slice(startIndex, endIndex + 1);
    return sub;
};

pieceOfPie(['Pumpkin Pie', 'Key Lime Pie', 'Cherry Pie', 'Lemon Meringue Pie', 'Sugar Cream Pie'],
            'Key Lime Pie',
            'Lemon Meringue Pie'
);

//8.	Process Odd Positions

function oddPosition(input){
    let result = []
    for (let i = 0; i < input.length; i++) {
        if(i % 2 !=0 ){
            result.push(input[i] * 2);
        }
    }

    return result.reverse();
};

oddPosition([10, 15, 20, 25]);

//9.	Biggest Element

function biggersNumber(input){
    let currBiggestNum = -9007199254740991;
    for (let row = 0; row < input.length; row++) {
        let currRow = input[row];
        for (let col = 0; col < currRow.length; col++) {
            if(currRow[col] > currBiggestNum){
                currBiggestNum = currRow[col]
            }
        }
    }
    return currBiggestNum;
};

biggersNumber([[3, 5, 17, 12, 91, 5],
    [-1, 7, 4, 33, 6, 22],
    [1, 8, 99, 3, 10, 43]]
   );

//10.	Diagonal Sums

function diagonalSum(input){
    let mainDiagonal = 0;
    for (let row = 0; row < input.length; row++) {
        let currRow = input[row];
        for (let col = row; col <= row; col++) {
            mainDiagonal += currRow[col]          
        }
    }
    let secondaryDiagonal = 0;
    for (let row = 0; row < input.length; row++) {
        let currRow = input[row];
        for (let col = (currRow.length - 1) - row; col <= (currRow.length - 1) - row; col++) {
            secondaryDiagonal += currRow[col]          
        }
    }
    console.log(`${mainDiagonal} ${secondaryDiagonal}`);
};

diagonalSum([[3, 5, 17],
            [-1, 7, 14],
            [1, -8, 89]]
   );

//11.	Equal Neighbors

function equalNeighbors(input){
 let count = 0;

 for (let row = 0; row < input.length; row++) {

     let currCol = input[row];

     for (let col = 0; col < currCol.length; col++) {
         let currElement = currCol[col];
   
         if(row + 1 < input.length){
            if(input[row + 1][col] === currElement){
                count++;
           }
         }
         if(col + 1 < currCol.length){
            if(input[row][col + 1] === currElement){
                count++;
           }
        }
     }
 }
 return count;
}
  
equalNeighbors([['test', 'yes', 'yo', 'ho'],
                ['well', 'done', 'yo', '6'],
                ['not', 'done', 'yet', '5']]

);