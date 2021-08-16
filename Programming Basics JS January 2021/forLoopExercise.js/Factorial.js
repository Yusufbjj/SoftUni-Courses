function solve(input) {

    let number = Number(input[0]);

    let factorial = 1;

    for (i = 1; i <= number; i++) {
        factorial *= i;

    }
    console.log(factorial);


}
solve(["4"])
