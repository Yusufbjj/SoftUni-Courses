function empployees(names) {
    for (const line of names) {
        
        let currentName = {
            name: line,
            personalNum:line.length
        }
        console.log(`Name: ${currentName.name} -- Personal Number: ${currentName.personalNum}`);
    }
}
empployees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
)