function demo(input) {
    let x = Number(input[0]);
    let y = Number(input[1]);
    let magicNumber = Number(input[2]);
    let isFound = false;
    let counter = 0;


    for (let i = x; i <= y; i++) {
        for (let z = x; z <= y; z++) {
            counter++;
            if (i + z === magicNumber) {
                console.log(`Combination N:${counter} (${i} + ${z} = ${magicNumber})`);
                isFound = true;
                break;
            }
        }
        if(isFound){
            break;
        }
    }
    if(!isFound){
        console.log(`${counter} combinations - neither equals ${magicNumber}`);
    }


}
demo(["88",
"888",
"1000"])












