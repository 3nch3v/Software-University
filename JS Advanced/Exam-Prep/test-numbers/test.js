const expect = require('chai').expect;
const testNumbers = require('./testNumbers');

describe('Test testNumbers.js', ()=> {
    describe('Test the functionality for func sumNumbers()', ()=> {
        it('Expect undefined. Test func sumnumbers with incorrect input string as first parameter and a valid number for second one and expect.', () => {
            expect(testNumbers.sumNumbers('a', 5)).to.be.undefined;
        })
        it('Expect undefined. Test func sumnumbers with incorrect input with a valid number as first parameter and a string for second one.', () => {
            expect(testNumbers.sumNumbers(-1, '5')).to.be.undefined;
        })
        it('Expect undefined. Test func sumnumbers with incorrect input with two strings as params', () => {
            expect(testNumbers.sumNumbers('-10', '5')).to.be.undefined;
        })
        it('Expect 3.00 as string with input 1 and 2.', () => {
            expect(testNumbers.sumNumbers(1, 2)).to.be.equal('3.00');
        })
        it('Expect 4.00 as string with input -1 and 5.', () => {
            expect(testNumbers.sumNumbers(-1, 5)).to.be.equal('4.00');
        })
        it('Expect -60.00 as string with input -10 and -50', () => {
            expect(testNumbers.sumNumbers(-10, -50)).to.be.equal('-60.00');
        })
        it('Expect 10.00 as string with input 2.5 and 7.50', () => {
            expect(testNumbers.sumNumbers(2.5, 7.50)).to.be.equal('10.00');
        })
    })

    describe('Test the functionality for func numberChecker()', ()=> {
        it('Expect to trow error with message "The input is not a number!" with incorect input -> string', () => {
            expect(function() {testNumbers.numberChecker('just a str')} )
                    .to.throw('The input is not a number!');
        })
        it('Expect to trow error with message "The input is not a number!" with undefined as input', () => {
            expect(function() {testNumbers.numberChecker(undefined)} )
                    .to.throw('The input is not a number!');
        })
        it('Expect to return message "The number is even!" with input 20.', () => {
            expect(testNumbers.numberChecker(20)).to.be.equal('The number is even!');
        })
        it('Expect to return message "The number is odd!" with input 3.', () => {
            expect(testNumbers.numberChecker(3)).to.be.equal('The number is odd!');
        })
        it('Expect to return message "The number is odd!" with input 5 as string.', () => {
            expect(testNumbers.numberChecker('5')).to.be.equal('The number is odd!');
        })
        it('Expect to return message "The number is even!" with input 10 as string.', () => {
            expect(testNumbers.numberChecker('10')).to.be.equal('The number is even!');
        })
        it('Expect to return message "The number is even!" with input -66 as string.', () => {
            expect(testNumbers.numberChecker('-66')).to.be.equal('The number is even!');
        })
        it('Expect to return message "The number is odd!" with input -63.', () => {
            expect(testNumbers.numberChecker('-63')).to.be.equal('The number is odd!');
        })
    })
    describe('Test the functionality for func averageSumArray()', ()=> {
        it('Expect to return 10 with input [5, 10, 15]', () => {
            expect(testNumbers.averageSumArray([5, 10, 15])).to.be.equal(10);
        })
        it('Expect to return -10 with input [-5, -10, -15]', () => {
            expect(testNumbers.averageSumArray([-5, -10, -15])).to.be.equal(-10);
        })
    })
})