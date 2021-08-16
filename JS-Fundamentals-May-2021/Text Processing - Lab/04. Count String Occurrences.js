function countStrOccurences(text, word) {
    let words = text.split(" ");
    let count =0;
    for (let str of words) {
        if(str==word){
            count++;

        }
    }
    console.log(count);
}
countStrOccurences("This is a word and it also is a sentence",
    "is")