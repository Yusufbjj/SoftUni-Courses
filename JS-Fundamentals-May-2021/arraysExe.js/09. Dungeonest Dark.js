function dungeon(array) {
    let rooms = array.join("").split("|");
    let health = 100;
    let coins = 0;
    let roomsCounter = 0;
    let isSuccesfull = true;
    for (const room of rooms) {
        let [item, monsterNumber] = room.split(" ");
        roomsCounter++;
        monsterNumber = Number(monsterNumber);
        if (item === "potion") {
            let currentHealth = health;
            health += monsterNumber;
            if(health<100){
                console.log(`You healed for ${monsterNumber} hp.`);

            }else{
                console.log(`You healed for ${100-currentHealth} hp.`);
            }
            if(health>100){
                health=100;
            }

            console.log(`Current health: ${health} hp.`);
        } else if (item === "chest") {
            coins += monsterNumber;
            console.log(`You found ${monsterNumber} coins.`);
        } else {
            health -= monsterNumber;
            if (health > 0) {
                console.log(`You slayed ${item}.`);
            } else {
                isSuccesfull = false;
                console.log(`You died! Killed by ${item}.`);
                console.log(`Best room: ${roomsCounter}`);break;
            }
        }

    }
    if (isSuccesfull) {
        console.log(`You've made it!`);
        console.log(`Coins: ${coins}`);
        console.log(`Health: ${health}`);

    }
}
dungeon(["cat 10|potion 30|orc 10|chest 10|snake 25|chest 110"]);