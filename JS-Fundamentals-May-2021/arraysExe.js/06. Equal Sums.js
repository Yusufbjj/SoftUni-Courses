function equalSums(numbers) {
    let isExcisting = false;
    for (let index = 0; index < numbers.length; index++) {
        let leftSum = 0;
        let rightSum = 0;
        for (let j = 0; j < index; j++) {
            leftSum += numbers[j];
        }
        for (let z = index + 1; z < numbers.length; z++) {
            rightSum += numbers[z];
        }
        if (leftSum === rightSum) {
            console.log(index);
            isExcisting = true;
        }
    }
    if (!isExcisting) {
        console.log("no");
    }

}
equalSums([1,2,3])