function demo(input) {

    let guests = Number(input[0]);
    let moneyPerPerson = Number(input[1]);
    let budget = Number(input[2]);
    let discount = moneyPerPerson;

    if (guests >= 10) {
        discount =moneyPerPerson- (0.15 * moneyPerPerson);
    }
    if (guests > 15) {
        discount = moneyPerPerson- (0.20 * moneyPerPerson);
    }
    if (guests > 20) {
        discount = moneyPerPerson-(0.25 * moneyPerPerson);
    }
    

    let cakePrice = 0.1 * budget;
    let totalMoney = guests * discount + cakePrice;

    if (totalMoney > budget) {
        console.log(`No party! ${(totalMoney - budget).toFixed(2)} leva needed.`);
    }
    if (budget > totalMoney) {

        console.log(`It is party time! ${(budget - totalMoney).toFixed(2)} leva left.`);

    
    }
    
}
demo(["24", "35", "550"]);