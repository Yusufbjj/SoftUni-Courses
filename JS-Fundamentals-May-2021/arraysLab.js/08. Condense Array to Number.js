function condenseArrayToNumber(arr) {
    let condensedArr = [];
    while(arr.length>1){
        for (let index = 0; index < arr.length-1; index++) {
            let firstEle = arr[index];
            let secondEle= arr[index+1];
            let currentSum=firstEle+secondEle;
            condensedArr.push(currentSum);
        }
        arr=condensedArr;
        condensedArr = [];
        
    }
    console.log(arr[0]);
  
}
condenseArrayToNumber([2, 10, 3]);
condenseArrayToNumber([5, 0, 4, 1, 2]);
condenseArrayToNumber([1]);