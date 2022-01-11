function solve(str, weight, pricePerKg) {

    weight /= 1000;

    let moneyNeeded = weight * pricePerKg;

    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${str}.`);
}
solve('orange', 2500, 1.80);