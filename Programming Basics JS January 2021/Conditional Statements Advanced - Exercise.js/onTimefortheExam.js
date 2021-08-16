function test(input) {
    let examHour = Number(input[0]);
    let examMinute = Number(input[1]);
    let arrivalHour = Number(input[2]);
    let arrivalMinute = Number(input[3]);

    let arriveTimeInMinutes = arrivalHour * 60 + arrivalMinute;
    let examTimeInMinutes = examHour * 60 + examMinute;
    let lateMinutes = 0;
    let lateHours = 0;
    let onTimeMinutes = 0;
    let earlyHours = 0;
    let earlyMinutes = 0;

    if (arriveTimeInMinutes > examTimeInMinutes) {
        console.log(`Late`);
        if (arriveTimeInMinutes - examTimeInMinutes < 60) {
            lateMinutes = arriveTimeInMinutes - examTimeInMinutes;
            console.log(`${lateMinutes} minutes after the start`);

        } else if (arriveTimeInMinutes - examTimeInMinutes >= 60) {
            lateHours = Math.floor((arriveTimeInMinutes - examTimeInMinutes) / 60);
            lateMinutes = (arriveTimeInMinutes - examTimeInMinutes) % 60;


        }

        if (lateMinutes < 10) {
            console.log(`${lateHours} :0${lateMinutes} hours after the start`);
        } else {
            console.log(`${lateHours} : ${lateMinutes} hours after the start`);
        }




    } else if (arriveTimeInMinutes === examTimeInMinutes || examTimeInMinutes - arriveTimeInMinutes <= 30) {
        console.log(`On time`);
        onTimeMinutes = examTimeInMinutes - arriveTimeInMinutes;
        if (arriveTimeInMinutes != examTimeInMinutes) {
            console.log(`${onTimeMinutes} minutes before the start`)
        }


    } else if (examTimeInMinutes - arriveTimeInMinutes > 30) {
        console.log(`Early`);
        if (examTimeInMinutes - arriveTimeInMinutes < 60) {
            earlyMinutes = examTimeInMinutes - arriveTimeInMinutes;
            console.log(`${earlyMinutes} minutes before the start`)
        } else if (examTimeInMinutes - arriveTimeInMinutes >= 60) {

            earlyHours = Math.floor((examTimeInMinutes - arriveTimeInMinutes) / 60);
            earlyMinutes = ((examTimeInMinutes - arriveTimeInMinutes) % 60);



        }

        if (earlyMinutes < 10) {
            console.log(`${earlyHours} :0${earlyMinutes} hours before the start`);
        } else {
            console.log(`${earlyHours} : ${earlyMinutes} hours before the start`);
        }


    }

    


}
test(["16", "00", "15", "00"])




















