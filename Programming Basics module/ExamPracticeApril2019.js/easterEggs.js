function solve(input) {
    let totalEggs = input[0];
    index = 1;
    firstEggColor = input[index];
    
    let redEggs = 0;
    let orangeEggs = 0;
    let blueEggs = 0;
    let greenEggs = 0;
    let maxEggs = 0;
    let maxEggsColor = 0;

    while(index<=totalEggs){
        let currentEggColor = input[index];
        index++;
        if(currentEggColor==="red"){
            redEggs++;
        }else if (currentEggColor==="orange"){
            orangeEggs++;
        }else if (currentEggColor==="blue"){
            blueEggs++;
        }else if (currentEggColor==="green"){
            greenEggs++;
        }


        currentEggColor = input[index];  
    }
    if(redEggs>orangeEggs&&blueEggs&&greenEggs){
        maxEggs=redEggs;
        maxEggsColor="red";
    }else if (orangeEggs>redEggs&&blueEggs&&greenEggs){
        maxEggs=orangeEggs;
        maxEggsColor="orange";
    }else if(blueEggs>greenEggs&&orangeEggs&&redEggs){
        maxEggs=blueEggs;
        maxEggsColor="blue";
    }else if(greenEggs>blueEggs&&orangeEggs&&redEggs){
        maxEggs=greenEggs;
        maxEggsColor="green";
    }
    
    console.log(`Red eggs: ${redEggs}`);
    console.log(`Orange eggs: ${orangeEggs}`);
    console.log(`Blue eggs: ${blueEggs}`);
    console.log(`Green eggs: ${greenEggs}`);
    console.log(`Max eggs: ${maxEggs} -> ${maxEggsColor}`);

}
solve(["4",
"blue",
"red",
"blue",
"orange"])
