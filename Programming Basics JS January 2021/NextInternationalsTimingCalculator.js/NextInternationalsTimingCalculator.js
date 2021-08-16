function calculator(input) {
    let country = input[0];
    let zone = input[1];
    let isles = Number(input[2]);
    let items = Number(input[3]);
    let boxes = Number(input[4]);

    let batchSmv = 0;
    let islesSmv = 0;
    let itemsSmv = 0;
    let boxesSmv = 0.8178;

    switch (zone) {
        case "A": batchSmv = 3.0414; islesSmv = 1.0948;
            switch (country) {
                case "Belfast": itemsSmv = 0.4173; break;
                case "Germany": itemsSmv = 0.4173; break;
                case "Russia": itemsSmv = 0.4173; break;
            }break;
        case "B": batchSmv = 1.0094; islesSmv = 3.4182;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078;; break;
                case "Germany": itemsSmv = 0.1780;; break;
                case "Russia": itemsSmv = 0.2655;; break;
            }break;
        case "C": batchSmv = 4.0363; islesSmv = 1.0030;
            switch (country) {
                case "Belfast": itemsSmv = 0.2036; break;
                case "Germany": itemsSmv = 0.2430;; break;
                case "Russia": itemsSmv = 0.3432;; break;
            }break;
        case "D": batchSmv = 2.9141; islesSmv = 1.3550;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078; break;
                case "Germany": itemsSmv = 0.1780; break;
                case "Russia": itemsSmv = 0.2655; break;
            }break;
        case "E": batchSmv = 2.3841; islesSmv = 2.1043;
            switch (country) {
                case "Belfast": itemsSmv = 0.1878; break;
                case "Germany": itemsSmv = 0.1844;; break;
                case "Russia": itemsSmv = 0.2727; break;
            }break;
        case "F": batchSmv = 1.3828; islesSmv = 1.3550;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078; break;
                case "Germany": itemsSmv = 0.1780; break;
                case "Russia": itemsSmv = 0.2655; break;
            }break;
        case "G": batchSmv = 4.3243; islesSmv = 1.3803;
            switch (country) {
                case "Belfast": itemsSmv = 0.2156; break;
                case "Germany": itemsSmv = 0.2117; break;
                case "Russia": itemsSmv = 0.2921; break;
            }break;
        case "H": batchSmv = 5.1363; islesSmv = 1.0030;
            switch (country) {
                case "Belfast": itemsSmv = 0.2036; break;
                case "Germany": itemsSmv = 0.2430; break;
                case "Russia": itemsSmv = 0.3432; break;
            }break;
        case "J": batchSmv = 1.3594; islesSmv = 1.0948;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078; break;
                case "Germany": itemsSmv = 0.1780; break;
                case "Russia": itemsSmv = 0.2655; break;
            }break;
        case "L": batchSmv = 4.5767; islesSmv = 1.0688;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078; break;
                case "Germany": itemsSmv = 0.1780; break;
                case "Russia": itemsSmv = 0.2655; break;
            }break;
        case "Q": batchSmv = 2.0722; islesSmv = 1.4393;
            switch (country) {
                case "Belfast": itemsSmv = 0.2036; break;
                case "Germany": itemsSmv = 0.2430; break;
                case "Russia": itemsSmv = 0.3432; break;
            }break;
        case "S": batchSmv = 2.4849; islesSmv = 1.6055;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078; break;
                case "Germany": itemsSmv = 0.1780; break;
                case "Russia": itemsSmv = 0.2655; break;
            }break;
        case "T": batchSmv = 3.1229; islesSmv = 1.6055;
            switch (country) {
                case "Belfast": itemsSmv = 0.2078; break;
                case "Germany": itemsSmv = 0.1780; break;
                case "Russia": itemsSmv = 0.2655; break;
            }break;
        case "V": batchSmv = 4.0379; islesSmv = 1.4393;
            switch (country) {
                case "Belfast": itemsSmv = 0.2036; break;
                case "Germany": itemsSmv = 0.2430; break;
                case "Russia": itemsSmv = 0.3432; break;
            }break;
        case "W": batchSmv = 2.1643; islesSmv = 1.8352;
            switch (country) {
                case "Belfast": itemsSmv = 0.2156; break;
                case "Germany": itemsSmv = 0.2117; break;
                case "Russia": itemsSmv = 0.2921; break;
            }break;
        case "X": batchSmv = 5.3487; islesSmv = 1.7039;
            switch (country) {
                case "Belfast": itemsSmv = 0.1910; break;
                case "Germany": itemsSmv = 0.1632; break;
                case "Russia": itemsSmv = 0.2464; break;
            }break;
        default: console.log("Error");
    }
    minutes = (batchSmv + (isles * islesSmv) + (items * itemsSmv) + (boxes * boxesSmv)).toFixed(2);
    console.log(minutes)
}
calculator(["Germany", "T", "2", "117", "3"])
calculator(["Germany", "V", "2", "150", "5"])
calculator(["Germany", "Q", "7", "150", "4"])
calculator(["Germany", "T", "10", "150", "4"])
calculator(["Germany", "Q", "14", "75", "2"])
calculator(["Belfast", "S", "13", "150", "5"])
calculator(["Belfast", "V", "7", "150", "5"])
