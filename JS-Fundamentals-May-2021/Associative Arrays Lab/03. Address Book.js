function addressBook(input) {
    let addressBook = {};
    for (let line of input) {
        let [name,address] = line.split(":");
        addressBook[name] = address;
        if(addressBook.hasOwnProperty(name)){
            addressBook[name]=address;
        }
    }
    let entries = Object.entries(addressBook);
    entries.sort((a,b)=>a[0].localeCompare(b[0]));
    for (let key of entries) {
        console.log(`${key[0]} -> ${key[1]}`);
    }
}
addressBook(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']);