const cinema = require('./cinema.js');
const { assert } = require('chai');

describe('cinema tests', () => {
    describe('showMovies function', () => {
       
        it('empty arr', () => {
            assert.equal(cinema.showMovies([]), `There are currently no movies to show.`)
        });

        it('return movies', () => {
            assert.equal(cinema.showMovies(["one","two"]), `one, two`)
        });

        it('return movies', () => {
            assert.equal(cinema.showMovies(["one"]), `one`)
        });

    });

    describe('ticketPrice function', () => {

        it('throws invalid type', () => {
            assert.throws(() => cinema.ticketPrice(-1), `Invalid projection type.`)
        });

        it('throws invalid type', () => {
            assert.throws(() => cinema.ticketPrice("dsadsa"), `Invalid projection type.`);
        });

        it('throws invalid type', () => {
            assert.throws(() => cinema.ticketPrice(undefined), `Invalid projection type.`);
        });

        it('throws invalid type', () => {
            assert.throws(() => cinema.ticketPrice([]), `Invalid projection type.`);
        });

        it('throws invalid type', () => {
            assert.throws(() => cinema.ticketPrice({}), `Invalid projection type.`);
        });

        it('throws invalid type', () => {
            assert.throws(() => cinema.ticketPrice(1), `Invalid projection type.`);
        });

        it('returns ticket price', () => {
            assert.equal(cinema.ticketPrice("Premiere"), 12.00)
        });

        it('returns ticker price', () => {
            assert.equal(cinema.ticketPrice("Normal"), 7.50)
        });

        it('returns ticket price', () => {
            assert.equal(cinema.ticketPrice("Discount"), 5.50)
        });


    });

    describe('swapSeatsInHall function', () => {

        it('same seats error', () => {
            assert.equal(cinema.swapSeatsInHall(1,1),"Unsuccessful change of seats in the hall.")
        });

        it('wrong first place argument', () => {
            assert.equal(cinema.swapSeatsInHall("",1),"Unsuccessful change of seats in the hall.")
        });

        it('wrong first place argument', () => {
            assert.equal(cinema.swapSeatsInHall(-1,1),"Unsuccessful change of seats in the hall.")
        });

        it('wrong first place argument', () => {
            assert.equal(cinema.swapSeatsInHall(21,1),"Unsuccessful change of seats in the hall.")
        });

        it('wrong first place argument', () => {
            assert.equal(cinema.swapSeatsInHall(15.5,1),"Unsuccessful change of seats in the hall.")
        });

        it('wrong first place argument', () => {
            assert.equal(cinema.swapSeatsInHall(0,1),"Unsuccessful change of seats in the hall.")
        });



        it('wrong second place argument', () => {
            assert.equal(cinema.swapSeatsInHall(1,""),"Unsuccessful change of seats in the hall.")
        });

        it('wrong second place argument', () => {
            assert.equal(cinema.swapSeatsInHall(1,-1),"Unsuccessful change of seats in the hall.")
        });

        it('wrong second place argument', () => {
            assert.equal(cinema.swapSeatsInHall(1,21),"Unsuccessful change of seats in the hall.")
        });

        it('wrong second place argument', () => {
            assert.equal(cinema.swapSeatsInHall(1,15.5),"Unsuccessful change of seats in the hall.")
        });

        it('wrong second place argument', () => {
            assert.equal(cinema.swapSeatsInHall(1,0),"Unsuccessful change of seats in the hall.")
        });

        it('succesfull', () => {
            assert.equal(cinema.swapSeatsInHall(1,2),"Successful change of seats in the hall.")
        });
        it('succesfull', () => {
            assert.equal(cinema.swapSeatsInHall(19,20),"Successful change of seats in the hall.")
        });
    });
});
