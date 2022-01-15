function solve(num) {
    let numAsString = String(num);

    let result = true;

    let firstNum = numAsString[0];

    let nextNum;

    let sum = Number(firstNum);

    for (let index = 1; index < numAsString.length; index++) {

        nextNum = numAsString[index]

        sum += Number(nextNum);

        if (firstNum != nextNum) {
            result = false;
        }
    }

    console.log(result);
    console.log(sum);
}
solve(2222222);
solve(1234);