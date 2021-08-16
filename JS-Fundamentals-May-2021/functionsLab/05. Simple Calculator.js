function simpleCalculator(num1,num2,operator){
    let result =0;
    switch(operator){
        case "multiply":result=num1*num2;break;
        case "divide":result=num1/num2;break;
        case "add":result=num1+num2;break;
        case "subtract":result=num1-num2;break;
    }
    
   return result;
}
simpleCalculator(5,5,"multiply");
simpleCalculator(40,8,"divide");
simpleCalculator(12,19,"add");
simpleCalculator(50,13,"subtract");