function solve(input) {

    input.sort((a, b) => a.localeCompare(b));

    for (let index = 0; index < input.length; index++) {

        console.log(`${index + 1}.${input[index]}`);

    }
}
solve(["John", "Bob", "Christina", "Ema"]);