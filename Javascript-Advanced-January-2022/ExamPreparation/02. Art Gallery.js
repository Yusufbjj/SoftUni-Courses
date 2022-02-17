class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            "picture": 200,
            "photo": 50,
            "item": 250
        };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {

        articleModel = articleModel.toLowerCase();
        let objArticle = {};

        if (!Object.keys(this.possibleArticles).includes(articleModel)) {
            throw new Error("This article model is not included in this gallery!");
        }

        objArticle = {
            articleModel,
            articleName,
            quantity: Number(quantity)
        }

        if (this.listOfArticles.length === 0) {
            this.listOfArticles.push(objArticle)
        } else {
            for (let ele of this.listOfArticles) {
                if (ele.articleName == articleName && ele.articleModel == articleModel) {
                    ele.quantity += quantity;
                    break;
                } else {
                    this.listOfArticles.push(objArticle)
                    break;
                }
            }
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {

        let guest = {};

        for (let guest of this.guests) {
            if (guest.guestName === guestName) {
                throw new Error(`${guestName} has already been invited.`);
            }
        }

        switch (personality) {
            case "Vip": guest = { guestName, points: 500, purchaseArticle: 0 };
                break;
            case "Middle": guest = { guestName, points: 250, purchaseArticle: 0 };
                break;
            default: guest = { guestName, points: 50 , purchaseArticle: 0 };
                break;
        }

        this.guests.push(guest);

        return `You have successfully invited ${guestName}!`;

    }

    buyArticle(articleModel, articleName, guestName) {

        let isNotFound = true;
        let guestNotFound = true;
        let neededArticleName;
        let neededGuest;

        for (let article of this.listOfArticles) {
            if (article.articleName === articleName && article.articleModel.toLowerCase() === articleModel) {

                neededArticleName = article;
                isNotFound = false;
                break;

            }
        }

        if (isNotFound) {
            throw new Error("This article is not found.");
        }

        if (neededArticleName.quantity === 0) {
            return `The ${articleName} is not available.`;
        }

        for (let guest of this.guests) {
            if (guest.guestName === guestName) {
                neededGuest = guest;
                guestNotFound = false;
                break;
            }
        }

        if (guestNotFound) {
            return "This guest is not invited.";
        }

        if (neededGuest.points >= this.possibleArticles[articleModel]) {
            neededGuest.points -= this.possibleArticles[articleModel];
            neededGuest.purchaseArticle++;
            neededArticleName.quantity--;

        } else {
            return "You need to more points to purchase the article.";
        }

        return `${guestName} successfully purchased the article worth ${this.possibleArticles[articleModel]} points.`
    }

    showGalleryInfo(criteria) {

        let result = '';

        switch (criteria) {
            case "article":
                result += "Articles information:\n";

                for (let ele of this.listOfArticles) {
                    result += `${ele.articleModel} - ${ele.articleName} - ${ele.quantity}` + '\n';
                }

                break;
            case "guest":
                result += "Guests information:" + '\n';

                for (let guest of this.guests) {
                    result += `${guest.guestName} - ${guest.purchaseArticle}` + '\n';
                }
                break;
            default:
                break;
        }
        return result.trim();
    }
}
let art = new ArtGallery("Curtis Mayfield");
console.log(art.addArticle('picture', 'Mona Liza', 3));
console.log(art.addArticle('Item', 'Ancient vase', 2));
console.log(art.addArticle('picture', 'Mona Liza', 1));
console.log(art.inviteGuest('John', 'Vip'));
console.log(art.inviteGuest('Peter', 'Middle'));
console.log(art.buyArticle('picture', 'Mona Liza', 'John'));
console.log(art.buyArticle('item', 'Ancient vase', 'Peter'));
console.log(art.showGalleryInfo('article'));
console.log(art.showGalleryInfo('guest'));










