function computerStore(input) {
    let totalPriceWithoutTax = 0;
    let totalAmountOfTax = 0;
    let totalPriceWithTax = 0;
    for (let command of input) {
        if (Number(command) > 0) {
            totalPriceWithoutTax += Number(command);
            totalAmountOfTax += 0.20 * Number(command);

        } else if (command == "special") {
            totalPriceWithTax = (totalPriceWithoutTax + totalAmountOfTax) * 0.90;
        } else if (command == "regular") {
            totalPriceWithTax = totalPriceWithoutTax + totalAmountOfTax;

        } else {
            console.log(`Invalid price!`);
        }
    }
    if (totalPriceWithTax != 0) {

        console.log(`    Congratulations you've just bought a new computer!
        Price without taxes: ${totalPriceWithoutTax.toFixed(2)}$
        Taxes: ${totalAmountOfTax.toFixed(2)}$
        -----------
        Total price: ${totalPriceWithTax.toFixed(2)}$`);
    } else {
        console.log(`Invalid order!`);
    }
}
computerStore([
    '1050',
    '200',
    '450',
    '2',
    '18.50',
    '16.86',
    'special'
]
)
computerStore([
    '1023',
    '15',
    '-20',
    '-5.50',
    '450',
    '20',
    '17.66',
    '19.30', 'regular'
]
)
computerStore([
    'regular'
]
)