function solve(obj) {

    let resultObj = {
        model: "",
        engine: {
            power: 0,
            volume: 0
        },
        carriage: {
            type: "",
            color: ""
        },
        wheels: []
    };

    resultObj.model = obj.model;

    if (obj.power <= 90) {

        resultObj.engine.power = 90;

        resultObj.engine.volume = 1800;


    } else if (obj.power <= 120) {

        resultObj.engine.power = 120;

        resultObj.engine.volume = 2400;

    } else if (obj.power <= 200) {

        resultObj.engine.power = 200;

        resultObj.engine.volume = 3500;
    }

    if (obj.carriage == "hatchback") {

        resultObj.carriage.type = "hatchback";

        resultObj.carriage.color = obj.color;

    } else {
        resultObj.carriage.type = "coupe";

        resultObj.carriage.color = obj.color;
    }

    if (obj.wheelsize % 2 == 0) {

        let size = obj.wheelsize - 1;

        for (let index = 0; index < 4; index++) {

            resultObj.wheels.push(size);

        }

    } else {

        for (let index = 0; index < 4; index++) {

            resultObj.wheels.push(obj.wheelsize);

        }
    }

    return (resultObj);
}

solve({
    model: 'Brichka',
    power: 65,
    color: 'white',
    carriage: 'hatchback',
    wheelsize: 16
});