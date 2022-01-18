function solve(input) {

    let newArr = [];

    for (let n of input) {

        if (n >= 0) {

            newArr.push(n);

        } else {

            newArr.unshift(n);

        }

    }

    newArr.forEach(element => {
        console.log(element);
    });
}
solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);