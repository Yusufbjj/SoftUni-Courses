function nxnMatrix(n){
    for (let index = 0; index < n; index++) {
        let coloumn = ""
        let row = n+" "
        for (let index = 0; index < n; index++) {
           
           coloumn+=row;
            
        }
        console.log(coloumn);
    }
}
nxnMatrix(3)
nxnMatrix(7)
nxnMatrix(2)