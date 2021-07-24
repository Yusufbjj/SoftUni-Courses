function perfectNumber(n) {
    function sumOfPositiveDevisors(b) {
        let sum = 0;
        for (let index = 0; index < b; index++) {
            if (b % index === 0) {
                sum += index;
            }
        }
        return sum;
    }
    if (sumOfPositiveDevisors(n) != n) {
        return "It's not so perfect."
    } else {
        return "We have a perfect number!"
    }
}
let result = perfectNumber(28);
console.log(result);
