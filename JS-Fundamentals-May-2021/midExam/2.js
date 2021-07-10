function problem2(input) {
    let oldMostFavouriteGenres = input.shift().split(" | ");
    for (let line of input) {
        let [command, genre, newGenre] = line.split(" ");
        if (command == "Stop!") {
            console.log(`${oldMostFavouriteGenres.join(" ")}`);
            break;
        }
        if (command == "Join") {
            if (!oldMostFavouriteGenres.includes(genre)) {
                oldMostFavouriteGenres.push(genre);
            }
        } else if (command == "Drop") {
            if (oldMostFavouriteGenres.includes(genre)) {
                let index = oldMostFavouriteGenres.indexOf(genre);
                oldMostFavouriteGenres.splice(index, 1);
            }
        } else if (command == "Replace") {
            if (oldMostFavouriteGenres.includes(genre) && !oldMostFavouriteGenres.includes(newGenre)){
                let indexOldGenre = oldMostFavouriteGenres.indexOf(genre);
                oldMostFavouriteGenres.splice(indexOldGenre,1,newGenre);
            }
        }

    }
}
problem2(["Romance | Fiction | Horror | Mystery",
    "Drop Romance",
    "Join Fantasy",
    "Stop!"]
)
problem2(["Poetry | Romance",
"Drop Children",
"Replace Fantasy Crime",
"Stop!"]
)