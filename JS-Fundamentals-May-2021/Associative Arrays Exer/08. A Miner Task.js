function minerTask(input) {
    let resources = {};
    for (let index = 0; index < input.length; index += 2) {
        let resource = input[index];
        let quantity = Number(input[index + 1]);
        if (!Object.keys(resources).includes(resource)) {
            resources[resource] = 0;
        }
        resources[resource] += quantity;

    }
    for (let key in resources) {
        console.log(`${key} -> ${resources[key]}`);
    }
}
minerTask([
    'Gold',
    '155',
    'Silver',
    '10',
    'Copper',
    '17'
]);
minerTask([
    'gold',
    '155',
    'silver',
    '10',
    'copper',
    '17',
    'gold',
    '15'
]
)