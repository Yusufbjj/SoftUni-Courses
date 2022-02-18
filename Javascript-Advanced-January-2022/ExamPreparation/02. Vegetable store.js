class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        for (let ele of vegetables) {

            let [type, quantity, price] = ele.split(" ");

            let vegObject = {
                type,
                quantity: Number(quantity),
                price: Number(price)
            }

            let isVegetablePresentInTheAvailableProductsArray = false;

            let foundVegObj = this.availableProducts.find(e => e.type === vegObject.type);

            if (foundVegObj) {
                isVegetablePresentInTheAvailableProductsArray = true;

                foundVegObj.quantity += Number(quantity);

                if (foundVegObj.price < vegObject.price) {
                    foundVegObj.price = vegObject.price;
                }
            } else {
                this.availableProducts.push(vegObject);
            }
        }

        let typesArr = [];
        for (let product of this.availableProducts) {
            typesArr.push(product.type);
        }
        return (`Successfully added ${typesArr.join(", ")}`);
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;
        for (let product of selectedProducts) {
            let [type, quantity] = product.split(" ");


            let vegObj = {
                type,
                quantity: Number(quantity)
            }

            let currentVegetableObject = this.availableProducts.find(e => e.type === vegObj.type);

            if (!currentVegetableObject) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            } else {
                if (vegObj.quantity > currentVegetableObject.quantity) {
                    throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
                } else {
                    let currentPrice = currentVegetableObject.price * vegObj.quantity;
                    totalPrice += currentPrice;
                    currentVegetableObject.quantity -= vegObj.quantity;

                }
            }

        }
        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity) {
        quantity = Number(quantity);

        let currentVegetableObject = this.availableProducts.find(e => e.type === type);

        if (!currentVegetableObject) {
            throw new Error(`${type} is not available in the store.`);
        } else {
            if (quantity > currentVegetableObject.quantity) {
                currentVegetableObject.quantity = 0;

                return `The entire quantity of the ${type} has been removed.`;
            } else {
                currentVegetableObject.quantity -= quantity;
                return `Some quantity of the ${type} has been removed.`;
            }
        }

    }

    revision() {
        let result = "Available vegetables:\n";
        for (let ele of this.availableProducts.sort((a, b) => a.price - b.price)) {
            result += `${ele.type}-${ele.quantity}-$${ele.price}\n`;
        }
        result += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;
        return result;
    }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());



