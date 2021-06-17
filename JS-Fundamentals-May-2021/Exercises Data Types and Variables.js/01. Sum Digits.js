function solve(num){
    let numberAsString = num.toString();
    let sum= 0;
    for (let a of numberAsString) {
        sum+=Number(a);
        
    }
    console.log(sum);
}
solve(245678);