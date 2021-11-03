function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/books/';

    const loadBooksBtn = document.querySelector('#loadBooks');
    const tbody = document.querySelector('table tbody')
    const form = document.querySelector('form');
    const formTitle = document.querySelector('form h3');

    loadBooksBtn.addEventListener('click', loadBooks);
    form.addEventListener('submit', submitData)

    async function loadBooks() {
        tbody.replaceChildren();

        try {
            const res = await fetch(url);

            if(res.ok !== true || res.status !== 200) {
                throw new Error('Bad request.');
            }

            const data = await res.json();

            for(const [id, bookInfo] of Object.entries(data)) {
                const editBtn = createHtmlElement('button', {}, 'Edit');
                const deleteBtn = createHtmlElement('button', {}, 'Delete');
                editBtn.addEventListener('click', updateBook);
                deleteBtn.addEventListener('click', deleteBook);

                const tr = createHtmlElement('tr', { id: id},
                                createHtmlElement('td', {}, `${bookInfo.title}`),
                                createHtmlElement('td', {}, `${bookInfo.author}`),
                                createHtmlElement('td', {},
                                    editBtn,
                                    deleteBtn));
                 tbody.appendChild(tr);
            }
        } catch(error) {
            console.log(error);
        }
    }

    async function submitData(e) {
        e.preventDefault();

        const data = new FormData(form);
        const entries = [...data.entries()];

        const title = entries[0][1].trim();
        const author = entries[1][1].trim();

        if(title === '' || author === '') {
            return;
        }

        try {
            const book = {
                title: title,
                author: author,
            };

            const options = {
                method: 'POST',
                headers: { 'Content-type': 'application/json'},
                body: JSON.stringify(book)
            };

            const isEdit = formTitle.textContent === 'Edit FORM';
            let bookId = '';

            if(isEdit) {
                options.method = 'PUT'
                bookId = formTitle.id;
                formTitle.removeAttribute('id');
            }

            const urlRequest = bookId == '' ? url : (url + bookId);

            const res = await fetch(urlRequest, options);

            if(res.ok !== true || res.status !== 200) {
                throw new Error('Bad request.');
            }

            await loadBooks();
            
            form.reset();

            if(isEdit) {
                formTitle.textContent = 'FORM';
            }
        } catch(error) {
            console.log(error);
        }
    }

    async function updateBook(e) {
        const bookId = e.currentTarget.parentElement.parentElement.id;

        try {
            const book = await getById(bookId);

            document.querySelector('input[name="title"]').value = book.title;
            document.querySelector('input[name="author"]').value = book.author;
            formTitle.textContent = 'Edit FORM';
            formTitle.id = bookId;
            
        } catch(error) {
            console.log(error);
        }
    }

    async function getById(bookId) {
        const res = await fetch(url + bookId);

        if(res.ok !== true || res.status !== 200) {
            throw new Error('Bad request.');
        }

        const book = await res.json();

        return book;
    }

    async function deleteBook(e) {
        const bookId = e.currentTarget.parentElement.parentElement.id;

        try {
            const res = await fetch(url + bookId, { method: 'DELETE' });

            if(res.ok !== true || res.status !== 200) {
                throw new Error('Bad request.');
            }

            await loadBooks();

        } catch(error) {
            console.log(error);
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

solve();