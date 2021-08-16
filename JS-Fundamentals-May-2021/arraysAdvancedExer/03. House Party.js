function houseParty(array) {
    let list = [];
    for (const line of array) {
        let [name] = line.split(" ")

        if (line === `${name} is going!`) {
            if(list.includes(name)){
                console.log(`${name} is already in the list!`);     
            }else{
                list.push(name);

            }
        } else if (line === `${name} is not going!`) {
            if (list.includes(name)) {
                list.pop(name);
            }else{
                console.log(`${name} is not in the list!`);
            }
        }
    }
    console.log(list.join("\n"));
   
}
houseParty(['Allie is going!',
    'George is going!',
    'John is not going!',
    'George is not going!']
)
houseParty(['Tom is going!',
'Annie is going!',
'Tom is going!',
'Garry is going!',
'Jerry is going!']
)
