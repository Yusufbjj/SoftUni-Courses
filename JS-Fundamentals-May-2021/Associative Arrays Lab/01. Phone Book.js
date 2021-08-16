function phoneNumber(input) {
    let phone = {};
    for (let line of input) {
      let [name,num] = line.split(" ");
      phone[name] = num;
    }
    for (let key in phone) {
      console.log(`${key} -> ${phone[key]}`);
    }
}
phoneNumber(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']);