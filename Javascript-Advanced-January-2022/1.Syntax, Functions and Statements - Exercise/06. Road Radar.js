function solve(speed, area) {

    let status = "";

    let difference;

    let speedLimit;

    switch (area) {
        case "city": speedLimit = 50; break;
        case "residential": speedLimit = 20; break;
        case "interstate": speedLimit = 90; break;
        case "motorway": speedLimit = 130; break;
    }

    if (speed <= speedLimit) {

        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);

    } else {

        difference = speed - speedLimit;

        if (difference <= 20) {

            status = "speeding";

        } else if (difference <= 40) {

            status = "excessive speeding";

        } else {

            status = "reckless driving";
            
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }

}
solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');