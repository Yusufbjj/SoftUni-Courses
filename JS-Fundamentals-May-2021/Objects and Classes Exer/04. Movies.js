function movies(array) {
    let movieList = [];
    for (let command of array) {

        if (command.includes("addMovie")) {
            let [addMovieCommand, ...movieName] = command.split(" ");
            let movieNameAsString = movieName.join(" ")
            let movieObject = {
                name: movieNameAsString,

            }
            movieList.push(movieObject)

        } else if (command.includes("directedBy")) {
            let tokens = command.split(" ");
            let movieNameTokens = [];
            let directorNameTokens = [];
            let directedByIndex = tokens.findIndex(x => x === "directedBy");
            for (let index = 0; index < directedByIndex; index++) {
                movieNameTokens.push(tokens[index]);

            }
            for (let index = directedByIndex + 1; index < tokens.length; index++) {
                directorNameTokens.push(tokens[index])

            }
            let name = movieNameTokens.join(" ");
            let director = directorNameTokens.join(" ");
            let movie = movieList.find(x => x.name === name);
            if (movie) {

                movie.director = director;
            }

        } else {
            let tokens = command.split(" ");
            let date = tokens.pop();
            tokens.pop();
            let name = tokens.join(" ");

            let movie = movieList.find(x => x.name === name);
            if (movie) {

                movie.date = date;
            }

        }
    }
    for (let movie of movieList) {
        if (movie.director && movie.date && movie.name) {
            console.log(JSON.stringify(movie));
        }
    }


}
movies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);