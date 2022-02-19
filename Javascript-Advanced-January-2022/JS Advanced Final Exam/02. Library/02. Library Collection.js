class LibraryCollection {
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length >= this.capacity) {
            throw new Error("Not enough space in the collection.");
        } else {
            let booksObj = {
                bookName,
                bookAuthor,
                payed: false
            }
            this.books.push(booksObj);
            return `The ${bookName}, with an author ${bookAuthor}, collect.`;
        }
    }

    payBook(bookName) {
        let bookNeeded = this.books.find(b => b.bookName === bookName);
        if (!bookNeeded) {
            throw new Error(`${bookName} is not in the collection.`);
        } else {
            if (bookNeeded.payed) {
                throw new Error(`${bookName} has already been paid.`);
            } else {
                bookNeeded.payed = true;
            }

            return `${bookName} has been successfully paid.`;
        }
    }

    removeBook(bookName) {
        let bookNeeded = this.books.find(b => b.bookName === bookName);
        if (!bookNeeded) {
            throw new Error(`The book, you're looking for, is not found.`);
        } else {
            if (!bookNeeded.payed) {
                throw new Error(`${bookName} need to be paid before removing from the collection.`);
            } else {
                let index = this.books.indexOf(bookNeeded);
                this.books.splice(index, 1);
            }

            return `${bookName} remove from the collection.`;
        }
    }

    getStatistics(bookAuthor) {
        let result = '';

        if (!bookAuthor) {
            let emptySlots = this.capacity - this.books.length;
            result += `The book collection has ${emptySlots} empty spots left.\n`;
            for (let ele of this.books.sort((a, b) => a.bookName - b.bookName)) {
                let paidOrNot = ele.payed ? 'Has Paid' : 'Not Paid';
                result += `${ele.bookName} == ${ele.bookAuthor} - ${paidOrNot}.\n`;
            }
        } else {
            let neededAuthor = this.books.find(a => a.bookAuthor === bookAuthor);
            if (!neededAuthor) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            } else {
                let sameAuthorBooks = this.books.filter(a => a.bookAuthor === bookAuthor);
                for (let author of sameAuthorBooks) {
                    let paidOrNot = author.payed ? 'Has Paid' : 'Not Paid';
                    result += `${author.bookName} == ${author.bookAuthor} - ${paidOrNot}.\n`;
                }

            }
        }

        return result.trimEnd();
    }
}
const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());



