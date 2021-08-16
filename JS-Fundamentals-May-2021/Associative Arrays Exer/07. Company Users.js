function companyUsers(input) {
    let companies = {};
    //fill in company names as keys in the object and employees id as values inside an array
    for (let line of input) {
        let [companyName, employeeId] = line.split(" -> ");

        if (!Object.keys(companies).includes(companyName)) {
            companies[companyName] = [];

        }

        if (!companies[companyName].includes(employeeId)) {
            companies[companyName].push(employeeId)
        }

    }
    //sort the companies by the name in ascending order
    let sortedCompanies = Object.entries(companies).sort((a, b) => a[0].localeCompare(b[0]));
    //print 
    for (let [company, employees] of sortedCompanies) {
        console.log(company);

        for (let id of employees) {
            console.log(`-- ${id}`);
        }
    }
}
companyUsers([
    'SoftUni -> AA12345',
    'SoftUni -> BB12345',
    'Microsoft -> CC12345',
    'HP -> BB12345']);