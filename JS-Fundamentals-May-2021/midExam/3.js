function problem3(input) {
    let chat = [];
    for (let line of input) {
        let [command,message1,message2] = line.split(" ");
        if(command=="end"){
            for (let command of chat) {
                console.log(`${command}`);
            }
            break;
        }
        if(command=="Chat"){
            chat.push(message1);
        }else if (command=="Delete"){
            if(chat.includes(message1)){
                let index = chat.indexOf(message1);
                chat.splice(index,1);
            }
        }else if (command=="Edit"){
            if(chat.includes(message1)){
                let index = chat.indexOf(message1);
                chat.splice(index,1,message2);
            }
        }else if (command=="Pin"){
            if(chat.includes(message1)){
                let index = chat.indexOf(message1);
                chat.splice(index,1);
                chat.push(message1);
            }
        }else if (command=="Spam"){
            let [command,...message] = line.split(" ");
            for (let word of message) {
                
                chat.push(word)
            }
        }
    }
}
problem3(["Chat Hello",
"Chat darling",
"Edit darling Darling",
"Spam how are you",
"Delete Darling",
"end"]);
problem3(["Chat John",
"Spam Let's go to the zoo",
"Edit zoo cinema",
"Chat tonight",
"Pin John",
"end"]);

