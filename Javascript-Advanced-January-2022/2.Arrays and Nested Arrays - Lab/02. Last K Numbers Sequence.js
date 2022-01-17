function solve(n, k) {

    let numbers = [1];

    while (numbers.length != n) {

        let sum = 0;

        let counter = k;

        for (let index = numbers.length - 1; index >= 0; index--) {

            counter--;

            sum += numbers[index];

            if (counter == 0) {
                break;
            }
        }
        numbers.push(sum)
    }

    return numbers;
    
}
solve(6, 3);
solve(8, 2);