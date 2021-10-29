const { expect } = require('chai');
const library = require('./library.js');

describe('Library tests.', () => {
    describe('Test calcPriceOfBook() function', () => {
        it('It has th throw message "Invalid input" with invalid input. Args undefined and number', () => {
            expect(function() {library.calcPriceOfBook(undefined, 4)}).to.throw("Invalid input");
        });
        it('It has th throw message "Invalid input" with invalid input. Args number instead of string and valid number', () => {
            expect(function() {library.calcPriceOfBook(56, 4)}).to.throw("Invalid input");
        });
        it('It has th throw message "Invalid input" with invalid input. Args valid string and undefined', () => {
            expect(function() {library.calcPriceOfBook('Book', undefined)}).to.throw("Invalid input");
        });
        it('It has th throw message "Invalid input" with invalid input. Args valid string and not a intiger as year', () => {
            expect(function() {library.calcPriceOfBook('Book', 5.6)}).to.throw("Invalid input");
        });
        it('It has th throw message "Invalid input" with invalid input. Args valid string and missing year', () => {
            expect(function() {library.calcPriceOfBook('Book')}).to.throw("Invalid input");
        });
        it('It has th throw message "Invalid input" with invalid input. Args array and valid year', () => {
            expect(function() {library.calcPriceOfBook([], 656)}).to.throw("Invalid input");
        });
        it('It has to return message `Price of King is 20.00` with valid sting and year after 1980', () => {
            expect(library.calcPriceOfBook('King', 2020)).to.equal(`Price of King is 20.00`);
        });
        it('It has to return message `Price of King is 10.00` with valid sting and year before 1980', () => {
            expect(library.calcPriceOfBook('King', 1980)).to.equal(`Price of King is 10.00`);
        });
    });

    describe('Test findBook() function', () => {
        it('It has th throw message "No books currently available" with input an empty array and book name', () => {
            expect(function() {library.findBook([], 'Book')}).to.throw("No books currently available");
        });
        it('It has to return message `We found the book you want.` with valid input.', () => {
            expect(library.findBook(['King', 'Book'], 'Book')).to.equal(`We found the book you want.`);
        });
        it('It has to return message `The book you are looking for is not here!` if the array does not contains the searching book', () => {
            expect(library.findBook(['King', 'Book'], 'No book')).to.equal(`The book you are looking for is not here!`);
        });
        it('It has to return message `The book you are looking for is not here!` if books name was not pass as arg.', () => {
            expect(library.findBook(['King', 'Book'])).to.equal(`The book you are looking for is not here!`);
        });
    });

    describe('Test arrangeTheBooks() function', () => {
        it('It has to throw "Invalid input" if the books count is not integer.', () => {
            expect(function() {library.arrangeTheBooks(3.5)}).to.throw("Invalid input");
        });
        it('It has to throw "Invalid input" if the books count is a negative integer.', () => {
            expect(function() {library.arrangeTheBooks(-55)}).to.throw("Invalid input");
        });
        it('It has to throw "Invalid input" if the books count is undefined.', () => {
            expect(function() {library.arrangeTheBooks(undefined)}).to.throw("Invalid input");
        });
        it('It has to throw "Invalid input" if the books count is a string.', () => {
            expect(function() {library.arrangeTheBooks('str')}).to.throw("Invalid input");
        });

        it('It has to return message `Insufficient space, more shelves need to be purchased.` if the number of books is bigger than the capacity.', () => {
            expect(library.arrangeTheBooks(50)).to.equal(`Insufficient space, more shelves need to be purchased.`);
        });
        it('It has to return message `Great job, the books are arranged.` with valid input.', () => {
            expect(library.arrangeTheBooks(40)).to.equal(`Great job, the books are arranged.`);
        });
    });
});