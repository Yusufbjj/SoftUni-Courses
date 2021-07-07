function inventory(input) {
    let inventory = input.shift().split(", ");
    for (let line of input) {
        let [command, item] = line.split(" - ");
        if (command == "Craft!") {
            console.log(`${inventory.join(", ")}`);
            break;
        }
        if (command == "Collect") {
            if (!inventory.includes(item)) {

                inventory.push(item);
            }

        } else if (command == "Drop") {
            if (inventory.includes(item)) {
                let index = inventory.indexOf(item);
                inventory.splice(index, 1);
            }
        } else if (command == "Combine Items") {
            let [oldItem, newItem] = item.split(":");
            if (inventory.includes(oldItem)) {
                let index = inventory.indexOf(oldItem);
                inventory.splice(index+1, 0, newItem);
            }

        } else if (command == "Renew") {
            if (inventory.includes(item)) {
                let index = inventory.indexOf(item);

                let removedItem = inventory.splice(index,1);
                inventory.push(removedItem[0]);
            }
        }
    }
}
inventory(['Iron, Wood, Sword', 'Collect - Gold', 'Drop - Wood', 'Craft!']);
inventory([
    'Iron, Sword',
    'Drop - Bronze',
    'Combine Items - Sword:Bow',
    'Renew - Iron',
    'Craft!'
]
)
