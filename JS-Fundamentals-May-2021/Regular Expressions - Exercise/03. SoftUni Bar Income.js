function softuniBar(input) {
    //  %([A-Z][a-z]*)%   name 
    //  <(\w*)>        product
    //  \|(\d*)\|      count 
    //  (-?\d+(?:\.\d+)?)\$    price 
    //  %([A-Z][a-z]*)%.*?<(\w+)>.*?\|(\d+).*?\|.*?(\d+(?:\.\d+)?)\$   all in one   .*?  between them
    
    let pattern = /%([A-Z][a-z]*)%.*?<(\w+)>.*?\|(\d+)\|.*?(-?\d+(?:\.\d+)?)\$/
    let total = 0;
    while (input[0]!="end of shift") {
        let line = input.shift();

        let match = pattern.exec(line);
        
        if(match!=null){
            let [_, name, product, quantity, price] = match;
            quantity=Number(quantity);
            price = Number(price);
            total+=quantity*price;
            console.log(`${name}: ${product} - ${(quantity * price).toFixed(2)}`);
        }

    }
    console.log(`Total income: ${total.toFixed(2)}`);


   
}
// softuniBar(["%George%<Croissant>|2|10.3$",
// "%Peter%<Gum>|1|1.3$",
// "%Maria%<Cola>|1|2.4$",
// "end of shift"])
softuniBar(["%InvalidName%<Croissant>|2|10.3$",
"%Peter%<Gum>1.3$",
"%Maria%<Cola>|1|2.4",
"%Valid%<Valid>valid|10|valid20$",
"end of shift"]
)