function solve(arr) {

    let foods = {};

    for (let index = 0; index < arr.length; index += 2) {

        let food = arr[index];

        foods[food] = 0;

        let caloriesPerHundredGrams = Number(arr[index+1]);

        foods[food] += caloriesPerHundredGrams;

    }

    console.log(foods);
}
solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);