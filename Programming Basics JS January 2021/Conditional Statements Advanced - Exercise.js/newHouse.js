function test(input) {

    let flowerType = input[0];
    let flowersCount = Number(input[1]);
    let budget = Number(input[2]);
    let finalPrice = 0;


    if (flowerType === "Roses") {
        finalPrice = flowersCount * 5;

        if (flowersCount > 80) {
            finalPrice = finalPrice * 0.9;
        }

    } else if (flowerType ==="Dahlias") {
        finalPrice = flowersCount * 3.80;

        if (flowersCount > 90) {
            finalPrice = finalPrice * 0.85;
        }

    } else if (flowerType ==="Tulips") {
        finalPrice = flowersCount * 2.80;
        

        if (flowersCount > 80) {
            finalPrice = finalPrice * 0.85;
        }
    } else if (flowerType ==="Narcissus") {
        finalPrice = flowersCount * 3;


        if (flowersCount < 120) {
            finalPrice = finalPrice * 1.15;
        }
    } else if (flowerType ==="Gladiolus") {
        finalPrice = flowersCount * 2.50;

        if (flowersCount < 80) {
            finalPrice = finalPrice * 1.20;
        }
    }
    


    if (finalPrice > budget) {
        console.log(`Not enough money, you need ${(finalPrice - budget).toFixed(2)} leva more.`);
    } else {
        console.log(`Hey, you have a great garden with ${flowersCount} ${flowerType} and ${(budget - finalPrice).toFixed(2)} leva left.`)
    }


}
test(["Tulips","88","260"]);


