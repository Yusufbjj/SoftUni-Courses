function solve(input) {

    let sumRow = input[0].reduce(function (a, b) {
        return a + b;
    }, 0);

    let result = true;

    for (let index = 1; index < input.length; index++) {

        let row = input[index];

        let currentRowSum = row.reduce(function (a, b) {
            return a + b;
        }, 0);

        if (currentRowSum != sumRow) {
            result = false;
            break;
        }
    }

    for (let index = 0; index < input.length; index++) {

        let currentColSum = 0;

        for (let j = 0; j < input.length; j++) {

            currentColSum += input[j][index];

        }
        if (sumRow != currentColSum) {
            result = false;
            break;
        }
    }

    console.log(result);

}
solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);

solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
);

solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
);