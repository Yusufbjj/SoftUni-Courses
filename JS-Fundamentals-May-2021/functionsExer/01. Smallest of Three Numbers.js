function smallestNum(n1,n2,n3){
    let smallest = n1;
    for (const num of arguments) {
        if(num<smallest){
            smallest=num;
        }
    }
    console.log(smallest);
}
smallestNum(2,5,3)
smallestNum(600,342,123)
smallestNum(25,21,4)