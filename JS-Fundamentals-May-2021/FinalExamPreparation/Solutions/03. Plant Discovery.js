function plantDiscovery(input) {
    let n = Number(input.shift());
    let catalogue = {
        
    };
    for (let index = 0; index < n; index++) {
        let [name,rarity] = input.shift().split("<->");

        catalogue[name] = {
            rarity:Number(rarity),
            ratings:[],
            avgRating:0
        };
        
    }

    while (input[0]!="Exhibition") {
        let line = input.shift().split(": ");
        let[action,str] = line;
        let [name,num] = str.split(" - ");
        num=Number(num);

        if(action=="Rate"){
            
            if(catalogue[name]!=undefined){
                let plant = catalogue[name];
                plant.ratings.push(num);

                let total = 0;
                for (let rating of plant.ratings) {
                    total+=rating
                }
                plant.avgRating=total/plant.ratings.length;
            }else{
                console.log(`error`);
            }
        }else if(action=="Update"){
            if(catalogue[name]!=undefined){
                let plant = catalogue[name];
                plant.rarity=num;
            }else{
                console.log(`error`);
            }
        }else if(action=="Reset"){
            if(catalogue[name]!=undefined){
                let plant = catalogue[name];
                plant.ratings.length=0;
                plant.avgRating=0;
            }else{
                console.log(`error`);
            }
        }
    }

    let sorted = Object.entries(catalogue).sort((a,b)=>b[1].rarity-a[1].rarity||b[1].avgRating-a[1].avgRating||a[0].localeCompare(b[0]));
    console.log(`Plants for the exhibition:`);
    for (let [name,plant] of sorted) {
       console.log(`- ${name}; Rarity: ${plant.rarity}; Rating: ${plant.avgRating.toFixed(2)}`);
    }
    
   
}
plantDiscovery(["3",
    "Arnoldii<->4",
    "Woodii<->7",
    "Welwitschia<->2",
    "Rate: Woodii - 10",
    "Rate: Welwitschia - 7",
    "Rate: Arnoldii - 3",
    "Rate: Woodii - 5",
    "Update: Woodii - 5",
    "Reset: Arnoldii",
    "Exhibition"]);
    plantDiscovery(["2",
    "Candelabra<->10",
    "Oahu<->10",
    "Rate: Oahu - 7",
    "Rate: Candelabra - 6",
    "Exhibition"])
    
