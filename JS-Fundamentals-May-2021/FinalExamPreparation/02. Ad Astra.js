function adAstra([input]) {
    let pattern = /(\||#)(?<item>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1/g;
    let totalCalories = 0;
    let foods = [];
    let matches = pattern.exec(input)


    // for (let item of matches) {
    //     let symbol = item[0];

    //     item = item.split(`${symbol}`);
    //     let calories = Number(item[3]);
    //     totalCalories += calories;
    // }
    // let days = Math.floor(totalCalories / 2000);
    // console.log(`You have food to last you for: ${days} days!`);
    // for (let item of matches) {
    //     let symbol = item[0];

    //     item = item.split(`${symbol}`);
    //     console.log(`Item: ${item[1]}, Best before: ${item[2]}, Nutrition: ${item[3]}`);
    // }

        while (matches != null) {
            let item = matches[2];
            let date = matches[3];
            let calories = Number(matches[4]);

            
            totalCalories += calories;
            foods.push(`Item: ${item}, Best before: ${date}, Nutrition: ${calories}`)
            matches = pattern.exec(input);
        }
        let days = Math.floor(totalCalories / 2000);
        console.log(`You have food to last you for: ${days} days!`);
        for (let line of foods) {
            console.log(line);
        }
    
}
adAstra([
    '#Bread#19/03/21#4000#|Invalid|03/03.20||Apples|08/10/20|200||Carrots|06/08/20|500||Not right|6.8.20|5|'
])
adAstra(['$$#@@%^&#Fish#24/12/20#8500#|#Incorrect#19.03.20#450|$5*(@!#Ice Cream#03/10/21#9000#^#@aswe|Milk|05/09/20|2000|']);