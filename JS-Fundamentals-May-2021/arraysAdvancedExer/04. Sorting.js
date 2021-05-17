function sorting(array) {
    array.sort((a,b)=> a - b);
    
    let newArray = [];
    while(array.length>0){
        let currentBiggest = array.pop();
        let currentSmallest = array.shift();
        newArray.push(currentBiggest,currentSmallest)
    }
    console.log(newArray.join(" "));
}
sorting([1, 21, 3, 52, 69, 63, 31, 2, 18, 94]);