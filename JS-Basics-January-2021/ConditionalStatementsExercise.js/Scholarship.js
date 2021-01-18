function demo(input) {
    let income = Number(input[0]);
    let grade = Number(input[1]);
    let minimumSalary = Number(input[2]);
    let socialScholarship = 0.35 * minimumSalary;
    let excelentScholarship = grade * 25;

    if (income > minimumSalary) {
        console.log("You cannot get a scholarship!")
    } else
        if (grade > 4.5)
            if (socialScholarship > excelentScholarship) {
                console.log(`You get a Social scholarship ${socialScholarship} BGN`);
            } else if (grade >= 5.5)
                if (excelentScholarship > socialScholarship) {
                    console.log(`You get a scholarship for excellent results ${excelentScholarship} BGN`);

                } else {
                    console.log(`You get a Social scholarship ${socialScholarship} BGN`);
                }



}
demo(["0.00", "5.65", "420.00"]);

