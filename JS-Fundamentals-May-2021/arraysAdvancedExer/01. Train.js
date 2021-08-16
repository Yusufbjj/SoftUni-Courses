function train(array) {
    let wagons = array.shift().split(" ");
    let capacity = Number(array.shift());
    for (const line of array) {
        let [command, passengers] = line.split(" ")
        if (command === "Add") {
            wagons.push(passengers);
        } else {
            command = Number(command);
            for (let index = 0; index < wagons.length; index++) {

                if (Number(wagons[index]) + command <= capacity) {
                    wagons[index] = Number(wagons[index]) + command; break;
                }
            }
        }
    }
    console.log(wagons.join(" "));
}
train(['32 54 21 12 4 0 23',
    '75',
    'Add 10',
    'Add 0',
    '30',
    '10',
    '75']
)