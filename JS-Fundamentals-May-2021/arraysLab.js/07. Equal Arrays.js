function equalArrays(arr1,arr2){
    let sum =0;
    let areEqual = true;  
    for (let index = 0; index < arr1.length; index++) {
        if(arr1[index]==arr2[index]){
            sum+=Number(arr1[index]);
            
            
        }else{
            console.log(`Arrays are not identical. Found difference at ${index} index`);
            areEqual=false;break;
        }

    }
    if(areEqual){
        console.log(`Arrays are identical. Sum: ${sum}`);
    }
    
}
equalArrays(['1','2','3','4','5'], ['1','2','4','4','5']);