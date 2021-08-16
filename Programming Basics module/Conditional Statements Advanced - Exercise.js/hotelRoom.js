function test(input) {
    let month = input[0];
    let nights = Number(input[1]);

    let priceStudio = 0;
    let priceApartment = 0;

    if (month === "May" || month === "October") {
        priceStudio = nights * 50;
        priceApartment = nights * 65;

        if (nights > 7 && nights < 14) {
            priceStudio = priceStudio * 0.95;


        } else if (nights > 14) {
            priceStudio = priceStudio * 0.70;
            priceApartment = priceApartment * 0.90;


        }

    } else if (month === "June" || month === "September") {

        priceStudio = nights * 75.20;
        priceApartment = nights * 68.70;

        if (nights <= 14) {
            priceStudio = nights * 75.20;
            priceApartment = nights * 68.70;


        } else if (nights > 14) {
            priceStudio = priceStudio * 0.80;
            priceApartment = priceApartment * 0.90;


        }

    } else {
        priceStudio = nights * 76;
        priceApartment = nights * 77;

        if (nights > 14) {
            priceApartment = priceApartment * 0.90;
        }

    }
    console.log(`Apartment: ${priceApartment.toFixed(2)} lv.`);
    console.log(`Studio: ${priceStudio.toFixed(2)} lv.`);

}
test(["August",
"20"]);












