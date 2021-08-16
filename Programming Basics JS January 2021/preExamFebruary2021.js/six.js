function solve(input) {
    index=0;
    let locations = Number(input[index]);
    index++;

    for (let i = 0;i<locations;i++){
        sumGold=0;
        
        let expectedAverageGoldPerDay = Number(input[index]);
        index++;
        let daysPerLocation = Number(input[index]);
        index++;
       
        for(let j =0;j<daysPerLocation;j++){
            let currentDayGold = Number(input[index]);
            index++;
            sumGold+=currentDayGold/daysPerLocation;
        
        }
        if(sumGold>=expectedAverageGoldPerDay){
            console.log(`Good job! Average gold per day: ${sumGold.toFixed(2)}.`);
        }else if (sumGold<expectedAverageGoldPerDay){
            console.log(`You need ${(expectedAverageGoldPerDay-sumGold).toFixed(2)} gold.`);
        }
    }
}
solve(["2",
    "10",
    "3",
    "10",
    "10",
    "11",
    "20",
    "2",
    "20",
    "10"]);
