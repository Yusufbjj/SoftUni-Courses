function solve(input) {

    let products = {};

    for (let line of input) {
        let [product, price] = line.split(" : ");

        products[product] = Number(price);

    }

    let result = Object.entries(products);

    result.sort((a, b) => a[0].localeCompare(b[0]));

    let firstChar = "";

    for (let index = 0; index < result.length; index++) {

        if (firstChar != result[index][0][0]) {

            firstChar =  result[index][0][0];

            console.log(firstChar);
        }

        console.log(`  ${result[index][0]}: ${result[index][1]}`);
    }
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);