function getArticleGenerator(input) {

    let articles = input;

    return () => {
        if (articles.length > 0) {
            let container = document.getElementById('content'); //get element 
            let article = document.createElement('article'); //create article element
            
            let currentText = articles.shift(); // take the first string from the array of articles
            article.innerText = currentText; // assign the string to the article inner text
            container.appendChild(article); //append article to the container element

        }
    }

}
