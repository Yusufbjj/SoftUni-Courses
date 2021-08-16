function solve(input) {
    let message = input.shift();
    let inputLine = input.shift();
 
    while (inputLine !== 'Reveal') {
        let [command, token, replacement] = inputLine.split(':|:');
 
        if (command === 'InsertSpace') {
            let arr = message.split('');
            let index = Number(token);
            let space = ' ';
            arr.splice(index, 0, space);
            message = arr.join('');
            console.log(message);
        } else if (command === 'Reverse') {
 
            if (message.indexOf(token) !== -1) {
                let array = message.split(token);
                let str = token.split('').reverse().join('');
                array.push(str);
                message = array.join('');
                console.log(message);
            } else {
                console.log("error");
            }
 
        } else if (command === 'ChangeAll') {
            while (message.includes(token)) {
                let replacedText = message.replace(token, replacement);
                message = replacedText;
            }
            console.log(message);
        }
        inputLine = input.shift();
    }
    console.log(`You have a new text message: ${message}`);
}
solve([
    'Hiware?uiy',
    'ChangeAll:|:i:|:o',
    'Reverse:|:?uoy',
    'Reverse:|:jd',
    'InsertSpace:|:3',
    'InsertSpace:|:7',
    'Reveal'
]
)