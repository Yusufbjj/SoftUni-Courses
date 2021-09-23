function counterStrike(input) {
    let initialEnergy = input.shift();
    initialEnergy = Number(initialEnergy);

    let wonBattles = 0;
    let isSuccesfull = false;

    for (let energy of input) {
        if (energy === "End of battle") {
            console.log(`Won battles: ${wonBattles}. Energy left: ${initialEnergy}`);
            break;
        }
        if (initialEnergy < energy) {
            console.log(`Not enough energy! Game ends with ${wonBattles} won battles and ${initialEnergy} energy`);
            break;
        }
        initialEnergy -= energy;
        wonBattles++;
        if(wonBattles%3===0){
            initialEnergy+=wonBattles;
        }
    }

}
counterStrike((["100",
    "10",
    "10",
    "10",
    "1",
    "2",
    "3",
    "73",
    "10"])
)
counterStrike((["200",
    "54",
    "14",
    "28",
    "13",
    "End of battle"])
)