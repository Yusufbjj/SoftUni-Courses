function demo(input) {
    let ourNumber = Number(input[0]);
    let output = ""
    for (let i = 1; i < 9; i++) {
        for (let j = 1; j <= 9; j++) {
            for (let k = 1; k <= 9; k++) {
                for (let l = 1; l <= 9; l++) {


                    if (ourNumber % i === 0 &&
                        ourNumber % j === 0 &&
                        ourNumber % k === 0 &&
                        ourNumber % l === 0) {
                        output+=`${i}${j}${k}${l} `;
                    }
                }
            }
        }

    }
    console.log(output);
}
demo(["3"]);
