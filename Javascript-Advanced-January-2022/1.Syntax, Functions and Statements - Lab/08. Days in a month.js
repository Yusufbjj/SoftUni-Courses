function solve(month, year) {

    let days = new Date(year, month, 0);

    console.log(days.getDate());
    
}
solve(1, 2012);
solve(2, 2021);