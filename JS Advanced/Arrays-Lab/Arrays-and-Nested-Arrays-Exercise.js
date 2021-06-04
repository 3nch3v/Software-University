//1.	Print an Array with a Given Delimiter

function printWithDelimiter(input, delimiter){
    console.log(input.join(delimiter));
}

printWithDelimiter(['One', 'Two', 'Three', 'Four', 'Five'], '-');

//2.	Print Every N-th Element from an Array 

function printElements(input, step){
    let result = [];
    for (let i = 0; i < input.length; i+= step) {
        result.push(input[i]);
    }

    return result;
}

printElements(['5', '20', '31', '4', '20'], 2);

//3.	Add and Remove Elements  

function addOrRemoveElement(commands){
    let arr = [];

    for (let index = 0; index < commands.length; index++) {
        switch(commands[index]){
            case 'add': arr.push(1 + index); break;
            case 'remove': arr.pop(); break;
            default: 'Invalid command';
        }
    }

    if(arr.length == 0){
        console.log('Empty');
    }
    else{
        arr.forEach(element => {
            console.log(element);
        });
    }
}

addOrRemoveElement(['remove', 'remove', 'remove', 'remove', 'remove']);

//4.	Rotate Array

function rotate(input, rorations){
    for (let index = 0; index < rorations; index++) {      
        input.unshift(input.pop());
    }

    console.log(input.join(' '));
}

rotate(['Banana', 'Orange', 'Coconut', 'Apple'], 15);


//5.	Extract Increasing Subsequence from Array

function increaseSubsequence(input) {
    let result=[];
    let biggestNum = input[0];

    for (let i = 0; i < input.length; i++) {
        
        if(input[i] >= biggest){

            result.push(input[i]);

            biggestNum = input[i];
        }
    }

    return result;
}

function solve(input){
    let maxNum = Number.MIN_SAFE_INTEGER;
    let output = input.reduce((arr, curr) => {
        if(curr >= maxNum){
            maxNum = curr;
            arr.push(curr);
        }
        return arr;
    }, []);

    return output;
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);

//6.	List of Names

function sortNames(input){
    let sortedNames = input.sort((a, b) => a.localeCompare(b));

    for (let index = 0; index < sortedNames.length; index++) {
        console.log(`${index + 1}.${sortedNames[index]}`);
    }
};
sortNames(["John", "Bob", "Christina", "Ema"]);


//7.	Sorting Numbers

function sortNumbers(input){
    let sorted = input.sort((a, b) => a - b);
    let output = [];
    let count = Math.ceil(sorted.length / 2);
    for (let index = 0; index < count; index++) {
        if(sorted.length > 0){
        output.push(sorted.shift());
        }
        if(sorted.length > 0){
            output.push(sorted.pop());
        }
    }

    return output;
};

sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 100]);

//8.	Sort an Array by 2 Criteria

function orderByTwoCriterias(input){
    let sorted = input
    .sort((a, b) => {    
        if( a.length - b.length === 0){
            return a.localeCompare(b);
        }

        return  a.length - b.length;
    })
    
    sorted.forEach(element => {
        console.log(element);
    });
};

orderByTwoCriterias(['alpha', 
'beta', 
'gamma']);


// 9.	Magic Matrices

function isMagicalMatrix(matrix){
    let isMagical = true;
    let firstRowSum = matrix[0].reduce((a, b) => a + b, 0);

    for (let row = 1; row < matrix.length; row++) {
        let currRowSum = matrix[row].reduce((a, b) => a + b, 0);
        if(firstRowSum !== currRowSum){
            isMagical = false;
            break;
        }
    }

    if(isMagical){

        let colSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            colSum += matrix[row][0];
        }

    let cuurCol = 1;

    for (let i = 1; i < matrix.length; i++) {
        let currColSum = 0;
   
        for (let row = 0; row < matrix.length; row++) {
            currColSum += matrix[row][cuurCol];
        }

        if(currColSum !== colSum){
            isMagical = false;
            break;
        };

        cuurCol++;
    }; 
    }

    return isMagical;
}

isMagicalMatrix([[11, 32, 45],
                 [21, 0, 1],
                 [21, 1, 1]] );


//10.	*Tic-Tac-Toe

function ticTacToe(gameMoves){
    let game = [[false, false, false],
                    [false, false, false],
                    [false, false, false]];
    let firstPlayer = 'X';
    let secondPlayer = 'O';

    let firstMoveX = gameMoves[0].split(' ');
    let row = Number(firstMoveX[0]);
    let col = Number(firstMoveX[1]);
    game[row][col] = firstPlayer;

    let movesX = 1;
    let movesO = 0;
    
    let spaceChecker = (matrix) => matrix.some((arr) => arr.some(value => value === false));

    function hasWinner(game){
        let isWinner = false;
        if(game[0][0] === game[0][1] && game[0][1] === game[0][2] && game[0][0] !== false ){
            isWinner = true;
        }else if(game[1][0] === game[1][1] && game[1][1] === game[1][2] && game[1][0] !== false ){
                isWinner = true;
        }else if(game[2][0] === game[2][1] && game[2][1] === game[2][2] && game[2][0] !== false ){
              isWinner = true;
        }else if(game[0][0] === game[1][0] && game[1][0] === game[2][0] && game[0][0] !== false ){
          isWinner = true;
        }else if(game[0][1] === game[1][1] && game[1][1] === game[2][1] && game[0][1] !== false ){
              isWinner = true;
        }else if(game[0][2] === game[1][2] && game[1][2] === game[2][2] && game[0][2] !== false ){
              isWinner = true;
        }else if(game[0][0] === game[1][1] && game[1][1] === game[2][2] && game[0][0] !== false ){
              isWinner = true;
        }else if(game[0][2] === game[1][1] && game[1][1] === game[2][0] && game[0][2] !== false ){
              isWinner = true;
        }     
        return isWinner;
    }

    function printMatrix(game){
        for (let i = 0; i < game.length; i++) {
            console.log(game[i].join('\t')); 
        }
    }

    for (let i = 1; i < gameMoves.length; i++) {
        let noMoreFreeSpace = spaceChecker(game);

        if(!noMoreFreeSpace){
            console.log('The game ended! Nobody wins :(')
            printMatrix(game)
            break;
        }

        let currMove = gameMoves[i].split(' ');
        let row = Number(currMove[0]);
        let col = Number(currMove[1]);

        if(game[row][col] === false){
            if(movesX === movesO){
                game[row][col] = firstPlayer;
                movesX++;
            }else{
                game[row][col] = secondPlayer;
                movesO++;
            }
        }else{
            console.log('This place is already taken. Please choose another!');
        }
        
        let isWinner = hasWinner(game);

        if(isWinner){
            if(movesO === movesX){
                console.log('Player O wins!');
            }else{
                console.log('Player X wins!');
            }          
            printMatrix(game)
            break;
        }  
    }
};

ticTacToe(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]);
