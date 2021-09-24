function fancyBarcodes(input) {
    let pattern = /(@#+)([A-Z][A-Za-z\d]{4,}[A-Z])@#+/g;
    let numbersPattern = /\d/g;
    let n = Number(input.shift());
    for (let index = 0; index < n; index++) {
        let match = input[index].match(pattern);
        if (match) {
            match = match[0];
            let numbers = match.match(numbersPattern);
            if (numbers != null) {

                console.log(`Product group: ${numbers.join("")}`);
            } else {
                console.log(`Product group: 00`);
            }
        } else {
            console.log(`Invalid barcode`);
        }
    }
}
fancyBarcodes(["3",
    "@#FreshFisH@#",
    "@###Brea0D@###",
    "@##Che4s6E@##"])
fancyBarcodes(["6",
    "@###Val1d1teM@###",
    "@#ValidIteM@#",
    "##InvaliDiteM##",
    "@InvalidIteM@",
    "@#Invalid_IteM@#",
    "@#ValiditeM@#"])

