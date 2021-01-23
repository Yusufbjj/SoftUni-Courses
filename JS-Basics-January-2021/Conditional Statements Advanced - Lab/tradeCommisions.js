function demo(input) {
    let city = input[0];
    let sales = Number(input[1]);
    let commisions = 0;

    if (sales >= 0 && sales <= 500) {
        switch (city) {
            case "Sofia": commisions = 0.05 * sales;console.log(commisions.toFixed(2)); break;
            case "Varna": commisions = 0.045 * sales;console.log(commisions.toFixed(2)); break;
            case "Plovdiv": commisions = 0.055 * sales;console.log(commisions.toFixed(2)); break;
            default: console.log("error"); break;
        }

    } else if (sales > 500 && sales <= 1000) {
        switch (city) {
            case "Sofia": commisions = 0.07 * sales;console.log(commisions.toFixed(2)); break;
            case "Varna": commisions = 0.075 * sales;console.log(commisions.toFixed(2)); break;
            case "Plovdiv": commisions = 0.08 * sales; console.log(commisions.toFixed(2));break;
            default: console.log("error"); break;
        }

    } else if (sales > 1000 && sales <= 10000) {
        switch (city) {

            case "Sofia": commisions = 0.08 * sales;console.log(commisions.toFixed(2)); break;
            case "Varna": commisions = 0.10 * sales;console.log(commisions.toFixed(2)); break;
            case "Plovdiv": commisions = 0.12 * sales;console.log(commisions.toFixed(2)); break;

            default: console.log("error"); break;

        }

    } else if (sales > 10000) {
        switch (city) {
            case "Sofia": commisions = 0.12 * sales;console.log(commisions.toFixed(2)); break;
            case "Varna": commisions = 0.13 * sales;console.log(commisions.toFixed(2)); break;
            case "Plovdiv": commisions = 0.145 * sales;console.log(commisions.toFixed(2)); break;
            default: console.log("error"); break;

        }

    } else {
        console.log("error");
    }

}
demo(["Bourgas",
    "9999.9999"])








