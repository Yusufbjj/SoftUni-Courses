function solve(input) {

    let biggestNum = Number.NEGATIVE_INFINITY;

    for (let index = 0; index < input.length; index++) {

        let arr = input[index];

        for (let j = 0; j < arr.length; j++) {

            if (biggestNum < Number(arr[j])) {

                biggestNum = Number(arr[j]);

            }
        }
    }
    //console.log(biggestNum);
    return (biggestNum);
}

solve([[20, 50, 10],
[8, 33, 145]]);

solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]);