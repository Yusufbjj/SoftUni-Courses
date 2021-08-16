function problem1(input) {
    let email = input.shift();
    while (input[0]!="Complete") {
        let line = input.shift();
        let [command,...others]=line.split(" ");
        if(command=="Make"){
            if(others[0]=="Upper"){
                email=email.toUpperCase();
            }else if(others[0]=="Lower"){  
                email=email.toLowerCase();
            }
            console.log(email);
        }else if(command=="GetDomain"){
            let count = Number(others[0]);
            let substr = email.substring(email.length-count,email.length);
            console.log(substr);
        }else if(command=="GetUsername"){
            let str = "";
            if(!email.includes("@")){
                console.log(`The email ${email} doesn't contain the @ symbol.`);
            }else{

                for (let ch of email) {
                    if(ch=="@"){
                        console.log(`${str}`);
                        break;
                    }
                    str+=ch;
                }
            }

        }else if (command=="Replace"){
            let char = others[0];
            let dash = "-";
            while(email.includes(char)){
                email=email.replace(char,dash)
            }
            console.log(email);

        }else if(command=="Encrypt"){
            let str ="";
            for (let ch of email) {
                let asciChar = ch.charCodeAt(0);
                str+=asciChar+" ";
            }
            console.log(str);
        }
    }
}


problem1(["Mike123@somemail.com",
"Make Upper",
"GetDomain 3",
"GetUsername",
"Encrypt",
"Complete"])
problem1(["AnotherMail.com",
"Make Lower",
"GetUsername",
"Replace a",
"Complete"])
