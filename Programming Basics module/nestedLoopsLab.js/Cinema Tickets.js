function demo(input) {
    let index = 0;
    let command = input[index];
    index++;
    let totalTickets = 0;
    let studentTickets = 0;
    let standardTickets = 0;
    let kidsTickets = 0;

    while (command !== "Finish") {
        let name = command;
        let freeSpace = Number(input[index]);
        index++;
        let type = input[index];
        index++;
        let soldTickets = 0;

        while (type !== "End") {

            switch (type) {
                case "standard":
                    standardTickets++;
                    totalTickets++;
                    break;
                case "student":
                    studentTickets++;
                    totalTickets++;
                    break;
                case "kid":
                    kidsTickets++;
                    totalTickets++;
                    break;
            }
            soldTickets++;
            if (freeSpace <= soldTickets) {
                break;
            }
            type = input[index];
            index++;
        }
        console.log(`${name} - ${((soldTickets / freeSpace) * 100).toFixed(2)}% full.`);


        command = input[index];
        index++;
    }
    console.log(`Total tickets: ${totalTickets}`);
    console.log(`${((studentTickets / totalTickets) * 100).toFixed(2)}% student tickets.`);
    console.log(`${((standardTickets / totalTickets) * 100).toFixed(2)}% standard tickets.`);
    console.log(`${((kidsTickets / totalTickets) * 100).toFixed(2)}% kids tickets.`);

}
demo(["The Matrix",
    "20",
    "student",
    "standard",
    "kid",
    "kid",
    "student",
    "student",
    "standard",
    "student",
    "End",
    "The Green Mile",
    "17",
    "student",
    "standard",
    "standard",
    "student",
    "standard",
    "student",
    "End",
    "Amadeus",
    "3",
    "standard",
    "standard",
    "standard",
    "Finish"]);











