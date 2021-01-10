function demo(input){

    let tankLength = Number(input[0]);
    let tankWidth = Number(input[1]);
    let tankHeigth = Number(input[2]);
    let percentageUsed = Number(input[3]);
    let tankVolume= tankLength * tankWidth * tankHeigth ; 
    let tankVolumeLitres = tankVolume * 0.001;
    let percentageConverted = percentageUsed * 0.01;
    let litresNeeded = tankVolumeLitres * (1-percentageConverted);

    console.log(litresNeeded)


}
demo (['85' ,'75','47','17'])