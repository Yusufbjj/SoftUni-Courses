function bonusSystem(input) {
    input=input.map(Number);
    let students = input.shift();
    let lecturesCount = input.shift();
    let initialBonus = input.shift();

    let maxBonus=0;
    let maxAttendances = 0;
    for (let index = 0; index < students; index++) {
        let studentAttendances =input[index];
        let currentBonus= (studentAttendances / lecturesCount)* (5 + initialBonus)
        if (maxBonus<currentBonus){
            maxBonus=currentBonus;
            maxAttendances = studentAttendances;
        }

        
    }
    console.log(`Max Bonus: ${Math.ceil(maxBonus)}.`);
    console.log(`The student has attended ${maxAttendances} lectures.`);

}
bonusSystem([
    '5',  '25', '30',
    '12', '19', '24',
    '16', '20'
  ])