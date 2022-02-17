window.addEventListener('load', solve);

function solve() {
    let inputGenre = document.getElementById('genre');
    let inputNameOfSong = document.getElementById('name');
    let inputAuthor = document.getElementById('author');
    let inputDate = document.getElementById('date');

    let addBtn = document.getElementById('add-btn');

    let collectionOfSongsContainer = document.querySelector(".all-hits-container");
    let savedSongsContainer = document.querySelector(".saved-container");
    let likesContainer = document.querySelector(".likes p");

    addBtn.addEventListener('click', (e) => {

        e.preventDefault();
        let divHitsInfoElement = document.createElement('div');
        divHitsInfoElement.classList.add('hits-info');

        if (inputGenre.value !== '' && inputNameOfSong.value !== '' && inputAuthor.value !== '' && inputDate !== '') {

            let genreText = inputGenre.value;
            let songText = inputNameOfSong.value;
            let authorText = inputAuthor.value;
            let dateText = inputDate.value;

            let imgElement = document.createElement('img');
            debugger;
            imgElement.setAttribute('src', "./static/img/img.png");

            let genreElement = document.createElement('h2');
            let songElement = document.createElement("h2");
            let authorElement = document.createElement("h2");
            let dateElement = document.createElement("h3");

            let saveSongButtonElement = document.createElement("button");
            saveSongButtonElement.classList.add('save-btn');
            saveSongButtonElement.textContent = "Save song";
            saveSongButtonElement.addEventListener('click', (e) => {
                e.target.remove();
                likeSongButtonElement.remove();
                savedSongsContainer.appendChild(divHitsInfoElement);
            });

            let likeSongButtonElement = document.createElement("button");
            likeSongButtonElement.classList.add('like-btn');
            likeSongButtonElement.textContent = "Like song";
            likeSongButtonElement.addEventListener('click', (e) => {
                e.target.disabled = true;
                let likesArr = likesContainer.textContent.split(": ");
                let likesNumber = Number(likesArr[1]);
                likesNumber++;
                likesContainer.textContent = `Total Likes: ${likesNumber}`;
            });


            let deleteButtonElement = document.createElement("button");
            deleteButtonElement.classList.add('delete-btn');
            deleteButtonElement.textContent = "Delete";
            deleteButtonElement.addEventListener('click', (e) => {
                e.target.parentElement.remove();
            });


            genreElement.textContent = `Genre: ${genreText}`;
            songElement.textContent = `Name: ${songText}`;
            authorElement.textContent = `Author: ${authorText}`;
            dateElement.textContent = `Date: ${dateText}`;

            divHitsInfoElement.appendChild(imgElement);
            divHitsInfoElement.appendChild(genreElement);
            divHitsInfoElement.appendChild(songElement);
            divHitsInfoElement.appendChild(authorElement);
            divHitsInfoElement.appendChild(dateElement);

            divHitsInfoElement.appendChild(saveSongButtonElement);
            divHitsInfoElement.appendChild(likeSongButtonElement);
            divHitsInfoElement.appendChild(deleteButtonElement);

            collectionOfSongsContainer.appendChild(divHitsInfoElement);
            inputGenre.value='';
            inputNameOfSong.value='';
            inputAuthor.value='';
            inputDate.value='';
        }
    });
}