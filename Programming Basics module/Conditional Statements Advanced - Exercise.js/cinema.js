function test(input) {
    let projection = input[0];
    let rows = Number(input[1]);
    let coloumns = Number(input[2]);

    let income = 0;

    if(projection==="Premiere"){
        income=rows*coloumns*12.0;
    }else if (projection==="Normal"){
        income=rows*coloumns*7.50;;
    }else if (projection==="Discount"){
        income=rows*coloumns*5.00;
    }
    console.log(`${income.toFixed(2) } leva`)

}
test(["Discount",
"12",
"30"]);



