function mathPower(n,power){
    let result=1;
    for (let index = 0; index < power; index++) {
       result*=n;
        
    }
    return result;
}
mathPower(2,8);