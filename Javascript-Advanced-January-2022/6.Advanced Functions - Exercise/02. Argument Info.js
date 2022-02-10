function solve() {

    let data = {};

    Array.from(arguments).forEach((line) => {

        let type = typeof line;

        console.log(`${type}: ${line}`);

        if (!data[type]) {

            data[type] = 0;

        }

        data[type]++;

    });

    for (let key of Object.entries(data).sort((a,b)=>b[1]-a[1])) {

       console.log(`${key[0]} = ${key[1]}`);

    }
}

solve('cat', 42, function () { console.log('Hello world!'); });