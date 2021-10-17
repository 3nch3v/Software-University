function getArticleGenerator(articles) {
    let index = 0;

    function schowNext() {
        if(index < articles.length) {
            let div = document.querySelector('#content');
            let article = document.createElement('article');
            article.textContent = articles[index];
            div.appendChild(article)

            index++;
        }
    } 
    
    return schowNext;
}
