function addAndSubstract(numbers) {
    let sumNumbers = 0;
    let sumNewArr = 0;
    for (const num of numbers) {
        sumNumbers += num;
    }
    for (let index = 0; index < numbers.length; index++) {
        if (numbers[index] % 2 === 0) {
            numbers[index] = numbers[index] + index;
        } else {
            numbers[index] = numbers[index] - index;
        }
        sumNewArr+=numbers[index];

    }
    console.log(`[ ${numbers.join(", ")} ]`);
    console.log(sumNumbers);
    console.log(sumNewArr);
}
addAndSubstract([5, 15, 23, 56, 35])