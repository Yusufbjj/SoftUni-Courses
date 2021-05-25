function magicSum(array,num){
    for (let index = 0; index < array.length; index++) {
          
        for (let j = index+1; j < array.length; j++) {
            
            if(array[index]+array[j]===num){
                console.log(`${array[index]} ${array[j]}`);
            }     
        }  
    }
}
magicSum([1, 2, 3, 4, 5, 6],
    6
    
    
    );