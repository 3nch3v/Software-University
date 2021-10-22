const expect = require('chai').expect;
const cinema = require('./cinema.js');

describe('cinema tests', () => {
    describe('showMovies tests', () => {
        it('Empty array should return message "There are currently no movies to show."', () => {
            expect(cinema.showMovies([])).to.be.equal('There are currently no movies to show.');
        });
        it('It have to show the list of movie', () => {
            expect(cinema.showMovies(['It', 'Bee'])).to.be.equal('It, Bee');
        });
        it('The string length shoul be equal to 7', () => {
            expect(cinema.showMovies(['It', 'Bee']).length).to.be.equal(7);
        });
    });
    describe('ticketPrice test', () => {
        it('It should throw new Error if project type is not correct', () => {
            expect(function() { cinema.ticketPrice('Invalid Type')}).to.throw('Invalid projection type.');
        });
        it('It should 12.00 for type Premiere', () => {
            expect(cinema.ticketPrice('Premiere')).to.be.equal(12.00);
        });
        it('It should 7.50 for type Normal', () => {
            expect(cinema.ticketPrice('Normal')).to.be.equal(7.50);
        })
        it('It should 5.50 for type Discount', () => {
            expect(cinema.ticketPrice('Discount')).to.be.equal(5.50);
        })
    });
    describe('swapSeatsInHall test', () => {
        it('It should be Unsuccessful if the seats numbers are 1 and 0', () => {
            expect(cinema.swapSeatsInHall(1, 0)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seats numbers are 1 and 21', () => {
            expect(cinema.swapSeatsInHall(1, 21)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seats numbers are 0 and 12', () => {
            expect(cinema.swapSeatsInHall(0, 12)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seat number is the same', () => {
            expect(cinema.swapSeatsInHall(5, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the first seat number is not integer', () => {
            expect(cinema.swapSeatsInHall(9.1, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the second seat number is not integer 5.8 and 8', () => {
            expect(cinema.swapSeatsInHall(5, 8.6)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the first seat number is string', () => {
            expect(cinema.swapSeatsInHall('string', 5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seats numbers are string', () => {
            expect(cinema.swapSeatsInHall(5, 'str')).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the second seat number is missing', () => {
            expect(cinema.swapSeatsInHall(5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seat numbers are missing', () => {
            expect(cinema.swapSeatsInHall(undefined, undefined)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Successful if the seat numbers are valid (2 and 10)', () => {
            expect(cinema.swapSeatsInHall(8, 10)).to.be.equal('Successful change of seats in the hall.');
        });
        it('It should be Successful if the seat numbers are valid (1 and 20)', () => {
            expect(cinema.swapSeatsInHall(1, 20)).to.be.equal('Successful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seat numbers are strings (3 and 12)', () => {
            expect(cinema.swapSeatsInHall('3', '12')).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seat numbers are strings (undefined and 6)', () => {
            expect(cinema.swapSeatsInHall(undefined, 6)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seat numbers are strings (8 and undefined)', () => {
            expect(cinema.swapSeatsInHall(8, undefined)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('It should be Unsuccessful if the seat numbers are strings (8 and undefined)', () => {
            expect(cinema.swapSeatsInHall(true, 34)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
    });
});