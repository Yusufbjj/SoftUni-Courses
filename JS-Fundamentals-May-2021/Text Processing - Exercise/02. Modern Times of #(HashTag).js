function modernTimes(string) {
    string = string.split(" ");
    
    for (let word of string) {
        let symbol = "#";
        let firstChar = word[0];
        if (firstChar == symbol && word.length > 1) {

            let isSpecial = true;
            let specialWord = word.slice(1);
            for (let character of specialWord) {
                let asciChar = character.charCodeAt(0);
                if (asciChar <65 || asciChar > 122 || asciChar >=91 && asciChar<=96) {
                    isSpecial=false;
                    break;
                }

            }
            
            if(isSpecial){

                console.log(specialWord);
            }
        }
    }
}
modernTimes('Nowadays everyone uses # to tag a #special word in #socialMedia')