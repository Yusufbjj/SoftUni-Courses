function demo(input) {
    let cakes = Number(input[0]);
    index = 1;
    let winBakerName = "";
    let winBakerPoints = 0;

    for (let i = 1; i <= cakes; i++) {
        let chefName = input[index];
        index++;
        let tempPoints = 0;
        let command = input[index];
        index++;

        while (command !== "Stop") {
            let points = Number(command);
            tempPoints += points;
            command = input[index];
            index++
        }
        console.log(`${chefName} has ${tempPoints} points.`);
        if (tempPoints > winBakerPoints) {
            winBakerName = chefName;
            winBakerPoints = tempPoints;
            console.log(`${winBakerName} is the new number 1!`);

        }
    }
    console.log(`${winBakerName} won competition with ${winBakerPoints} points!`);


}
demo(["3",
    "Chef Manchev",
    "10",
    "10",
    "10",
    "10",
    "Stop",
    "Natalie",
    "8",
    "2",
    "9",
    "Stop",
    "George",
    "9",
    "2",
    "4",
    "2",
    "Stop"]);


