function demo(input){

    let radians = Number(input[0])
    let degrees = radians * 180 / Math.PI;
    console.log (degrees.toFixed(0));
}
demo(['3.1416'])