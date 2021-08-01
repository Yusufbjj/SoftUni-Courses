function destinationMapper(input) {
    let pattern = /(\=|\/)([A-Z][A-Za-z]{2,})\1/g;
    let matches = input.match(pattern);
    let travelPoints = 0;
    let destinations = [];
    if(matches!=null){

        for (let destination of matches) {
            let name = destination.slice(1, destination.length - 1);
            let currentPoints = name.length;
            destinations.push(name);
            travelPoints += currentPoints;
        }
    }
    console.log(`Destinations: ${destinations.join(", ")}`);
    console.log(`Travel Points: ${travelPoints}`);
    
}
destinationMapper("=Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i=");
destinationMapper("ThisIs some InvalidInput");