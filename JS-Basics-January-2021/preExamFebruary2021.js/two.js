function solve(input) {
  let width = Number(input[0]);
  let length = Number(input[1]);
  let height = Number(input[2]);
  let pilotHeight = Number(input[3]);
  let rocketSize = width*length*height;
  let roomSize = (pilotHeight+0.40)*2*2;
  let maxPeople = Math.floor(rocketSize/roomSize)

  if(maxPeople>=3 && maxPeople<=10){
    console.log(`The spacecraft holds ${maxPeople} astronauts.` );
  }else if (maxPeople<3){
    console.log(`The spacecraft is too small.`);
  }else {
      console.log("The spacecraft is too big.");
  }

  

}
solve(["4.5",
"4.8",
"5",
"1.75"]);


