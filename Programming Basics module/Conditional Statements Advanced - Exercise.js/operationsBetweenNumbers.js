function test(input) {
    let firstNumber = Number(input[0]);
    let secondNumber = Number(input[1]);
    let operator = input[2];

    switch (operator) {
        case "+":
            if ((firstNumber + secondNumber) % 2 === 0) {
                console.log(`${firstNumber} + ${secondNumber} = ${firstNumber + secondNumber} - even`);
            } else {
                console.log(`${firstNumber} + ${secondNumber} = ${firstNumber + secondNumber} - odd`);
            } break;
        case "-":
            if ((firstNumber - secondNumber) % 2 === 0) {
                console.log(`${firstNumber} - ${secondNumber} = ${firstNumber - secondNumber} - even`);
            } else {
                console.log(`${firstNumber} - ${secondNumber} = ${firstNumber - secondNumber} - odd`);
            } break;
        case "*":
            if ((firstNumber * secondNumber) % 2 === 0) {
                console.log(`${firstNumber} * ${secondNumber} = ${firstNumber * secondNumber} - even`);
            } else {
                console.log(`${firstNumber} * ${secondNumber} = ${firstNumber * secondNumber} - odd`);
            } break;
        case "/":
            if (secondNumber === 0) {
                console.log(`Cannot divide ${firstNumber} by zero`);
            } else {
                console.log(`${firstNumber} / ${secondNumber} = ${(firstNumber / secondNumber).toFixed(2)} `);

            } break;
        case "%":
            if (secondNumber === 0) {
                console.log(`Cannot divide ${firstNumber} by zero`);
            } else {
                console.log(`${firstNumber} % ${secondNumber} = ${firstNumber % secondNumber} `);

            } break;


    }


}
test(["10",
    "3",
    "%"]);




