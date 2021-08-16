function pirates(input) {
    let cities = {};

    while (input[0] != "Sail") {
        let line = input.shift();
        let [name, population, gold] = line.split("||");
        population = Number(population);
        gold = Number(gold);
        if (!cities[name]) {
            cities[name] = {
                population: 0,
                gold: 0
            }

        }
        cities[name].gold += gold;
        cities[name].population += population;

    }
    input.shift();

    while (input[0] != "End") {
        let line = input.shift();
        let [command, ...others] = line.split("=>");
        if (command == "Plunder") {
            let [town, people, gold] = others;
            people = Number(people);
            gold = Number(gold);
            cities[town].gold -= gold;
            cities[town].population -= people;
            console.log(`${town} plundered! ${gold} gold stolen, ${people} citizens killed.`);
            if (cities[town].population == 0 || cities[town].gold == 0) {
                delete cities[town];
                console.log(`${town} has been wiped off the map!`);
            }

        } else {
            let [town, gold] = others;
            gold = Number(gold);
            if (gold <= 0) {
                console.log(`Gold added cannot be a negative number!`);
                continue;
            }
            cities[town].gold += gold;
            console.log(`${gold} gold added to the city treasury. ${town} now has ${cities[town].gold} gold.`);


        }
    }

    let sorted = Object.entries(cities).sort((a, b) => b[1].gold - a[1].gold || a[0].localeCompare(b[0]));


    let count = sorted.length;

    if (count != 0) {
        console.log(`Ahoy, Captain! There are ${count} wealthy settlements to go to:`);
        for (let city of sorted) {
            console.log(`${city[0]} -> Population: ${city[1].population} citizens, Gold: ${city[1].gold} kg`);
        }
    } else {
        console.log(`Ahoy, Captain! All targets have been plundered and destroyed!`);
    }

}
// pirates(["Tortuga||345000||1250",
//     "Santo Domingo||240000||630",
//     "Havana||410000||1100",
//     "Sail",
//     "Plunder=>Tortuga=>75000=>380",
//     "Prosper=>Santo Domingo=>180",
//     "End"])

pirates(["Nassau||95000||1000",
    "San Juan||930000||1250",
    "Campeche||270000||690",
    "Port Royal||320000||1000",
    "Port Royal||100000||2000",
    "Sail",
    "Prosper=>Port Royal=>-200",
    "Plunder=>Nassau=>94000=>750",
    "Plunder=>Nassau=>1000=>150",
    "Plunder=>Campeche=>150000=>690",
    "End"])

