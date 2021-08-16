function gladiator(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let countLostFights = 0;
    let helmetExpences = 0;
    let swordExpences = 0;
    let shieldExpences = 0;
    let armorExpences = 0;
    let brokenShieldCounter = 0;
    for (let index = 0; index < lostFights; index++) {
        
        countLostFights += 1;
        if (countLostFights % 2 === 0) {
            helmetExpences += helmetPrice;
        }
        if (countLostFights % 3 === 0) {
            swordExpences += swordPrice;
        }
        if (countLostFights % 3 === 0 && countLostFights % 2 === 0) {
            shieldExpences += shieldPrice;
            brokenShieldCounter++;
            if (brokenShieldCounter % 2 === 0) {
                armorExpences += armorPrice;
            }

        }



    }
    let expenses = helmetExpences + swordExpences + shieldExpences + armorExpences;
    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}
gladiator(23,
    12.50,
    21.50,
    40,
    200
    
);