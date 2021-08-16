function oddAndEvenSum(num) {
    let numStr = num.toString();
    let oddSum = 0;
    let evenSum = 0;

    for (const n of numStr) {
        if (n % 2 === 0) {
            evenSum +=Number(n);
        }else{
            oddSum+=Number(n);
        }
    }
    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`
}
oddAndEvenSum(1000435);
oddAndEvenSum(3495892137259234);