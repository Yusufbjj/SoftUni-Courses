function factorial(a, b) {
    function factorial(a) {
        let factorialSum = a;
        for (let index = a - 1; index > 0; index--) {
            factorialSum *= index;
        }
        return factorialSum;
    }
    return (factorial(a) / factorial(b)).toFixed(2);
}
let result = factorial(5, 2);
console.log(result);