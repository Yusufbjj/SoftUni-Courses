function nationalCourt(input) {
    let emp1 = Number(input[0]);
    let emp2 = Number(input[1]);
    let emp3 = Number(input[2]);
    let hoursCount = 0;
    let allPeople = input[3];
    let totalProductionPerHour = emp1+emp2+emp3;
    
    while(allPeople>0){
        hoursCount++;
        if (hoursCount%4===0) {
            continue;
        }

        allPeople-=totalProductionPerHour;

    }
    console.log(`Time needed: ${hoursCount}h.`);
}
nationalCourt(["5",  "6",  "4", "20"]);
nationalCourt(1,  2,  3, 45);
nationalCourt(3,  2,  5, 40);
    