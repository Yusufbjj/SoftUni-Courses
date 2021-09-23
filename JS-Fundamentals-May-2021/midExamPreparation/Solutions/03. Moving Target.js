function movingTarget(input) {
    let targetSequence = input.shift().split(" ");
    for (let line of input) {
        let [command, index, power] = line.split(" ");

        if (command === "Shoot") {
            if (index < targetSequence.length) {
                targetSequence[index] -= power;
            }
            if (targetSequence[index] <= 0) {
                targetSequence.splice(index, 1);
            }
        } else if (command === "Add") {
            
            if (index >= 0 && index < targetSequence.length) {
                targetSequence.splice(index, 0, power)
            } else {
                console.log(`Invalid placement!`);
            }
        } else if (command === "Strike") {

            if (Number(index) - Number(power) >= 0 && Number(index) + Number(power) < targetSequence.length) {
                let start = Number(index) - Number(power);
                let end = 1 + Number(power) * 2;
                targetSequence.splice(start, end);
            } else {
                console.log(`Strike missed!`);
            }

        } else if(command==="End"){
            console.log(`${targetSequence.join("|")}`);
        }
    }
}

movingTarget(["1 2 3 4 5",
    "Strike 0 3",
    "End"])

movingTarget(["52 74 23 44 96 110",
    "Shoot 5 10",
    "Shoot 1 80",
    "Strike 2 1",
    "Add 22 3",
    "End"])

