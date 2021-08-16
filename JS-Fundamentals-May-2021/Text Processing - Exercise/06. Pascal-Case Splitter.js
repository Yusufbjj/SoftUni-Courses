function pascalCaseSplitter(text) {
    // let result = [];
    // let currentWord ="";
    // let lower = text.toLocaleLowerCase();
    
    // for (let index = 0; index < text.length; index++) {
    //     if(text[index]!=lower[index]){
    //         if(currentWord.length>0){
    //             result.push(currentWord);
    //         }
    //         currentWord=text[index]
    //     }else{

    //         currentWord+=text[index];
    //     }
        
    // }
    // if(currentWord.length>0){
    //     result.push(currentWord);
    // }
    // console.log(result.join(", "));
    let result = text[0];
    let lower = text.toLocaleLowerCase();
    for (let index = 1; index < text.length; index++) {
        if(text[index]!=lower[index]){
            result+= ", ";

        }
        result+=text[index];
    }
    console.log(result);

}
pascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan');
pascalCaseSplitter('HoldTheDoor');
pascalCaseSplitter('ThisIsSoAnnoyingToDo');