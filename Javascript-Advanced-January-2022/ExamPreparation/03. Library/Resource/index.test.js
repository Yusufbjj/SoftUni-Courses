const library = require('./library.js');

const { assert } = require('chai');

describe('library Tests', () => {

    describe('calcPriceOfBook function tests', () => {
        it('return half price before 1980', () => {
            assert.equal(library.calcPriceOfBook("asdas", 1950), `Price of asdas is 10.00`)
        });

        it('return half price before 1980', () => {
            assert.equal(library.calcPriceOfBook("asdas", 1980), `Price of asdas is 10.00`)
        });

        it('return price after 1980', () => {
            assert.equal(library.calcPriceOfBook("asdas", 2000), `Price of asdas is 20.00`)
        });

        it('throw invalid input error', () => {
            assert.throws(() => library.calcPriceOfBook(1, 1950), "Invalid input");
        });

        it('throw invalid input error', () => {
            assert.throws(() => library.calcPriceOfBook("harry potter", "1950"), "Invalid input");
        });

        it('throw invalid input error', () => {
            assert.throws(() => library.calcPriceOfBook("harry potter", 15.5), "Invalid input");
        });

        it('throw invalid input error', () => {
            assert.throws(() => library.calcPriceOfBook(undefined, 2000), "Invalid input");
        });
    });

    describe('findBook function tests', () => {
        it('throws error if arr is empty', () => {
            assert.throws(() => library.findBook([], "blabla"), "No books currently available");
        });

        it('we found the book message', () => {
            assert.equal(library.findBook(["blabla"], "blabla"), `We found the book you want.`)
        });

        it('we did not find the book message', () => {
            assert.equal(library.findBook(["blabla"], "blabla21321"), `The book you are looking for is not here!`)
        });
    });

    describe('arrangeTheBooks function tests', () => {

        it('throws invalid input', () => {
            assert.throws(() => library.arrangeTheBooks(-1), "Invalid input");

        });

        it('throws invalid input', () => {
            assert.throws(() => library.arrangeTheBooks("-1"), "Invalid input");

        });

        it('throws invalid input', () => {
            assert.throws(() => library.arrangeTheBooks(5.5), "Invalid input");

        });

        it('books are arranged', () => {
            assert.equal(library.arrangeTheBooks(40), `Great job, the books are arranged.`)
        });

        it('Insufficient space, more shelves need to be purchased.', () => {
            assert.equal(library.arrangeTheBooks(41), `Insufficient space, more shelves need to be purchased.`)
        });
    });

});
