function solve(input) {
    let numbersCount = Number(input[0]);
    let minNumber = Number.MAX_SAFE_INTEGER;

    for (let i = 1; i <= numbersCount; i++) {
        let currentNumber = Number(input[i]);

        if (currentNumber < minNumber) {

            minNumber = currentNumber;
        }



    }
    console.log(minNumber);


}
solve(["2",
    "100",
    "99"]);



