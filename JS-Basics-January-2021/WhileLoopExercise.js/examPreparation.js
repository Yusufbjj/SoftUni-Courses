function demo(input) {
    index = 0;
    let alowedBadGrades = Number(input[index]);
    index++;
    let exerciseName = input[index];
    index++;
    let exerciseGrade = Number(input[index]);
    index++;


    let sumGrades = 0;
    let lastExercise = ""
    let grades = 0;
    let averageGrade = 0;
    let badGrades = 0;

    while (badGrades < alowedBadGrades) {
        if (exerciseGrade <= 4) {
            badGrades++;
        }
        lastExercise = exerciseName;
        sumGrades += exerciseGrade;
        grades++;
        averageGrade = sumGrades / grades;

        exerciseName = input[index];
        index++;
        exerciseGrade = Number(input[index]);
        index++;

        if (exerciseName === "Enough") {
            console.log(`Average score: ${averageGrade.toFixed(2)}`);
            console.log(`Number of problems: ${grades}`);
            console.log(`Last problem: ${lastExercise}`); break;
        }
        if (alowedBadGrades <= badGrades) {
            console.log(`You need a break, ${badGrades} poor grades.`); break;

        }

    }

}
demo(["4",
    "Stone Age",
    "5",
    "Freedom",
    "5",
    "Storage",
    "3",
    "Enough"])


















