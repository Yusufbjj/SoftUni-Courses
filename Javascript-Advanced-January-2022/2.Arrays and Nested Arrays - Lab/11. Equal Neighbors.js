function equalNeighbors(input) {

    let pairs = 0;

    for (let rows = 0; rows < input.length; rows++) {

        for (let cols = 0; cols < input[rows].length; cols++) {

            if (input[rows][cols] == input[rows][cols + 1]) {

                pairs++;

            }
            
            if ((input[rows + 1]) != undefined) {

                if (input[rows][cols] == input[rows + 1][cols]) {

                    pairs++;

                }
            }
        }
    }

    return (pairs);
}

equalNeighbors([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
);

equalNeighbors([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
);

equalNeighbors([
    ["2", "2", "5", "7", "4"],
    ["4", "0", "5", "3", "4"],
    ["2", "5", "5", "4", "2"]])



