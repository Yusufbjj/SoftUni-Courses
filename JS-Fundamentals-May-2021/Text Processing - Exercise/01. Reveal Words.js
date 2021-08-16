function revealWords(words, string) {
    string = string.split(" ");
    words = words.split(", ");

    for (let word of string) {
        for (let str of words) {
            if (word == "*".repeat(word.length) && word.el) {


                let index = string.indexOf(word);
                string[index] = str;

            }

        }
    }
    console.log(string.join(" "));
}
revealWords('great',
    'softuni is ***** place for learning new programming languages'
)
revealWords('great, learning',
    'softuni is ***** place for ******** new programming languages'
)