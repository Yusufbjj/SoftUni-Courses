function blackFlag(input) {
    input=input.map(Number);
    
    let days = input[0];
    let dailyPlunder = input[1];
    let expectedPlunder = input[2];
    let totalPlunderGained = 0;
    
    for (let index = 1; index <= days; index++) {
        totalPlunderGained+=dailyPlunder;
        if(index%3===0){
            totalPlunderGained+=0.5*dailyPlunder;
        }
        if(index%5===0){
            totalPlunderGained=0.70*totalPlunderGained;
        }

        
    }
    if(totalPlunderGained>=expectedPlunder){
        console.log(`Ahoy! ${totalPlunderGained.toFixed(2)} plunder gained.`);
    }else{
        let percentage = totalPlunderGained/expectedPlunder*100;
        console.log(`Collected only ${percentage.toFixed(2)}% of the plunder.`);
    }
}
blackFlag(["5","40","100"]);
blackFlag(["10","20","380"]);

