// const isOddOrEven = require('./02.isOddOrEven.js');

// const lookupChar = require('./03. Char Lookup.js');


const { assert } = require('chai');

// describe('isOddOrEven function test', () => {
//     it('test with num', () => {
//         assert.equal(isOddOrEven(5),undefined);
//     });

//     it('test with arr', () => {
//         assert.equal(isOddOrEven([]),undefined);
//     });

//     it('test with even str', () => {
//         assert.equal(isOddOrEven("Hi"),"even");
//     });

//     it('test with even str', () => {
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