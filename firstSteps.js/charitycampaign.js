function demo(input){
    let days = Number(input[0]);
    let chefs = Number(input[1]);
    let cakes = Number(input[2]);
    let gofrettes = Number(input[3]);
    let pancakes = Number(input[4]);
    let cakesIncome = cakes * 45;
    let gofrettesIncome = gofrettes * 5.80;
    let pancakesIncome = pancakes * 3.20;
    let totalDay = (cakesIncome+gofrettesIncome+pancakesIncome)*chefs;
    let totalOverall = totalDay * days;
    let totalAfterOutgoings = totalOverall - ( totalOverall / 8);
    
    

    console.log(totalAfterOutgoings)

}
demo(['23','8','14','30','16'])