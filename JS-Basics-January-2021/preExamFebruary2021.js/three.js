function solve(input) {
    let team = input[0];
    let souvenirs = input[1];
    let souvenirsNumber = Number(input[2]);
    let totalPrice = 0;
    let invalid = false;
    let price = 0;

    switch (team) {
        case "Argentina":
            switch (souvenirs) {
                case "flags": price = 3.25; break;
                case "caps": price = 7.20; break;
                case "posters": price = 5.10; break;
                case "stickers": price = 1.25; break;
                default: invalid = true;
                    console.log("Invalid stock!");
            } break;
        case "Brazil":
            switch (souvenirs) {
                case "flags": price = 4.20; break;
                case "caps": price = 8.50; break;
                case "posters": price = 5.32; break;
                case "stickers": price = 1.20; break;
                default: invalid = true;
                    console.log("Invalid stock!");

            }break;
        case "Croatia":
            switch (souvenirs) {
                case "flags": price = 2.75; break;
                case "caps": price = 6.90; break;
                case "posters": price = 4.95; break;
                case "stickers": price = 1.10; break;
                default: invalid = true;
                    console.log("Invalid stock!");
            }break;
        case "Denmark":
            switch (souvenirs) {
                case "flags": price = 3.10; break;
                case "caps": price = 6.50; break;
                case "posters": price = 4.80; break;
                case "stickers": price = 0.90; break;
                default: invalid = true;
                    console.log("Invalid stock!");
            }break;
        default: invalid = true;
            console.log("Invalid country!");

    }
    totalPrice = souvenirsNumber * price;
    if (!invalid) {
        console.log(`Pepi bought ${souvenirsNumber} ${souvenirs} of ${team} for ${totalPrice.toFixed(2)} lv.`);
    } else {

    }

}
solve(["Brazil",
    "stickers",
    "5"]);













