function arrayRotation(arr,n){
    for (let index = 0; index < n; index++) {
        let element = arr.shift();
        arr.push(element);
        
        
    }
    console.log(arr.join(" "));
}
arrayRotation([51, 47, 32, 61, 21], 2)