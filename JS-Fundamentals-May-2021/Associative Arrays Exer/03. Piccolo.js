function piccolo(input) {
    let parkingLot = [];
   
    for (let car of input) {
        let [direction,carNumber] = car.split(", ");
        if(direction=="IN"){
            if(!parkingLot.includes(carNumber)){

                parkingLot.push(carNumber);
            }
        }else if(direction=="OUT"){
            if(parkingLot.includes(carNumber)){

                
                parkingLot.splice(parkingLot.indexOf(carNumber),1);
            }
        }
    }
    let sorted=parkingLot.sort((a,b)=>a.localeCompare(b));
   
    if(parkingLot.length>0){
      console.log(`${sorted.join("\n")}`);
    }else{
        
        console.log(`Parking Lot is Empty`);
    }
   
}
piccolo(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']);
piccolo(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
)