function demo(input) {
    let destination = input[0];
    let dates = input[1];
    let nights = Number(input[2]);

    let total = 0;

    switch (destination) {
        case "France":
            switch (dates) {
                case "21-23": total = nights * 30; break;
                case "24-27": total = nights * 35; break;
                case "28-31": total = nights * 40; break;
                default:
                    console.log("error");
            }break;
        case "Italy":
            switch (dates) {
                case "21-23": total = nights * 28; break;
                case "24-27": total = nights * 32; break;
                case "28-31": total = nights * 43; break;
                default:
                    console.log("error");
            }break;
        case "Germany":
            switch (dates) {
                case "21-23": total = nights * 32; break;
                case "24-27": total = nights * 37; break;
                case "28-31": total = nights * 43; break;
                default:
                    console.log("error");
            }break;
            
    }
    console.log(`Easter trip to ${destination} : ${total.toFixed(2)} leva.`);


}
demo(["France",
    "28-31",
    "8"]);

