function solve(input) {

    let biggestNum = Number.NEGATIVE_INFINITY;

    let output = [];

    let result = input.reduce((a, x) => {

        if (x >= biggestNum) {
            biggestNum = x;
            output.push(x);
        }

    }, 0);

    //console.log(output);

    return (output);
}
solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);

solve([1,
    2,
    3,
    4]
);

solve([20,
    3,
    2,
    15,
    6,
    1]
);