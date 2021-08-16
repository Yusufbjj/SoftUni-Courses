function schoolGrades(input) {
    let map = new Map();
    for (let string  of input) {
        let tokens = string.split(" ");
        let name = tokens[0];
        let grades = tokens.splice(1,tokens.length).map(Number);
        
        if(!map.has(name)){
            map.set(name,[]);
        }
        let existing = map.get(name);
        for (let grade of grades) {
            existing.push(grade);
        }
    }
    let sorted = Array.from(map).sort(compareAverage);
    function compareAverage(a,b) {
        //calculate first average 
        let avgA =0;
        a[1].forEach(x=>avgA+=x);
        avgA/=a[1].length
        //calc second average
        let avgB=0;
        b[1].forEach(x=>avgB+=x);
        avgB/=b[1].length;
        // comparison
        return avgA - avgB;
    }
    for (let line of sorted) {
        console.log(`${line[0]}: ${line[1].join(", ")}`);
    }
}
schoolGrades(['Lilly 4 6 6 5',
'Tim 5 6',
'Tammy 2 4 3',
'Tim 6 6']
)