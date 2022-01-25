function solve(arr, numOfRotations) {
    for (let index = 0; index < numOfRotations; index++) {
       
        let removedNum = arr.pop();

        arr.unshift(removedNum);
        
    }

    console.log(arr.join(" "));
}
solve(['1',
    '2',
    '3',
    '4'],
    2);