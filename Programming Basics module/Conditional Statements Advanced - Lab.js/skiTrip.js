function demo(input) {
    let nights = Number(input[0] - 1);
    let typeRoom = input[1];
    let feedback = input[2];
    let total = 0;
    

    if (nights < 10) {
        switch (typeRoom) {
            case "room for one person": total = nights * 18.00;break;   
            case "apartment": total = 0.70*(nights * 25.00);break;
            case "president apartment": total = (nights * 35.00);break;
        
        }
    }else if (nights>=10&&nights<=15){
        switch (typeRoom) {
            case "room for one person": total = (nights * 18.00);break;   
            case "apartment": total = 0.65*(nights * 25.00);break;
            case "president apartment": 0.85(total = nights * 35.00);break;
        
        }
    }else {
        switch (typeRoom) {
            case "room for one person": total = nights * 18.00;break;   
            case "apartment": total = 0.50*(nights * 25.00);break;
            case "president apartment": total = 0.80*(nights * 35.00);break;
        
        }

    } 
    if (feedback=="positive"){
        console.log((1.25*total).toFixed(2));
    }else {
        console.log((0.90*total).toFixed(2));
    }


}
demo(["2",
"apartment",
"positive"])



