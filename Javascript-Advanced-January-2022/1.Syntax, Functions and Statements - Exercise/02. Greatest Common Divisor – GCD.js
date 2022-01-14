function solve(a, b) {
    let greatestDevisor;

    for (let index = 1; index < 9; index++) {

        if (a % index == 0 && b % index == 0) {

            greatestDevisor = index;

        }

    }

    console.log(greatestDevisor);
}
solve(15, 5);
solve(2154, 458);