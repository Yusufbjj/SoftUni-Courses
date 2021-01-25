function test(input) {
    let time = input[1];
    let degrees = Number(input[0]);
    let outfit = 0;
    let shoes = 0;

    if (degrees >= 10 && degrees <= 18) {
        if(time=="Morning"){
            outfit="Sweatshirt";
            shoes = "Sneakers";
        }else if (time=="Afternoon" || time=="Evening"){
            outfit="Shirt";
            shoes = "Moccasins";
        }

    }else if (degrees > 18 && degrees <= 24) {
        if(time=="Morning" || time=="Evening"){
            outfit="Shirt";
            shoes = "Moccasins";
        }else if (time=="Afternoon" ){
            outfit="T-Shirt";
            shoes = "Sandals";
        }

    }else if (degrees >= 25) {
        if(time=="Morning"){
            outfit="T-Shirt";
            shoes = "Sandals";
        }else if (time=="Afternoon"){
            outfit="Swim Suit";
            shoes = "Barefoot";
        }else if (time=="Evening"){
            outfit="Shirt";
            shoes = "Moccasins";
        }

    }
    console.log(`It's ${degrees} degrees, get your ${outfit} and ${shoes}.`);

}
test(["22",
"Afternoon"]);




