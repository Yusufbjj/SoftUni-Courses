function imitationGame(input) {
    let message = input.shift();

    while(input[0]!="Decode"){
        let str= input.shift();
        let [command,...tokens] = str.split("|");
        
        if(command=="Move"){
            let index = Number(tokens[0]);
            let left = message.substring(0,index);
            let right = message.substring(index);
            message=right+left;
            
        }else if(command=="Insert"){
            let index = tokens[0];
            let value = tokens[1];
            let left = message.substring(0,index);
            let right = message.substring(index);
            message=left+value+right;
            
        }else if (command=="ChangeAll"){
            let substr = tokens[0];
            let replacement = tokens[1];
           message=message.split(substr).join(replacement);
        
        }
    }
    console.log(`The decrypted message is: ${message}`);
   
}
imitationGame([
    'zzHe',
    'ChangeAll|z|l',
    'Insert|2|o',
    'Move|3',
    'Decode'
  ]);