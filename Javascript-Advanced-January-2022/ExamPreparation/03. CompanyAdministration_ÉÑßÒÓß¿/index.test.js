const companyAdministration = require('./companyAdministration.js');
const { assert } = require('chai');

describe('companyAdministration tests', () => {
    describe('hiringEmployee function', () => {
        it('throw error when position not programmer', () => {
            assert.throws(() => companyAdministration.hiringEmployee("pepi", "neshtosi", 2), `We are not looking for workers for this position.`)
        });

        it('experience 3 years', () => {
            assert.equal(companyAdministration.hiringEmployee("pepi", "Programmer", 3), `pepi was successfully hired for the position Programmer.`)
        });

        it('less than 3 years exp', () => {
            assert.equal(companyAdministration.hiringEmployee("pepi", "Programmer", 2), `pepi is not approved for this position.`)
        });

        it('experience more than 3 years', () => {
            assert.equal(companyAdministration.hiringEmployee("pepi", "Programmer", 4), `pepi was successfully hired for the position Programmer.`)
        });
    });

    describe('calculateSalary function', () => {
        it('throws invalid hours', () => {
            assert.throws(() => companyAdministration.calculateSalary(-1), `Invalid hours`)
        });

        it('throws invalid hours', () => {
            assert.throws(() => companyAdministration.calculateSalary("dsadsa"), `Invalid hours`);
        });

        it('throws invalid hours', () => {
            assert.throws(() => companyAdministration.calculateSalary(undefined), `Invalid hours`);
        });

        it('returns money if hours are below 160', () => {
            assert.equal(companyAdministration.calculateSalary(1), 15)
        });

        it('returns money if hours are above 160', () => {
            assert.equal(companyAdministration.calculateSalary(161), 3415)
        });

        it('returns money if hours are above 160', () => {
            assert.equal(companyAdministration.calculateSalary(160), 2400)
        });


    });

    describe('firedEmployee function', () => {
        it('throws invalid input', () => {
            assert.throws(() => companyAdministration.firedEmployee(["pepi"], -1), `Invalid input`)
        });

        it('throws invalid input', () => {
            assert.throws(() => companyAdministration.firedEmployee(["pepi"], 2.2), `Invalid input`)
        });

        it('throws invalid input', () => {
            assert.throws(() => companyAdministration.firedEmployee(["pepi"], "aa"), `Invalid input`)
        });

        it('throws invalid input', () => {
            assert.throws(() => companyAdministration.firedEmployee("pepi", 0), `Invalid input`)
        });

        it('throws invalid input', () => {
            assert.throws(() => companyAdministration.firedEmployee(undefined, 0), `Invalid input`)
        });

        it('throws invalid input', () => {
            assert.throws(() => companyAdministration.firedEmployee([], 0), `Invalid input`)
        });

        it('return fired employees', () => {
            assert.equal(companyAdministration.firedEmployee(["pepi", "vani", "ceci"], 0), "vani, ceci");
        });

        it('return fired employees', () => {
            assert.equal(companyAdministration.firedEmployee(["pepi"], 0), '');
        });

    });
});
