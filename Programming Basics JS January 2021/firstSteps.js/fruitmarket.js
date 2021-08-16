function demo(input){
    let strawberryPrice = Number(input[0])
    let bananas = Number (input[1]);
    let oranges = Number(input[2]);
    let raspberries = Number(input[3]);
    let strawberries = Number(input[4]);
    let priceRaspberries = strawberryPrice / 2;
    let priceOranges = 0.6 * priceRaspberries;
    let priceBananas = 0.2 * priceRaspberries;
    let raspberriesSum = raspberries * priceRaspberries;
    let orangesSum = oranges * priceOranges;
    let bananasSum = bananas * priceBananas;
    let strawberriesSum = strawberries * strawberryPrice;
    let totalSum = raspberriesSum + orangesSum + strawberriesSum + bananasSum ;






    console.log (totalSum)
}
demo(['48','10','3.3','6.5','1.7'])