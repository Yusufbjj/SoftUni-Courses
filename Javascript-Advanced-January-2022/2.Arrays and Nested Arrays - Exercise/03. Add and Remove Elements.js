function solve(commands) {

    let initialNum = 0;

    let result = [];

    for (const command of commands) {

        initialNum += 1;
        
        if (command === 'add') {
            
            result.push(initialNum);

        } else {

            result.pop();

        }
    }

    if (result.length > 0) {

        for (const num of result) {

            console.log(num);

        }

    } else {

        console.log("Empty");

    }

}
solve(['add',
    'add',
    'add',
    'add']);
solve(['add',
    'add',
    'remove',
    'add',
    'add']
);
solve(['remove',
    'remove',
    'remove']
);