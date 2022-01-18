function solve(input) {

    input.sort((a, b) => a - b);

    let result = [];

    if (input.length % 2 == 0) {

        result = input.slice(input.length / 2);

    } else {

        result = input.slice(Math.trunc(input.length / 2));

    }

    return (result);

}
solve([4, 7, 2, 5]);
solve([3, 19, 14, 7, 2, 19, 6]);