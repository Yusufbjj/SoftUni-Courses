// const isOddOrEven = require('./02.isOddOrEven.js');

// const lookupChar = require('./03. Char Lookup.js');

const mathEnforcer = require('./04. Math Enforcer.js');

const { assert } = require('chai');

describe('mathEnforcer function tests', () => {
    describe('add five function tests', () => {
        it('should return undefined with string', () => {
            assert.equal(mathEnforcer.addFive('TEST'), undefined);
        });

        it('should return undefined with an array', () => {
            assert.equal(mathEnforcer.addFive([]), undefined);
        });

        it('should return undefined with an object', () => {
            assert.equal(mathEnforcer.addFive({}), undefined);
        });

        it('should return undefined with undefined', () => {
            assert.equal(mathEnforcer.addFive(undefined), undefined);
        });

        it('should return undefined with null', () => {
            assert.equal(mathEnforcer.addFive(null), undefined);
        });

        it('positive number 5', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
        });

        it('negative number -5', () => {
            assert.equal(mathEnforcer.addFive(-5), 0);
        });

        it('decimal number +5.5', () => {
            assert.equal(mathEnforcer.addFive(5.5), 10.5);
        });

    });

    describe('subtract ten function tests', () => {
        it('should return undefined with string', () => {
            assert.equal(mathEnforcer.subtractTen('TEST'), undefined);
        });

        it('should return undefined with an array', () => {
            assert.equal(mathEnforcer.subtractTen([]), undefined);
        });

        it('should return undefined with an object', () => {
            assert.equal(mathEnforcer.subtractTen({}), undefined);
        });

        it('should return undefined with undefined', () => {
            assert.equal(mathEnforcer.subtractTen(undefined), undefined);
        });

        it('should return undefined with null', () => {
            assert.equal(mathEnforcer.subtractTen(null), undefined);
        });

        it('positive integer number 5', () => {
            assert.equal(mathEnforcer.subtractTen(5), -5);
        });

        it('negative integer number -5', () => {
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        });

        it('decimal number 10.5', () => {
            assert.equal(mathEnforcer.subtractTen(10.5), 0.5);
        });
    });

    describe('sum of two numbers function tests', () => {
        it('two positive integer numbers', () => {
            assert.equal(mathEnforcer.sum(10, 20), 30);
        });

        it('two negative numbers', () => {
            assert.equal(mathEnforcer.sum(-10, -5), -15);
        });

        it('two decimal numbers', () => {
            assert.equal(mathEnforcer.sum(10.2, 5.5), 15.7);
        });

        it('first parameter string,second number', () => {
            assert.equal(mathEnforcer.sum('gfdgdf', 5), undefined);
        });

        it('first parameter number,second string', () => {
            assert.equal(mathEnforcer.sum(5, 'dgfd'), undefined);
        });
    });
});




// describe('isOddOrEven function test', () => {
//     it('test with num as parameter', () => {
//         assert.equal(isOddOrEven(5),undefined);
//     });

//     it('test with arr parameter', () => {
//         assert.equal(isOddOrEven([]),undefined);
//     });

//     it('test with even length string', () => {
//         assert.equal(isOddOrEven("Hi"),"even");
//     });

//     it('test with odd length string', () => {
//         assert.equal(isOddOrEven("Hello"),"odd");
//     });

// });

// describe('lookupChar function test', () => {
//     it('test with str as first parameter', () => {
//         assert.equal(lookupChar('pepi', 1), 'e');
//     });

//     it('test with num as first parameter', () => {
//         assert.equal(lookupChar(100, 1), undefined);
//     });

//     it('test with decimal as second parameter', () => {
//         assert.equal(lookupChar("pepi", 10.5), undefined);
//     });

//     it('test with empty string as first parameter', () => {
//         assert.equal(lookupChar("", 1), "Incorrect index");
//     });

//     it('test with negative index', () => {
//         assert.equal(lookupChar("pepi", -1), "Incorrect index");
//     });

//     it('test with index bigger than string length ', () => {
//         assert.equal(lookupChar("pepi", 5), "Incorrect index");
//     });
// });