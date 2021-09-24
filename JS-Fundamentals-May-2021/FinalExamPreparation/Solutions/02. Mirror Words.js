function mirrorWords(input) {
    let pattern = /(#|@)([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1/g
    let text = input[0];
    let matches = text.match(pattern);
    let mirrors = [];

    if (matches != null) {
        for (let str of matches) {
            let char = str[0];

            let [...words] = str.split(char);
            let word1 = words[1];
            let word2 = words[words.length - 2];
            let reversedWord2 = word2.split("").reverse().join("");
            if (word1 == reversedWord2) {
                mirrors.push(`${word1} <=> ${word2}`)
            }
        }


        console.log(`${matches.length} word pairs found!`);
        if (mirrors.length > 0) {
            console.log(`The mirror words are:`);
            console.log(mirrors.join(", "));
        } else {
            console.log(`No mirror words!`);
        }
    } else {
        console.log(`No word pairs found!`);
        console.log(`No mirror words!`);
    }
}
mirrorWords([
    '@mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r'
]
)
mirrorWords(['#po0l##l0op# @bAc##cAB@ @LM@ML@ #xxxXxx##xxxXxx# @aba@@ababa@'])
mirrorWords(["#lol#lol# @#God@@doG@# #abC@@Cba# @Xyu@#uyX#"])