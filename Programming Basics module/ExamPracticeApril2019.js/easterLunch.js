function demo(input){
    let cake = Number(input[0]);
    let eggsBoxes = Number(input[1]);
    let biscuits = Number(input[2]);
    let cakesPrice = cake * 3.20;
    let eggsBoxesPrice = eggsBoxes*4.35;
    let biscuitsPrice = biscuits*5.40;
    let eggsPaint = eggsBoxes*12*0.15;
    let total = cakesPrice+eggsBoxesPrice+biscuitsPrice+eggsPaint;

    console.log(total.toFixed(2));







}

demo(["4","4","3"]);
