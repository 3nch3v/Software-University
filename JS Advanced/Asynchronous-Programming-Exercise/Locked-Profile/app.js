async function lockedProfile() {
    const main = document.querySelector('#main');
    
    try{
        const data = await getData();
        let index = 1;

        for(const [id, userData] of Object.entries(data)) {
            main.appendChild(createProfile(id, userData.username, userData.email, userData.age, index));
            index++;
        }
    } catch(error) {
        console.log(error);
    }

    function createProfile(id, username, email, age, index) {
        const showMoreBtn = createHtmlElement('button', {}, 'Show more');
        showMoreBtn.addEventListener('click', showMore);

        const hiddenFieldsDiv = createHtmlElement('div', { id: `user${index}HiddenFields`},
                            createHtmlElement('hr', {}),
                            createHtmlElement('label', {}, 'Email:'),
                            createHtmlElement('input', { type: "email", name: `user${index}Email`, value: `${email}`, disabled: true, readOnly: true}),
                            createHtmlElement('label', {}, 'Age:'),
                            createHtmlElement('input', { type: "email", name: `user${index}Age`, value: `${age}`, disabled: true, readOnly: true}));
        hiddenFieldsDiv.style.display = 'none';

        const profileDiv = createHtmlElement('div', { className: "profile"},
                                createHtmlElement('img', { src: "./iconProfile2.png", className: "userIcon" }),
                                createHtmlElement('label', {}, 'Lock'),
                                createHtmlElement('input', { type: "radio", value: "lock", name: `user${index}Locked`, checked: true}),
                                createHtmlElement('label', {}, 'Unlock'),
                                createHtmlElement('input', { type: "radio", name: `user${index}Locked`, value: "unlock",}),
                                createHtmlElement('br', {}),
                                createHtmlElement('hr', {}),
                                createHtmlElement('label', {}, 'Username'),
                                createHtmlElement('input', { type: "text", name: `user${index}Username`, value: `${username}`, disabled: true, readOnly: true}),
                                hiddenFieldsDiv,
                                showMoreBtn);
        return profileDiv;
    }

    function showMore(e) {
        let btn = e.target;
        let isLocked = btn.parentElement.children[2].checked;
        
        if(!isLocked) {
            let divIdName = btn.parentElement.querySelector('div').id;
            let divElement = document.getElementById(divIdName);

            if(btn.textContent === 'Show more') {       
                divElement.style.display = 'block';
                btn.textContent = 'Hide it';

            } else if(btn.textContent === 'Hide it') {
                divElement.style.display = 'none';
                btn.textContent = 'Show more';
            }
        };
    };

    async function getData() {
        const res = await fetch('http://localhost:3030/jsonstore/advanced/profiles');

        if(res.ok !== true || res.status !== 200) {
            throw new Error('Bad request.');
        }

        const data = await res.json();

        return data;
    };

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