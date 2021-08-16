function manOWar(input) {
    let pirateShip = input.shift().split(">").map(Number);
    let warship = input.shift().split(">").map(Number);
    let maxHealth = Number(input.shift());
    
    for (let line of input) {
        let [command, startIndex, endIndex, damage] = line.split(" ");
        startIndex = Number(startIndex);
        endIndex = Number(endIndex);
        damage = Number(damage);
        if (command == "Retire") {
            break;
        }
        if (command == "Fire") {
            let damage = endIndex;
            if (startIndex >= 0 && startIndex < warship.length) {
                warship[startIndex] -= damage
                if (warship[startIndex] <= 0) {
                    console.log(`You won! The enemy ship has sunken.`);
                    break;
                }
            }
        } else if (command == "Defend") {
            if (startIndex >= 0 && startIndex < pirateShip.length && endIndex >= 0 && endIndex < pirateShip.length) {
                for (let index = startIndex; index <= endIndex; index++) {
                    pirateShip[index] -= damage;
                    if (pirateShip[index] <= 0) {
                        console.log(`You lost! The pirate ship has sunken.`);
                        break;
                    }
                }
            }
        } else if (command == "Repair") {
            let index = startIndex;
            let health = endIndex;
            if (index >= 0 && index < pirateShip.length) {
                pirateShip[index] += health;
                if (pirateShip[index] > maxHealth) {
                    pirateShip[index] = maxHealth;
                }
            }


        } else if (command == "Status") {
            let count = 0;
            let lowCapacity = 0.20 * maxHealth;
            for (let section of pirateShip) {
                if (section < lowCapacity) {
                    count++;
                }
            }
            if (count > 0) {
                console.log(`${count} sections need repair.`);
            }
        }
    }
    let filteredPirateShip = pirateShip.filter((x) => x <= 0).length;
    let filteredWarship = warship.filter((x) => x <= 0).length;
    if (filteredPirateShip == 0 && filteredWarship == 0) {
        let sumPirateShip = 0;
        let sumWarship = 0;
        for (let index = 0; index < pirateShip.length; index++) {
            sumPirateShip += Number(pirateShip[index]);

        }
        for (let index = 0; index < warship.length; index++) {
            sumWarship += Number(warship[index]);

        }
        console.log(`Pirate ship status: ${sumPirateShip}`);
        console.log(`Warship status: ${sumWarship}`);
    }
}
manOWar(["12>13>11>20>66",
    "12>22>33>44>55>32>18",
    "70",
    "Fire 2 11",
    "Fire 8 100",
    "Defend 3 6 11",
    "Defend 0 3 5",
    "Repair 1 33",
    "Status",
    "Retire"])
