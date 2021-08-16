function demo(input) {
    index = 0;
    let name = input[index];
    index++;
    let yearlyGrade = Number(input[index]);
    index++;
    averageGrade = 0;
    grade = 0;

    while (yearlyGrade >= 4.00) {
        grade += 1;
        averageGrade += yearlyGrade

        yearlyGrade = Number(input[index])
        index++;
        if (grade == 12) {
            averageGrade = (averageGrade / grade).toFixed(2);
            console.log(`${name} graduated. Average grade: ${averageGrade}`); 
        }
        if (yearlyGrade < 4) {
            console.log(`${name} has been excluded at ${grade + 1} grade`);

        }

    }


}
demo(["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"])










