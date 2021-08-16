function triange(n){
 for (let index = 1; index <= n; index++) {
    let line = "";
    for (let j = 1; j <= index; j++) {
       line+=index+" "
    }
    console.log(line);
 }
}
triange(3);
triange(5);
triange(6);