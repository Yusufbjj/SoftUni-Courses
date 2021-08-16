function solve(input) {
  let speed = Number(input[0]);
  let letresForHundredKilometres = Number(input[1]);
  let distance = 384400;
  let distanceBothWays = distance*2;
  let timeBothWays = Math.ceil(distanceBothWays / speed .toFixed(2));
  let totalTime = timeBothWays+3;
  let fuel = (letresForHundredKilometres*distanceBothWays)/100;
  console.log(totalTime);
  console.log(fuel);
}
solve(["10000",
"5"]);

