function solve(input) {

    let result = [];

    input.shift();

    for (let line of input) {

        let [Town, Latitude, Longitude] = line.split(" |");

        Town = Town.substring(2);

        let obj = {
            Town,
            Latitude: Number(Number(Latitude).toFixed(2)),
            Longitude: Number(Number(Longitude).toFixed(2))
        };

        result.push(obj);
     
    }
    console.log(JSON.stringify(result));
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);