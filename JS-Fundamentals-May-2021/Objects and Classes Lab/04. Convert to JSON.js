function convertToJson(name,lastName,color) {
    let result = {
        name:name,
        lastName:lastName,
        hairColor:color
    };
    console.log(JSON.stringify(result));
}
convertToJson('George',
'Jones',
'Brown'
)