function memoryGame(input) {
    let sequence = input.shift().split(" ");
    let turns = 0;
    for (let command of input) {
        if(sequence.length==0){
            console.log(`You have won in ${turns} turns!`);
            break;
        }else if (command == "end" && sequence.length>0) {
            console.log(`Sorry you lose :(\n${sequence.join(" ")}`);
            break;
        }
        let [indexOne, indexTwo] = command.split(" ").map(Number);
        turns++;
        if (sequence[indexOne] == sequence[indexTwo]) {
            let element = sequence[indexOne];
            sequence = sequence.filter((x) => x != element)

            console.log(`Congrats! You have found matching elements - ${element}!`);

        } else if (indexOne == indexTwo || indexOne < 0 || indexTwo < 0 || indexOne >= sequence.length  || indexTwo >= sequence.length ) {
            let middle = sequence.length / 2;
            sequence.splice(middle, 0, `-${turns}a`, `-${turns}a`);
            console.log(`Invalid input! Adding additional elements to the board`);
        } else if (sequence[indexOne] != sequence[indexTwo]) {
            console.log(`Try again!`);
        } 
    }
}
memoryGame([
    "1 1 2 2 3 3 4 4 5 5", "1 0", "-1 0", "1 0", "1 0", "1 0", "end"
]);
memoryGame(["a 2 4 a 2 4",
    "0 3",
    "0 2",
    "0 1",
    "0 1",
    "end"])