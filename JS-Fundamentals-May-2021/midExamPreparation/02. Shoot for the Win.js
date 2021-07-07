function shootForTheWin(input) {
    let count = 0;
    let targets = input.shift().split(" ");
    targets = targets.map(Number);

    for (let index of input) {
        if (index === "End") {
            
            console.log(`Shot targets: ${count} -> ${targets.join(" ")}`);
            break;
        }
        if(index>=targets.length){
            continue;
        }
        count++;
        let reduceValue =targets[index];
        targets[index] = -1;
        
       
        
       for (let index = 0; index < targets.length; index++) {
           let ele = targets[index];
           if(ele==-1){
               continue;
           }
           if(ele>reduceValue){
            targets[index]-=reduceValue;
           }else{
            targets[index]+=reduceValue;
           }
           
       }
        
    }
}
shootForTheWin(["24 50 36 70",
    "0",
    "4",
    "3",
    "1",
    "End"]);
shootForTheWin((["30 30 12 60 54 66",
"5",
"2",
"4",
"0",
"End"])
)
