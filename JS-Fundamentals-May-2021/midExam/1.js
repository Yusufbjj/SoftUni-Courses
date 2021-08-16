function problem1(input) {
  input=  input.map(Number);
  let orders = input.shift();
  let totalPrice = 0;
    for (let index = 0; index < orders; index++) {
        let pricePerCapsule = input.shift();
        let days = input.shift();
        let capsulesCount = input.shift();
        let currentPrice =(days*capsulesCount)*pricePerCapsule;
        totalPrice+=currentPrice;
        console.log(`The price for the coffee is: $${currentPrice.toFixed(2)}`);
    }
    console.log(`Total: $${totalPrice.toFixed(2)}`);
}
problem1((["1","1.53","30","8"]));
problem1(["2",
"4.99",
"31",
"3",
"0.35",
"31",
"5"])
