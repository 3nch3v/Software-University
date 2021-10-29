window.addEventListener('load', solve);

function solve() {
    let genre = document.querySelector('#genre');
    let name = document.querySelector('#name');
    let author = document.querySelector('#author');
    let date = document.querySelector('#date');

    let addBtn = document.querySelector('#add-btn');
    addBtn.addEventListener('click', addSong);

    function addSong(event) {
        event.preventDefault();

        if(genre.value === ''
          || name.value === ''
          || author.value === ''
          || date.value === ''){
            return;
        }

        let allHits = document.querySelector('.all-hits-container');

        let img = createHtmlElement('img', {});
        img.setAttribute('src', './static/img/img.png');

        let saveBtn = createHtmlElement('button', {}, `Save song`);
        saveBtn.classList.add("save-btn");
        saveBtn.addEventListener('click', saveSong)

        let likeBtn = createHtmlElement('button', {}, `Like song`);
        likeBtn.classList.add("like-btn");
        likeBtn.addEventListener('click', likeSong)

        let deleteBtn = createHtmlElement('button', {}, `Delete`);
        deleteBtn.classList.add("delete-btn");
        deleteBtn.addEventListener('click', deleteSong)

        let div = createHtmlElement('div', {},
                    img,
                    createHtmlElement('h2', {}, `Genre: ${genre.value}`),
                    createHtmlElement('h2', {}, `Name: ${name.value}`),
                    createHtmlElement('h2', {}, `Author: ${author.value}`),
                    createHtmlElement('h3', {}, `Date: ${date.value}`),
                    saveBtn,
                    likeBtn,
                    deleteBtn);

        div.classList.add("hits-info");

        allHits.appendChild(div);

        genre.value = '';
        name.value = '';
        author.value = '';
        date.value = ''; 

        function likeSong() {
            let likes = document.querySelector('.likes p');
            let currLikesCount = Number(likes.textContent.split(' ')[2]);
            likes.textContent = `Total Likes: ${++currLikesCount}`;

            likeBtn.disabled = true;            
        }

        function saveSong() {
            let saved = document.querySelector('.saved-container');

            div.removeChild(div.querySelector('.save-btn'));
            div.removeChild(div.querySelector('.like-btn'));

            saved.appendChild(div);
        }

        function deleteSong(event) {
            let currSong = event.currentTarget.parentElement;
            currSong.remove();
        }
    }

    function createHtmlElement(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }
        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }  
}