function loadingBar(n){
    function fullRow(n){
        return `%`.repeat(n/10)
    }
    function emptyRow(n){
        return `.`.repeat(10-n/10)
    }
   if(n===100){
       return `100% Complete!\n[${fullRow(n)}]`;
       
   }else {
       return `${n}% [${fullRow(n)}${emptyRow(n)}]\nStill loading...`
   }
}
let result =loadingBar(100);
console.log(result);