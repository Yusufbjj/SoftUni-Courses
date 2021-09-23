function shopingList(array) {
    let initialList = array.shift().split("!");
    for (let command of array) {
        let [typeOfCommand, product, newProduct] = command.split(" ");
        if (typeOfCommand === "Urgent") {
            if (!initialList.includes(product)) {
                initialList.unshift(product);
            }
        } else if (typeOfCommand === "Unnecessary") {
            if (initialList.includes(product)) {
                let indexOfProduct = initialList.indexOf(product);
                initialList.splice(indexOfProduct, 1);
            }
        } else if (typeOfCommand === "Correct") {
            if (initialList.includes(product)) {
                let indexOfProduct = initialList.indexOf(product);
                initialList[indexOfProduct] = newProduct;
            }

        } else if (typeOfCommand === "Rearrange") {
            if (initialList.includes(product)) {
                let indexOfProduct = initialList.indexOf(product);
                let item = initialList.splice(indexOfProduct, 1);
                initialList.push(item);
            }
        } else {
            break;
        }

    }
    console.log(initialList.join(", "));

}
shopingList(["Tomatoes!Potatoes!Bread",
    "Unnecessary Milk",
    "Urgent Tomatoes",
    "Go Shopping!"
])