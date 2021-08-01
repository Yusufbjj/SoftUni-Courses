function activationKeys(input) {
    let key = input.shift();

    while(input[0]!="Generate"){
        let line = input.shift();

        let[command,...others] = line.split(">>>");
        if(command=="Contains"){
            let substr = others[0];
            if(key.includes(substr)){
                console.log(`${key} contains ${substr}`);
            }else{
                console.log(`Substring not found!`);
            }
        }else if (command=="Flip"){
            let [upOrLow,startIndex,endIndex] = others;
            startIndex=Number(startIndex);
            endIndex=Number(endIndex);
            let start = key.substring(0,startIndex);
            let str= key.substring(startIndex,endIndex);
            let end = key.substring(endIndex,key.length);
            if(upOrLow=="Upper"){
                str = str.toUpperCase();
                
            }else{
                str=str.toLowerCase();
            }
            key = start+str+end;
            console.log(key);
        }else if (command=="Slice"){
            let [startIndex,endIndex] = others;
            startIndex=Number(startIndex);
            endIndex=Number(endIndex);
            let start = key.substring(0,startIndex);
            
            let str = key.substring(startIndex,endIndex);
           
            let end = key.substring(endIndex,key.length);
            key = start+end;
            console.log(key);
        }
    }
    console.log(`Your activation key is: ${key}`);
}
activationKeys(["abcdefghijklmnopqrstuvwxyz",
"Slice>>>2>>>6",
"Flip>>>Upper>>>3>>>14",
"Flip>>>Lower>>>5>>>7",
"Contains>>>def",
"Contains>>>deF",
"Generate"]);
