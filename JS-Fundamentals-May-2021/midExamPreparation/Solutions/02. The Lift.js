function theLift(input) {
    let people = Number(input.shift());
    let wagons = input.join().split(" ").map(Number);
    for (let index = 0; index < wagons.length; index++) {
        while (wagons[index]<4) {
            if(people==0){         
                break;
            }
            wagons[index] += 1;
            people-=1;
        }
    }

    if(people==0 && wagons[wagons.length-1]!=4 ){
        console.log(`The lift has empty spots!\n${wagons.join(" ")}`);
    }else if(people>0){
        console.log(`There isn't enough space! ${people} people in a queue!\n${wagons.join(" ")}`);
    }else if(people==0 && wagons[wagons.length-1]==4 ){
        console.log(`${wagons.join(" ")}`);
    }
}
theLift(["15", "0 0 0 0 0"]);
theLift([ "20", "0 2 0"]);