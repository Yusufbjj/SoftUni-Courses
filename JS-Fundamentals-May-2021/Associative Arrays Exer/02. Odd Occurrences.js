function oddOcurrences(string) {
    let occurences = {};
    let listOfStrings = string.split(" ");

    for (let string of listOfStrings) {
        let stringToLower = string.toLowerCase();

        if (!Object.keys(occurences).includes(stringToLower)) {
            occurences[stringToLower] = 0;
        }
        occurences[stringToLower] += 1;
    }
    let result = [];

    for (let [key, value] of Object.entries(occurences)) {
        if (value % 2 !== 0) {
            result.push(key);
        }


    }
    console.log(result.join(" "));
}
oddOcurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')