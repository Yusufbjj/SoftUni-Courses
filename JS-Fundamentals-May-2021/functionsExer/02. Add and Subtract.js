function addAndSubtract(num1,num2,num3){    
    let sum = (a,b)=>a+b;
    let subtract = (a,b)=>a-b;
    console.log(subtract(sum(num1,num2),num3));
    return subtract(sum(num1,num2),num3);
    
}
addAndSubtract(23,6,10);
addAndSubtract(1,17,30);
addAndSubtract(42,58,100);