function solve(input) {
  let index = 0;
  let command = input[index];
  index++;
  let numberAdults = 0;
  let numberKids = 0;
  let moneyForToys = 0;
  let moneyForSweaters = 0;
  while (command != "Christmas") {
    let age = Number(command);
    if (age <= 16) {
      numberKids++;
      moneyForToys += 5;
    } else if (age > 16) {
      numberAdults++;
      moneyForSweaters += 15;
    }
    command = input[index];
    index++;
  }
  console.log(`Number of adults: ${numberAdults}`);
  console.log(`Number of kids: ${numberKids}`);
  console.log(`Money for toys: ${moneyForToys}`);
  console.log(`Money for sweaters: ${moneyForSweaters}`);
}
solve(["16",
  "20",
  "46",
  "12",
  "8",
  "20",
  "49",
  "Christmas"]);



