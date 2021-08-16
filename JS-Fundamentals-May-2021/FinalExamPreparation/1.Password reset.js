function paswordReset(input) {
    let operations = {
        TakeOdd,
        Cut,
        Substitute
    };
    //store initial password
    let rawPassword = input.shift();

    //iterate input command
    while (input[0] != "Done") {
        let tokens = input.shift().split(" ");
        let command = operations[tokens[0]];
        rawPassword = command(rawPassword, tokens[1], tokens[2]);

        // --execute operation with given parameteres

    }
    // print result
    console.log(`Your password is: ${rawPassword}`);


    function TakeOdd(text) {
        let result = "";
        for (let index = 0; index < text.length; index++) {
            if (index % 2 != 0) {
                result += text[index];
            }

        }
        console.log(result);
        return result;
    }

    function Cut(text, start, count) {
        start = Number(start);
        count = Number(count);
        let word = text.substring(start, start + count);

        let result = text.replace(word, "");

        console.log(result);
        return result;
    }

    function Substitute(text, match, word) {
        let result = text.split(match).join(word);
        if (result == text) {
            console.log(`Nothing to replace!`);
        } else {

            console.log(result);
        }
        return result;
    }
}
paswordReset(["Siiceercaroetavm!:?:ahsott.:i:nstupmomceqr", 
"TakeOdd",
"Cut 15 3",
"Substitute :: -",
"Substitute | ^",
"Done"])

