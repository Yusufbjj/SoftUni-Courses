function solve(arr) {

    let result = "";

    for (let index = 0; index < arr.length; index++) {
        if (index % 2 == 0) {

            result += arr[index] + " ";

        }

    }
    
    console.log(result);
}
solve(['20', '30', '40', '50', '60']);