function solve() {
    let addBtn= document.querySelector('#add-new button');
    let archiveUl = document.querySelector('#archive ul');
    let clearBtn = document.querySelector('#archive button');
    clearBtn.addEventListener('click', clearAll);
    addBtn.addEventListener('click', addMovie);

    function addMovie(event) {
        event.preventDefault();
        let inputElements = Array.from(document.querySelector('#container').children);

        let name = inputElements[0].value;
        let hallName = inputElements[1].value;
        let price = Number(inputElements[2].value);

        if(name !== '' && hallName !== '' && !Number.isNaN(price)) {
            let movies = document.querySelector('#movies ul');

            let li = createHtmlElement('li', {}, 
                                            createHtmlElement('span', {}, name), 
                                            createHtmlElement('strong', {}, `Hall: ${hallName}`),
                                            createHtmlElement('div', {}, 
                                                createHtmlElement('strong', {}, price.toFixed(2)),
                                                createHtmlElement('input', { placeholder: 'Tickets Sold'}),
                                                createHtmlElement('button', {}, 'Archive')));

            let archiveButton = li.children[2].children[2];
            archiveButton.addEventListener('click', addToArchive);

            movies.appendChild(li);
        }
        
        inputElements[0].value = '';
        inputElements[1].value = '';
        inputElements[2].value = '';
    }

    function addToArchive(event) {
        let li = event.currentTarget.parentElement.parentElement;
        let qty = Number(li.children[2].children[1].value);

        if(!Number.isNaN(qty) && qty >= 0) {
            li.children[1].textContent = `Total amount: ${(Number(li.children[2].children[0].textContent) 
                * Number(li.children[2].children[1].value)).toFixed(2)}`;
            li.removeChild(li.children[2]);
            let deleteBtn = createHtmlElement('button', {}, 'Delete');
            deleteBtn.addEventListener('click', deleteMovie);
            li.appendChild(deleteBtn);
            archiveUl.appendChild(li);
        }   
    }

    function deleteMovie(event) {
        let movie = event.currentTarget.parentElement;
        let ul = event.currentTarget.parentElement.parentElement;
        ul.removeChild(movie);
    }

    function clearAll() {
        archiveUl.textContent = '';
    }

    function createHtmlElement(type, attributes, ...content) {
        const element = document.createElement(type);

        for (let property in attributes) {
            element[property] = attributes[property];
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