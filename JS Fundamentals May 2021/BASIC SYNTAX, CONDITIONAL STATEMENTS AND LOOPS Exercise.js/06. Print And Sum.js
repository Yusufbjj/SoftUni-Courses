function printSum(start,end){
    let line = ""
    let sum = 0;
    for (let index = start; index <=end; index++) {
       line+=index+" ";
       sum+=index;
        
    }

    console.log(line);
    console.log(`Sum: ${sum}`);
}
printSum(5,10)
printSum(0,26)
printSum(50,60)