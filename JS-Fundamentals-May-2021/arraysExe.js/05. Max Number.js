function maxNumber(numbers) {
    let topIntegersArr = [];
    for (let index = 0; index < numbers.length; index++) {
        let element = numbers[index];
        let isInterger=true;
        for (let j = index + 1; j < numbers.length ; j++) {
           let nextElement = numbers[j];
            if (element <= nextElement) {
                isInterger=false;
                break;
            }
        }
        if(isInterger){
            topIntegersArr.push(element);
        }
    }
    console.log(topIntegersArr.join(" "));
}
maxNumber([1, 4, 3, 2])