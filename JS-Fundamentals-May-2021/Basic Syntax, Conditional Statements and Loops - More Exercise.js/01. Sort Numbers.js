function sortNumbers(a,b,c){
    let sortedNumbers = [];
    sortedNumbers.push(a,b,c);
    sortedNumbers.sort((a,b,c)=>b-a)
    for (let num of sortedNumbers) {
        console.log(num);  
    }
    

}
sortNumbers(2,1,3);