function login(input) {
    let username = input.shift();
    let password = username;
    for (let index = 0; index <4; index++) {
        
        let reversedStr = input[index].split("").reverse().join("");
        
        if (reversedStr != password) {
            if(index===3){
                console.log(`User ${username} blocked!`);break;
            }
            console.log(`Incorrect password. Try again.`);
        } else {
            console.log(`User ${username} logged in.`); break;
        }
        
    }
    
}
login(['Acer', 'login', 'go', 'let me in', 'recA']);
login(['momo', 'omom']);
login(['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']);