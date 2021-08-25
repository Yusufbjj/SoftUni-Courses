function strSubstring(word, text) {
    text = text.split(" ");

    for (let str of text) {
        let areEqual = str.toUpperCase() == word.toUpperCase();

        if (areEqual) {
            return console.log(word);

        }
    }


    return console.log(`${word} not found!`);

}
strSubstring('python',
    'JavaScript is the best programming language'
)