function solve (input){
    let type = input[0];
    let area = 0
    if (type === "square"){
        let num = Number(input[1]);
        area = num * num
        
    } else if (type === "rectangle"){
        let numA = Number(input[1]);
        let numB = Number(input[2]);
        area = numA * numB ; 
        
    } else if (type==="circle") {
        let r = Number(input[1]);
         area = Math.PI * r * r;
        
    } else {
        let numA = Number (input[1]);
        let numB = Number (input[2]);
         area = numA * numB / 2;
       

    }
    console.log(area.toFixed(3));

}
solve (["triangle","4.5","20"])


