function replaceRepeatingChars(str) {
    let strings= [];

    for (let index = 0; index < str.length; index++) {
        let current  = str[index];
        let next = str[index+1];
        if(current!=next){
            strings.push(current);
        }
        
    }
    console.log(strings.join(""));
}
replaceRepeatingChars('aaaaabbbbbcdddeeeedssaa');
replaceRepeatingChars('qqqwerqwecccwd');