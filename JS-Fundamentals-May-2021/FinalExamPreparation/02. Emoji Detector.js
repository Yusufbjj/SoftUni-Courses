function emojiDetector(input) {
    //patterns 
    let numbersPattern = /[0-9]/g;
    let numbersMatch = input[0].match(numbersPattern).map(Number);
    let emojiPattern = (/(::|\*\*)([A-Z][a-z]{2,})(\1)/g);
    
    let threshhold = 1;

    //find threshhold 
    for (let num of numbersMatch) {
        threshhold *= num;
    }
    console.log(`Cool threshold: ${threshhold}`);
    let emojiMatch = input[0].match(emojiPattern);
    
    //emojis
    console.log(`${emojiMatch.length} emojis found in the text. The cool ones are:`);
    // coolness 
    let coolones=[];
    for (let ele of emojiMatch) {
        let namePattern = /[A-Za-z]+/g;
       let name = ele.match(namePattern).join();
       let coolness=0;
       for (let letter of name) {
           let asciLetter= letter.charCodeAt(0);
           coolness+=asciLetter;
       }
       
       if(coolness>threshhold){
        coolones.push(ele);
       }
    }
    if(coolones.length>=1){
        for (let cool of coolones) {
            console.log(cool);
        }
    }

}
emojiDetector(["In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 **Tigers**, 1 ::Elephant:, 12 **Monk3ys**, a **Gorilla::, 5 ::fox:es: and 21 different types of :Snak::Es::. ::Mooning:: **Shy**"]);
emojiDetector(["It is a long established fact that 1 a reader will be distracted by 9 the readable content of a page when looking at its layout. The point of using ::LoremIpsum:: is that it has a more-or-less normal 3 distribution of 8 letters, as opposed to using 'Content here, content 99 here', making it look like readable **English**."])
emojiDetector(["asdsadas"])