function partyTime(input) {
    let indexOfParty = input.indexOf("PARTY");
    let digitList = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0"];
    let vip = [];
    let regular = [];

    for (let index = 0; index < indexOfParty; index++) {
        let currentGuest = input[index];
        if (digitList.includes(currentGuest[0])) {
            vip.push(currentGuest);
        } else {
            regular.push(currentGuest);
        }

    }
    for (let index = indexOfParty + 1; index < input.length; index++) {
        let currentGuest = input[index];
        if (vip.includes(currentGuest)) {
            vip.splice(vip.indexOf(currentGuest), 1);
        } else if (regular.includes(currentGuest)) {
            regular.splice(regular.indexOf(currentGuest), 1);
        }

    }
    let totalGuests = vip.length + regular.length;
    console.log(totalGuests);
    console.log(vip.join("\n"));
    console.log(regular.join("\n"));
}
partyTime(['7IK9Yo0h',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc',
    'tSzE5t0p',
    'PARTY',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc'
]);