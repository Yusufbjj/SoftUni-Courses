function needForSpeed(input) {
    let n = Number(input.shift());
    let cars = {};
    for (let index = 0; index < n; index++) {


        let line = input.shift();
        let [car, mileage, fuel] = line.split("|");
        mileage = Number(mileage);
        fuel = Number(fuel);
        cars[car] = {
            mileage,
            fuel
        };

    }


    while (input[0] != "Stop") {
        let line = input.shift();
        let [action, ...others] = line.split(" : ");

        if (action == "Drive") {
            let [car, distance, fuel] = others;
            distance = Number(distance);
            fuel = Number(fuel);
            if (cars[car].fuel < fuel) {
                console.log(`Not enough fuel to make that ride`);
            } else {
                cars[car].mileage += distance;
                cars[car].fuel -= fuel;
                console.log(`${car} driven for ${distance} kilometers. ${fuel} liters of fuel consumed.`);
            }
            if (cars[car].mileage >= 100000) {
                delete cars[car];
                console.log(`Time to sell the ${car}!`);
            }
        } else if (action == "Refuel") {
            let [car, fuel] = others;
            fuel = Number(fuel);

            if (cars[car].fuel + fuel > 75) {
                let difference = 75 - cars[car].fuel;
                cars[car].fuel = 75;
                console.log(`${car} refueled with ${difference} liters`);
            } else {
                cars[car].fuel += fuel;
                console.log(`${car} refueled with ${fuel} liters`);
            }
        } else if (action == "Revert") {
            let [car, kilometers] = others;
            kilometers = Number(kilometers);

            cars[car].mileage -= kilometers;
            if (cars[car].mileage < 10000) {
                cars[car].mileage = 10000;
            } else {
                console.log(`${car} mileage decreased by ${kilometers} kilometers`);

            }
        }
    }

    let sorted = Object.entries(cars).sort((a, b) => b[1].mileage - a[1].mileage || a[0].localeCompare(b[0]));

    for (let car of sorted) {

        console.log(`${car[0]} -> Mileage: ${car[1].mileage} kms, Fuel in the tank: ${car[1].fuel} lt.`);
    }
}
needForSpeed([
    '3',
    'Audi A6|38000|62',
    'Mercedes CLS|11000|35',
    'Volkswagen Passat CC|45678|5',
    'Drive : Audi A6 : 543 : 47',
    'Drive : Mercedes CLS : 94 : 11',
    'Drive : Volkswagen Passat CC : 69 : 8',
    'Refuel : Audi A6 : 50',
    'Revert : Mercedes CLS : 500',
    'Revert : Audi A6 : 30000',
    'Stop']);
needForSpeed([
    '4',
    'Lamborghini Veneno|11111|74',
    'Bugatti Veyron|12345|67',
    'Koenigsegg CCXR|67890|12',
    'Aston Martin Valkryie|99900|50',
    'Drive : Koenigsegg CCXR : 382 : 82',
    'Drive : Aston Martin Valkryie : 99 : 23',
    'Drive : Aston Martin Valkryie : 2 : 1',
    'Refuel : Lamborghini Veneno : 40',
    'Revert : Bugatti Veyron : 2000',
    'Stop'])