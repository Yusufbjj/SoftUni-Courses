function palindrome(array){
    for (let index = 0; index < array.length; index++) {
        let num = array[index]
        let reversedNum = array[index].toString().split("").reverse().join("");
        if(num==reversedNum){
            console.log("true");
            
        }else{
            console.log("false");
            
        }
    }
}
palindrome([123,323,421,121]);
palindrome([32,2,232,1010]);