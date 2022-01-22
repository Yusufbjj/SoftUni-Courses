function solve(input) {
    let products = [];

    for (let line of input) {

        let [townName, productName, productPrice] = line.split(" | ");

        if (products.filter(x => x.productName === productName).length > 0) {

            let obj = products.find(x => x.productName === productName);

            if (obj.productPrice > Number(productPrice)) {
                obj.productPrice = Number(productPrice);
                obj.townName = townName;
            }

        } else {

            products.push({ townName, productName, productPrice: Number(productPrice) });

        }
    }

    for (let obj of products) {
        
        console.log(`${obj.productName} -> ${obj.productPrice} (${obj.townName})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);