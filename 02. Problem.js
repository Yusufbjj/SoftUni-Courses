function problem2(input) {
    let pattern = /^(\$|%)([A-Z][a-z]{2,})\1\:\s(\[\d+\])\|\[\d+\]\|\[\d+\]\|$/g;
    let numbersPattern = /\d+/g;
    let n = Number(input.shift());
    for (let index = 0; index < n; index++) {
        let line =input.shift();
        let [tag,...other] = line.split(" ");
        tag=tag.substring(1,tag.length-2)
        let match =line.match(pattern);
        if(match!=null){
            let numMatches = match[0].match(numbersPattern);
            let str ="";
            for (let num of numMatches) {
                let asciSymbol = String.fromCharCode(num)
                str+=asciSymbol;
            }
            console.log(`${tag}: ${str}`);
        }else{
            console.log(`Valid message not found!`);
        }
        
    }
}
problem2(["4",
"$Request$: [73]|[115]|[105]|",
"%Taggy$: [73]|[73]|[73]|",
"%Taggy%: [118]|[97]|[108]|",
"$Request$: [73]|[115]|[105]|[32]|[75]|"]);

problem2(["3",
"This shouldnt be valid%Taggy%: [118]|[97]|[108]|",
"$tAGged$: [97][97][97]|",
"$Request$: [73]|[115]|[105]|true"]);