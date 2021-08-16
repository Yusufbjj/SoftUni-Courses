function bitcoinMine(input){
    let bitcoinPrice = 11949.16;
    let goldPerGram = 67.51 ;
    let daysCount=0;
    let totalBitcoins = 0;
    let firstBitcoinDay = 0;
    let totalMoney = 0;
    for (let index=0;index<input.length;index++) {
        daysCount++;
        let gold=input[index];
        if(daysCount%3===0){
            
            gold*=0.70;
            totalMoney+= gold*goldPerGram;
        }else{
            totalMoney+= gold*goldPerGram;
        }
        while(totalMoney>=bitcoinPrice){
            totalMoney-=bitcoinPrice;
            totalBitcoins++;
            if(totalBitcoins===1){
                firstBitcoinDay=daysCount;
            }
        }
    }
    console.log(`Bought bitcoins: ${totalBitcoins}`);
    if(totalBitcoins>=1){
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}   

bitcoinMine([3124.15,504.212,2511.124]);

