function race(input) {
    let racerNames = input.shift().split(", ");
    let namePattern = /[A-Za-z]/g;
    let distancePattern = /\d/g;
    let racers = {};
    for (let name of racerNames) {
        racers[name] = 0;
    }
    while (input[0]!="end of race") {
        let line = input.shift();

        let letters = line.match(namePattern);
        let numbers = line.match(distancePattern);
        let name =letters.join("");
        
        let distances = numbers.map(Number);
        let totalDistance = 0;
        for (let ele of distances) {
            totalDistance+=ele;
        }
        if(racers[name]!=undefined){
            racers[name]+=totalDistance;
        }
        
        
    }
    let result = Object.entries(racers).sort((a,b)=>b[1]-a[1]).slice(0,3);
    console.log(`1st place: ${result[0][0]}\n2nd place: ${result[1][0]}\n3rd place: ${result[2][0]}`);
    
}
race(["George, Peter, Bill, Tom",
"G4e@55or%6g6!68e!!@",
"R1@!3a$y4456@",
"B5@i@#123ll",
"G@e54o$r6ge#",
"7P%et^#e5346r",
"T$o553m&6",
"end of race"]
)