function secretChat(input) {
    let message = input.shift();

    while (input[0] != "Reveal") {
        let operation = input.shift();
        let [command, ...others] = operation.split(":|:");
        if (command == "InsertSpace") {
            let index = Number(others[0]);
            let space = " ";
            let left = message.substring(0, index);
            let right = message.substring(index);
            message = left + space + right;
            console.log(message);
        } else if (command == "Reverse") {
            let substr = others[0];

            let reversedSubstr = substr.split("").reverse().join("");

            if (message.includes(substr)) {
                let firstIndex = message.indexOf(substr[0]);
                let endOfString = firstIndex + substr.length;
                let firstPart = message.substring(0, firstIndex);
                let secondPart = message.substring(endOfString);
                message = firstPart + secondPart + reversedSubstr;
                console.log(message);
            } else {
                console.log(`error`);
            }

        } else if (command == "ChangeAll") {
            let substr = others[0];
            let replacement = others[1];
            while (message.includes(substr)) {

                message = message.replace(substr, replacement);
            }
            console.log(message);
        }
    }
    console.log(`You have a new text message: ${message}`);
}
// secretChat([
//     'heVVodar!gniV',
//     'ChangeAll:|:V:|:l',
//     'Reverse:|:!gnil',
//     'InsertSpace:|:5',
//     'Reveal']);
secretChat([
    'Hiware?uiy',
    'ChangeAll:|:i:|:o',
    'Reverse:|:?uoy',
    'Reverse:|:jd',
    'InsertSpace:|:3',
    'InsertSpace:|:7',
    'Reveal'
]
)