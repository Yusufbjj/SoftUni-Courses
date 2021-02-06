function demo(input) {
    let index = 0;
    let width = Number(input[index]);
    index++;
    let length = Number(input[index]);
    index++;
    let height = Number(input[index]);
    index++;

    let cubicM = width * length * height;
    let command = input[index];
    index++;
    
    while (command !== "Done") {
        let box = Number(command);
        cubicM -= box;
        if (cubicM < 0) {
            
            console.log(`No more free space! You need ${Math.abs(cubicM)} Cubic meters more.`);break;

        }
        command = input[index];
        index++;
        
    }
    if (cubicM>0) {
        console.log(`${cubicM} Cubic meters left.`);
    }
   
}
demo(["10","1","2","4","6","Done"])




