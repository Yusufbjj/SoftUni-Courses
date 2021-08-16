function problem3(input) {
    let battles = {};
    while (input[0] != "Results") {
        let line = input.shift();
        let [command, ...others] = line.split(":");
        if (command == "Add") {
            let [name, health, energy] = others;
            health = Number(health);
            energy = Number(energy);
            if (!battles[name]) {
                battles[name] = {
                    health,
                    energy
                }
            } else {
                battles[name].health += health;
            }
        } else if (command == "Attack") {
            let [atackerName, defenderName, damage] = others;
            damage = Number(damage);
            if (battles[atackerName] && battles[defenderName]) {
                battles[defenderName].health -= damage
                battles[atackerName].energy -= 1;
                if (battles[defenderName].health <= 0) {
                    delete battles[defenderName];
                    console.log(`${defenderName} was disqualified!`);
                }
                if (battles[atackerName].energy <= 0) {
                    delete battles[atackerName];
                    console.log(`${atackerName} was disqualified!`);
                }
            }
        } else if (command == "Delete") {
            let username = others[0];
            if (username == "All") {
               for (let key in battles) {
                  delete battles[key]
               }
               
            }
            if (battles[username]) {
                delete battles[username]
            }
        }
        
    }
    let sorted = Object.entries(battles).sort((a,b)=>b[1].health-a[1].health || a[0].localeCompare(b[0]));
    console.log(`People count: ${sorted.length}`);
    for (let person of sorted) {
        console.log(`${person[0]} - ${person[1].health} - ${person[1].energy}`);
     
    }
}
problem3(["Add:Mark:1000:5",
    "Add:Clark:1000:2",
    "Attack:Clark:Mark:500",
    "Attack:Clark:Mark:800",
    "Add:Charlie:4000:10",
    "Results"]);

problem3(["Add:Bonnie:3000:5",
    "Add:Kent:10000:10",
    "Add:Johny:4000:10",
    "Attack:Johny:Bonnie:400",
    "Add:Johny:3000:5",
    "Add:Peter:7000:1",
    "Delete:Kent",
    "Results"])

problem3(["Add:Bonnie:3000:5",
    "Add:Johny:4000:10",
    "Delete:All",
    "Add:Bonnie:3333:3",
    "Add:Aleks:1000:70",
    "Add:Tom:4000:1",
    "Results"])



