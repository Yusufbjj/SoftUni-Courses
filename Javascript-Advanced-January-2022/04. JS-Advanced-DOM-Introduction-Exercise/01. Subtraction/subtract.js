function subtract() {
    let firstNum = document.getElementById('firstNumber').value;

    let firstNumAsNumber = Number(firstNum);

    let secondNum = document.getElementById('secondNumber').value;

    let secondNumAsNumber = Number(secondNum);

    let result = firstNumAsNumber - secondNumAsNumber;

    let resuleElement = document.getElementById('result');

    resuleElement.textContent = result;

}