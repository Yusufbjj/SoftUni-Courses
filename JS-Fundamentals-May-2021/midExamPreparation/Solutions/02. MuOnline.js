function muOnline(input) {
    let initialHealth = 100;
    let bitcoins = 0;
    let dungeonRooms = input.split("|");
    let isSuccesfull=true;
    let bestRoom=0;
    for (let line of dungeonRooms) {
        let [command, number] = line.split(" ");
        number = Number(number);
        bestRoom++;
        if (command == "potion") {
            if (number + initialHealth > 100) {
                number = 100 - initialHealth;
                initialHealth=100;

            } else {
                initialHealth += number;
            }
            console.log(`You healed for ${number} hp.`);
            console.log(`Current health: ${initialHealth} hp.`);
        } else if (command == "chest") {
            bitcoins+=number;
            console.log(`You found ${number} bitcoins.`);
        } else {
            initialHealth-=number;
            if(initialHealth>0){
                console.log(`You slayed ${command}.`);
            }else{
                isSuccesfull=false;
                console.log(`You died! Killed by ${command}.`);
                console.log(`Best room: ${bestRoom}`);
                break;
            }
        }
    }
    if(isSuccesfull){
        console.log(`You've made it!\nBitcoins: ${bitcoins}\nHealth: ${initialHealth}`);
    }
}
muOnline('rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000');
muOnline('cat 10|potion 30|orc 10|chest 10|snake 25|chest 110');