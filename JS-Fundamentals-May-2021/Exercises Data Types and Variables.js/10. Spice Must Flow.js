function spice(startingYield){
    let miningCrew=26;
    let daysCounter=0;
    let totalSpice=0;
    while(startingYield>=100){
        let spiceCurrentDay=startingYield-miningCrew;
        totalSpice+=spiceCurrentDay;


        daysCounter++;
        startingYield-=10;

    }
    if(totalSpice>=miningCrew){
        totalSpice-=miningCrew;
    }
    
    console.log(`${daysCounter}\n${totalSpice}`);
    
}
spice(450)