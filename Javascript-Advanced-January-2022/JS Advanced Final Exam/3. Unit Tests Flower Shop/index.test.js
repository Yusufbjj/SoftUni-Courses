const flowerShop = require('./flowerShop.js');
const { assert } = require('chai');

describe('flower shop tests', () => {

    describe('calcPriceOfFlowers function', () => {
        it('throw invalid input with invalid flower as number', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers(1, 1, 1), "Invalid input!");
        });

        it('throw invalid input with invalid price ', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', "1", 1), "Invalid input!");
        });

        it('throw invalid input with invalid price ', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 12.2, 1), "Invalid input!");
        });

        it('throw invalid input with invalid quantity', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, "1"), "Invalid input!");
        });

        it('throw invalid input with invalid quantity', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, 12.2), "Invalid input!");
        });

        it('return succesfull message', () => {
            assert.equal(flowerShop.calcPriceOfFlowers('rose', 1, 2), `You need $2.00 to buy rose!`)
        });

    });

    describe('checkFlowersAvailable function tests', () => {
        it('return message flower available', () => {
            assert.equal(flowerShop.checkFlowersAvailable('rose', ["rose", "Lily", "Orchid"]), `The rose are available!`);
        });

        it('return message flower not available', () => {
            assert.equal(flowerShop.checkFlowersAvailable('invalid', ["rose", "Lily", "Orchid"]), `The invalid are sold! You need to purchase more!`);
        });

    });

    describe('sellFlowers function tests', () => {
        it('throws invalid input ', () => {
            assert.throws(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], "1"), `Invalid input!`);
        });

        it('throws invalid input', () => {
            assert.throws(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], -1), `Invalid input!`);
        });

        it('throws invalid input', () => {
            assert.throws(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 10), `Invalid input!`);
        });

        it('throws invalid input', () => {
            assert.throws(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 10.2), `Invalid input!`);
        });

        it('throws invalid input', () => {
            assert.throws(() => flowerShop.sellFlowers(1, 1), `Invalid input!`);
        });

        it('throws invalid input', () => {
            assert.throws(() => flowerShop.sellFlowers({}, 1), `Invalid input!`);
        });

        it('throws invalid input', () => {
            assert.throws(() => flowerShop.sellFlowers(undefined, 1), `Invalid input!`);
        });

        it('returns the array after the flower has been removed', () => {
            assert.equal(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 1),`Rose / Orchid`);
        });
    });

});


