function solve(input) {

    let result = [];

    for (let index = 1; index < input.length; index += 2) {

        result.push(input[index] * 2);

    }

    result.reverse();

    return(result);
}

solve([10, 15, 20, 25]);

solve([3, 0, 10, 4, 7, 3]);