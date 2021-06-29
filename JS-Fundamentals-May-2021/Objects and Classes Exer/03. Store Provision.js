function storeProvision(stock, orderedProducts) {
    class Product{
        constructor(name,quantity){
            this.name = name;
            this.quantity = quantity;
        }
    }
    
    for (let index = 0; index < orderedProducts.length; index += 2) {
        let orderedProductName = orderedProducts[index];
        let orderedProductQuantity = Number(orderedProducts[index + 1]);
        if (!stock.includes(orderedProductName)) {
            stock.push(orderedProductName, orderedProductQuantity);
        } else {
            let indexOfOrderedProduct = (stock.indexOf(orderedProductName) + 1);
            stock[indexOfOrderedProduct] = Number(stock[indexOfOrderedProduct]);
            stock[indexOfOrderedProduct] += orderedProductQuantity;
        }


    }
    for (let index = 0; index < stock.length; index+=2) {
        let productName = stock[index];
        let productQuantity = stock[index+1];
        let product = new Product(productName,productQuantity);
        console.log(`${product.name} -> ${product.quantity}`);
        
    }

}
storeProvision([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
)