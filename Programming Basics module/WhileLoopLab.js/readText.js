function demo(input) {

    let index = 0;
    let word = input[index];
    index++;
    while (word !== "Stop") {
        console.log(word);
        word = input[index];
        index++;
        


    }


}
demo(["Nakov",
    "SoftUni",
    "Sofia",
    "Bulgaria",
    "SomeText",
    "Stop",
    "AfterStop",
    "Europe",
    "HelloWorld"]);
