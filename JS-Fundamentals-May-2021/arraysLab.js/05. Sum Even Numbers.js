function sumEvenNum(arr){
    let sum =0;
    for (const num of arr) {
        if(num%2===0){
            sum+=Number(num);
        }
    }
    console.log(sum);
}
sumEvenNum(['1','2','3','4','5','6'])