function maxSequenceOfElements(array) {
    let longestSequence = []
    for (let index = 0; index < array.length; index++) {
        let element = array[index];
        let currentSequence = [element];
        for (let j = index + 1; j < array.length; j++) {
            let nextEle = array[j]
            if(element===nextEle){
                currentSequence.push(nextEle);;
            }else{
                break;
            }
        }
        if(longestSequence.length<currentSequence.length){
            longestSequence=currentSequence;
        }
    }
    console.log(longestSequence.join(" "));
}
maxSequenceOfElements([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);