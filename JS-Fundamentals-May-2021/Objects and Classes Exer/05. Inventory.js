function inventory(array) {
    let heroes = [];
  
    for (let command of array) {
        let [name, level,items] = command.split(" / ");
        
        items= items.split(", ")
        
        let hero = {
            name:name,
            level:level,
            items:items
        }
        heroes.push(hero);
    }
    
    let sortedHeroes = heroes.sort((a, b) => a.level - b.level);
    
    for (let hero of sortedHeroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.sort((a,b)=>a.localeCompare(b)).join(", ")}`);
    }
}
inventory([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
]
)