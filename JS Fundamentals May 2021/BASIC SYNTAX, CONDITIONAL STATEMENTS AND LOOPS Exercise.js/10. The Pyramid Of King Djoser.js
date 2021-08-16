function pyramid(base, increment) {
    let totalStones = 0;
    let totalMarble = 0;
    let totalLapiz = 0;
    let totalGold = 0;
    let count = 0;
    let height=0;
    while (base>2) {
        let perimeter = base*base;
        let currentBase=base-2;
        let eachStepStone = currentBase*currentBase;
        let eachStepMarble = perimeter-eachStepStone;
        count++;
        if(count%5===0){
          totalLapiz+=eachStepMarble;
        }else{
            totalMarble+=eachStepMarble;
        }
        totalStones+=eachStepStone;
   
        base -= 2;
    }
    count++;
    totalGold+=base*base*increment;
    height=Math.floor(count*increment);
    totalStones*=increment;
    totalMarble*=increment;
    totalLapiz*=increment;
    console.log(`Stone required: ${Math.ceil(totalStones)}`);
    console.log(`Marble required: ${Math.ceil(totalMarble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapiz)}`);
    console.log(`Gold required: ${Math.ceil(totalGold)}`);
    console.log(`Final pyramid height: ${height}`);

}

pyramid(11, 0.75);

