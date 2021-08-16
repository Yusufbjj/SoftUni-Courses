function towns(input) {
    for (let line of input) {
        let [town, latitude, longitude] = line.split(" | ");
        let townObject = {
            town: town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        }
        console.log(townObject);
    }
}
towns(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'])