function distinctArray (numbers) {
    let dist = [];

    for (const num of numbers) {
        if(!dist.includes(num)){
            dist.push(num);
        }
    }
    return dist.join(" ");
}
let result = distinctArray([1, 2, 3, 4]);
console.log(result);
distinctArray([7, 8, 9, 7, 2, 3, 4, 1, 2]);
distinctArray([1, 2, 3, 4]);