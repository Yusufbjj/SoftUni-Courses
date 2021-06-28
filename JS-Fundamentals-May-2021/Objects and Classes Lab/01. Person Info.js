function createPerson(firstName, lastName, age) {
    let person = {
        "firstName": firstName,
        "lastName": lastName,
        "age": age
    }
    return person;
}

console.log(createPerson("Peter",
    "Pan",
    "20"
));