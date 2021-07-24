function charInRange(a,b){
    let firstNum = a.charCodeAt();
    let secondNum = b.charCodeAt();

    let result = "";
    if(firstNum>secondNum){
        for (let index = secondNum+1; index < firstNum; index++){
            result+=String.fromCharCode(index)+ " ";
         
         }
         console.log(result);
    }else{
        for (let index = firstNum+1; index < secondNum; index++){
            result+=String.fromCharCode(index)+ " ";
         
         }
         console.log(result); 
    }
}
charInRange("a","d")
charInRange("#",":")
charInRange("C","#")
