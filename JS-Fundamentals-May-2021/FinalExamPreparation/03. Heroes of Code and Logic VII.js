function heroesOfCode(input) {
    
    let n = Number(input.shift());
    let heroes = {}
    for (let index = 0; index < n; index++) {
        let line = input.shift();
        let [name, hp, mp] = line.split(" ");
        hp = Number(hp);
        mp = Number(mp);
        heroes[name] = {
            hp,
            mp
        }
    }
    if (heroes) {

        while (input[0] != "End") {
            let line = input.shift();
            let [command,...others] = line.split(" - ");
            if (command == "CastSpell") {
                let [heroName, mpNeeded, spellName] = others;
                mpNeeded = Number(mpNeeded);
                if (heroes[heroName].mp >= mpNeeded) {
                    heroes[heroName].mp -= mpNeeded;
                    console.log(`${heroName} has successfully cast ${spellName} and now has ${heroes[heroName].mp} MP!`);
                } else {
                    console.log(`${heroName} does not have enough MP to cast ${spellName}!`);
                }
            } else if (command == "TakeDamage") {
                let [name, damage, atacker] = others;
                damage = Number(damage);
                heroes[name].hp -= damage;
                if (heroes[name].hp > 0) {
                    console.log(`${name} was hit for ${damage} HP by ${atacker} and now has ${heroes[name].hp} HP left!`);
                } else {
                    console.log(`${name} has been killed by ${atacker}!`);
                    delete heroes[name];
                }
            } else if (command == "Recharge") {
                let [name, amount] = others;
                amount = Number(amount);
                if (heroes[name].mp + amount > 200) {
                    let recovered = 200 - heroes[name].mp;
                    heroes[name].mp += recovered;
                    console.log(`${name} recharged for ${recovered} MP!`);
                } else {
                    heroes[name].mp += amount;
                    console.log(`${name} recharged for ${amount} MP!`);
                }

            } else if (command == "Heal") {
                let [name, amount] = others;
                amount = Number(amount);
                if (heroes[name].hp + amount > 100) {
                   let difference = 100 - heroes[name].hp;
                    heroes[name].hp += difference;
                    console.log(`${name} healed for ${difference} HP!`);
                } else {
                    heroes[name].hp += amount;
                    console.log(`${name} healed for ${amount} HP!`);
                }

            }
        }
    }
    let sortedHeroes = Object.entries(heroes).sort((a, b) => b[1].hp - a[1].hp || a[0].localeCompare(b[0]));
    for (let hero of sortedHeroes) {
       
        console.log(hero[0]);
        console.log(`  HP: ${hero[1].hp}`);
        console.log(`  MP: ${hero[1].mp}`);
    }

}
heroesOfCode(["2",
    "Solmyr 85 120",
    "Kyrre 99 50",
    "Heal - Solmyr - 10",
    "Recharge - Solmyr - 50",
    "TakeDamage - Kyrre - 66 - Orc",
    "CastSpell - Kyrre - 15 - ViewEarth",
"End"])

//heroesOfCode(["4", "Adela 90 150", "SirMullich 70 40", "Ivor 1 111", "Tyris 94 61", "Heal - SirMullich - 50", "Recharge - Adela - 100", "CastSpell - Tyris - 1000 - Fireball", "TakeDamage - Tyris - 99 - Fireball", "TakeDamage - Ivor - 3 - Mosquito", "End"])