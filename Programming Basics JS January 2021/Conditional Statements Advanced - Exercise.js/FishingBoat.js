function test(input) {
    let budget = Number(input[0]);
    let season = input[1];
    let fishermen = Number(input[2]);

    let boatPrice = 0;

    if (season == "Spring") {
        boatPrice = 3000;
        if (fishermen <= 6) {
            boatPrice = boatPrice * 0.90;
        } else if (fishermen <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fishermen > 11) {
            boatPrice = boatPrice * 0.75;
        }
        if(fishermen%2==0){
            boatPrice=boatPrice*0.95;
        }else {
            
        }

    } else if (season == "Summer") {
        boatPrice = 4200;

        if (fishermen <=6) {
            boatPrice = boatPrice * 0.90;
        } else if (fishermen <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fishermen > 11) {
            boatPrice = boatPrice * 0.75;
        }
        if(fishermen%2==0){
            boatPrice=boatPrice*0.95;
        }else {
            
        }

    } else if (season == "Autumn") {
        boatPrice = 4200;

        if (fishermen <= 6) {
            boatPrice = boatPrice * 0.90;
        } else if (fishermen <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fishermen > 11) {
            boatPrice = boatPrice * 0.75;
        }
    } else if (season == "Winter") {
        boatPrice = 2600;

        if (fishermen <=6) {
            boatPrice = boatPrice * 0.90;
        } else if (fishermen <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fishermen > 11) {
            boatPrice = boatPrice * 0.75;
        }
        if(fishermen%2==0){
            boatPrice=boatPrice*0.95;
        }else {
            
        }
    }
    if(budget>boatPrice){
        console.log(`Yes! You have ${(budget-boatPrice).toFixed(2)} leva left.`);
    }else {
      console.log (`Not enough money! You need ${(boatPrice-budget).toFixed(2)} leva.`);
    }
    
}
test(["3000",
"Summer",
"11"]);







