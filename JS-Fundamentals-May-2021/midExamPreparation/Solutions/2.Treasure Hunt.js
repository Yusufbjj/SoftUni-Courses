function treasureHunt(input) {
    let initialLoot = input.shift().split("|");

    for (let command of input) {
       
        let [action, ...items] = command.split(" ");
        if(action=="Yohoho!"){
            break;
        }
        if (action == "Loot") {
            for (let item of items) {
                if (!initialLoot.includes(item)) {
                    initialLoot.unshift(item);
                }
            }
        } else if (action == "Drop") {
            let index = Number(items[0]);
            if (index >= 0 && index < initialLoot.length) {
               
                let loot = initialLoot.splice(index, 1);
                initialLoot.push(loot[0]);
            }

        } else if (action == "Steal") {         
            let index = Number(items[0]);
            let stolenItems = initialLoot.slice(-index);
            initialLoot.splice(-index);
            console.log(`${stolenItems.join(", ")}`);
        } 

    }
    let averageGain = 0;
    if (initialLoot.length >0) {
        for (let item of initialLoot) {
            averageGain += item.length / initialLoot.length;
        }
        console.log(`Average treasure gain: ${averageGain.toFixed(2)} pirate credits.`);
        
    } else {
        console.log(`Failed treasure hunt.`);

    }
}
treasureHunt(["Gold|Silver|Bronze|Medallion|Cup",
    "Loot Wood Gold Coins",
    "Loot Silver Pistol",
    "Drop 3",
    "Steal 3",
    "Yohoho!"]);
treasureHunt(["Diamonds|Silver|Shotgun|Gold",
    "Loot Silver Medals Coal",
    "Drop -1",
    "Drop 1",
    "Steal 6",
    "Yohoho!"])

