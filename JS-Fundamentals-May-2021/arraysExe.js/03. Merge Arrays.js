function mergeArrays(arr1,arr2){
    let thirdArr = [];
    for (let index = 0; index < arr1.length; index++) {
        if(index%2===0){
            thirdArr.push(Number(arr1[index])+Number(arr2[index]));
        }else{
            thirdArr.push(arr1[index]+arr2[index]);
        }
        
    }
    console.log(thirdArr.join(" - "));
}
mergeArrays(['5', '15', '23', '56', '35'],
['17', '22', '87', '36', '11']
)