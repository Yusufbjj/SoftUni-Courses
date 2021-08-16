function bookShelf(input) {
    let bookshelf = {};

    // iterate all input elements
    for (let line of input) {
        if (line.includes("->")) {
            createShelf(bookshelf, line);
        } else {
            storeBook(bookshelf, line)
        }
    }
    //print result
    let sorted =Object.entries(bookshelf).sort(compareShelf);
    for (let [id,shelf] of sorted) {
        console.log(`${id} ${shelf.genre}: ${shelf.books.length}`);

        let sortedBooks = shelf.books.sort((a,b)=>a.name.localeCompare(b.name))
        for (let book of sortedBooks) {
            console.log(`--> ${book.name}: ${book.author}`);
        }
    }

    function compareShelf(a,b) {
        let countA = a[1].books.length;
        let countB = b[1].books.length;
        return countB-countA;
    }

    function createShelf(bookshelf,line) {
        let [id,genre] = line.split(" -> ");
        if(bookshelf[id]==undefined){
            bookshelf[id] = {
                genre,
                books:[]
            };
        }
    }
    function storeBook(bookshelf,line) {
        let [ name,rest] = line.split(": ");
        let [author,genre] = rest.split(", ");
       
        let shelf = Object.entries(bookshelf).find(([id,b])=>b.genre==genre);
        if(shelf!=undefined){
            shelf[1].books.push({name,author});
        }
    }

}
bookShelf(['1 -> history', '1 -> action', 'Death in Time: Criss Bell, mystery',
    '2 -> mystery', '3 -> sci-fi',
    'Child of Silver: Bruce Rich, mystery',
    'Hurting Secrets: Dustin Bolt, action',
    'Future of Dawn: Aiden Rose, sci-fi',
    'Lions and Rats: Gabe Roads, history', '2 -> romance',
    'Effect of the Void: Shay B, romance',
    'Losing Dreams: Gail Starr, sci-fi',
    'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history'])