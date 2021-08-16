function demo(input) {
    let index = 0;
    let command = input[index];
    index++;
    let maxNum = Number.MIN_SAFE_INTEGER;

    while (command != "Stop") {
        let num = Number(command);
        if (num > maxNum) {
            maxNum = num;

        }
        command = input[index];
        index++;

    }
    console.log(maxNum);

}
demo(["100",
    "99",
    "80",
    "70",
    "Stop"]);




