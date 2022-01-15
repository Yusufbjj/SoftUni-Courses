function solve(...input) {
    let num = Number(input[0]);

    for (let index = 1; index < input.length; index++) {
        switch (input[index]) {
            case "chop": num /= 2; break;
            case "dice": num = Math.sqrt(num); break;
            case "spice": num += 1; break;
            case "bake": num *= 3; break;
            case "fillet": num = (num * 0.80).toFixed(1); break;
        }
        console.log(num);
    }


}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');