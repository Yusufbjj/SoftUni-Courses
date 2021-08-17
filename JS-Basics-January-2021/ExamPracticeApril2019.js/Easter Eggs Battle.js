function solve(input) {
    let playerOneEggs = Number(input[0]);
    let playerTwoEggs = Number(input[1]);



    for (let i = 2; i <= input.length - 1; i++) {

        let command = input[i];

        if (command === "one") {
            playerTwoEggs--
        } else if (command === "two") {
            playerOneEggs--
        }

        if (playerOneEggs < 1) {
            console.log(`Player one is out of eggs. Player two has ${playerTwoEggs} eggs left.`); break;
        }
        if (playerTwoEggs < 1) {
            console.log(`Player two is out of eggs. Player one has ${playerOneEggs} eggs left.`); break;
        }
        if (command === "End of battle") {
            console.log(`Player one has ${playerOneEggs} eggs left.`);
            console.log(`Player two has ${playerTwoEggs} eggs left.`); break;

        }

    }

}
solve(["6",
"3",
"one",
"two",
"two",
"one",
"one"]);
