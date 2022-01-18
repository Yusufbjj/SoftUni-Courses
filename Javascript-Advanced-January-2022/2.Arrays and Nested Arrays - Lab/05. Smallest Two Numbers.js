function solve(input) {

    let sortedArr = input.sort((a, b) => a - b);

    let result = "";

    for (let index = 0; index < 2; index++) {

        result+=sortedArr[index] + " ";
        
    }
    
    console.log(result);
    
}
solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);