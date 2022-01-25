function solve(input) {

    input.sort((a, b) => a.length - b.length || a.localeCompare(b));

    for (const ele of input) {
        console.log(ele);
    }
    
}
solve(['alpha',
    'beta',
    'gamma']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']

);