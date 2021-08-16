function movies(array) {
    let moviesList = [];

    for (let command of array) {
        if (command.includes("addMovie")) {

            let [addMovieCommand, ...movie] = command.split(" ");
            let movieNameAsString = movie.join(" ");
            let movieObject = {
                name: movieNameAsString,
            }
            moviesList.push(movieObject);
        } else if (command.includes("directedBy")) {
            let [movieName,director] = command.split(" directedBy ");
            
            let movie = moviesList.find(x=>x.name===movieName);
            console.log(movie);
            if(movie){
                movie.director = director;
            }
        }else{
            let [movieName,date] = command.split(" onDate ");
            let movie = moviesList.find(x=>x.name===movieName);
            if(movie){
                movie.date=date;
            }
        }
    }
    for (let movie of moviesList) {
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
]
);