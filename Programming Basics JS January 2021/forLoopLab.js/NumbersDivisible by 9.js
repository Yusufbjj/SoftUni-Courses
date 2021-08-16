function solve (input){
    let x = Number(input[0]);
    let y = Number(input[1]);
    let sum = 0;
    let allNumber = "";

        for (i=x; i<=y; i++){
            if(i%9==0){
                sum+=i;
                
            }
        }
    console.log( `The sum: ${sum}`);
      for( z=x;z<=y;z++){
        if(z%9==0){
            console.log(z);
            
        }
      }


   
 }
 solve(["100","200"])