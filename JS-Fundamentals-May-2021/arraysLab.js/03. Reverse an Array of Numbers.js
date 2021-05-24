function reverseArray(n, input) {
    let newArr = [];
    for (let index = 0; index < n; index++) {
        newArr.push(input[index]);
        
    }
    console.log(newArr.reverse().join(" "));
}
reverseArray(3, [10, 20, 30, 40, 50])