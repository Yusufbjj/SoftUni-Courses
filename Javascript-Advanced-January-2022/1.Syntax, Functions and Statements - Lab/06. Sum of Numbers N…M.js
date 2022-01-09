function solve(a, b) {
    a = Number(a);
    b = Number(b);

    let sum = 0;

    for (let index = a; index <= b; index++) {

        sum += index;

    }

    return sum;
}
solve('1', '5');
solve('-8', '20');