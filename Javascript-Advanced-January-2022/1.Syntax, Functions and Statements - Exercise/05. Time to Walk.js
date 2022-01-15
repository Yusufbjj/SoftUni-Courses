function timeToWalk(steps, meters, speedKmH) {

    let distance = steps * meters;

    let speed = speedKmH * 1000 / 3600; //meter per seconds

    let rest = Math.floor(distance / 500) * 60; //rest in seconds

    let totalTimeInSeconds = distance / speed + rest; // 

    let hours = Math.floor(totalTimeInSeconds / 3600).toFixed(0).padStart(2, "0");
    let minutes = Math.floor(totalTimeInSeconds / 60).toFixed(0).padStart(2, "0");
    let seconds = Math.round(totalTimeInSeconds % 60).toFixed(0).padStart(2, "0");

    console.log(`${hours.padStart(2, "0")}:${minutes}:${seconds}`);
}
timeToWalk(4000, 0.60, 5);
timeToWalk(2564, 0.70, 5.5);