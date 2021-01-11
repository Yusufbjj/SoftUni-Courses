function demo(input){

let dogs = Number (input[0]);
let otherPets = Number (input[1]);
let dogsFood = dogs * 2.5
let otherPetsFood = otherPets* 4 
let finalAmount = dogsFood + otherPetsFood

console.log(` ${finalAmount} lv.`)

}

demo(["5","4"])