function demo(input) {
let index = 0;
let number = input[index];
index++;
let lowestNumber=34543453;

while(number!=="Stop"){
    
    if (number<lowestNumber){
        lowestNumber = Number(number);
    }
    number = input[index];
    index++;
    
}
console.log(lowestNumber);

   
}
demo(["45",
"-20",
"7",
"99",
"Stop"]);







