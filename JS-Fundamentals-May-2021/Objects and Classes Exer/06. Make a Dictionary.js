function dictionary(input) {
    let terms = {};

   for (let str of input) {
       let parsed = JSON.parse(str);
      for (let [term,definition] of Object.entries(parsed)) {
          terms[term] = definition;
      }
   }
   let sorted = Object.entries(terms).sort((a,b)=>a[0].localeCompare(b[0]));
   for (let key of sorted) {
      console.log(`Term: ${key[0]} => Definition: ${[key[1]]}`);
   }
}
dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
    );