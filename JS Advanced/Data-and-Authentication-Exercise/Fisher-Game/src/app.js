import { checkAuthentication } from './checkAuthentication.js';
import { request } from './postRequest.js';

const catches = document.querySelector('#catches');
const catchesUrl = 'http://localhost:3030/data/catches/';

window.addEventListener('DOMContentLoaded', () => {
    const logoutBtn = document.querySelector('#logout');
    logoutBtn.addEventListener('click', logout);
    const loadBtn = document.querySelector('.load');
    loadBtn.addEventListener('click', loadCatches);
    const addForm = document.querySelector('#addForm');
    addForm.addEventListener('submit', createCatch);
    catches.addEventListener('click', manipulateCatch)
    checkAuthentication();
    loadCatches();
})

async function createCatch(event) {
    event.preventDefault();
    try {
        const user = getUserAuthentication();

        if(user == null) {
            throw new Error('Please Login.');
        }
    
        const catchData = velidateCatchInput(addForm, user.id);
        const res = await request(catchesUrl, catchData, user.token);
        const catchDiv = createCatchHtml(res._id, res.angler, res.weight, res.species, res.location, res.bait, res.captureTime, true);
        catches.appendChild(catchDiv);
        addForm.reset();
    } catch(error) {
        alert(error.message);
    }
}

async function manipulateCatch(event) {
    const btn = event.target;

    if(btn.tagName.toLowerCase() !== 'button') {
        return;
    }

    const url = `${catchesUrl}${btn.id}`
    const catchDiv = btn.parentElement;

    try {
        const res = await fetch(url);

        if(res.ok !== true || res.status !== 200) {
            const error = await res.json();
            throw new Error(error.message);
        }

        const data = await res.json();
        const user = getUserAuthentication();

        if(user.id !== data._ownerId) {
            throw new Error('Unauthorized');
        }

        if(btn.className === 'update') {
            await updateCatch(url, user.token, data, catchDiv);
        } else if(btn.className === 'delete') {
            await deleteCatch(url, user.token);
            catchDiv.remove();
        }

    } catch(error) {
        alert(error.message);
    }
}

async function updateCatch(url, userToken, data, catchDiv) {
    const angler = catchDiv.querySelector('.angler').value;
    const weight = catchDiv.querySelector('.weight').value;
    const species = catchDiv.querySelector('.species').value;
    const location = catchDiv.querySelector('.location').value;
    const bait = catchDiv.querySelector('.bait').value;
    const captureTime = catchDiv.querySelector('.captureTime').value;;

    if(angler === '' 
    || species === '' 
    || location === '' 
    || bait === ''
    || isNaN(parseFloat(weight))
    || !Number.isInteger(parseFloat(captureTime))) {
      throw new Error('Please enter valid data in all input fields.');
    }

    data.angler = angler;
    data.weight = weight;
    data.species = species;
    data.location = location;
    data.bait = bait;
    data.captureTime = captureTime;

   const body = JSON.stringify(data);
    
    const options = {
        method: 'PUT',
        headers: { 
            'Content-Type': 'application/json',
            'X-Authorization': userToken,
            'Content-Length': body.length 
        },
        body: body
    }

   const res = await fetch(url, options);

     if(res.ok !== true) {
        const error = await res.json();
        throw new Error(error.message);
    };
}

async function deleteCatch(url, userToken) {
    const options = {
        method: 'DELETE',
        headers: { 'X-Authorization': userToken }
    };

    const res = await fetch(url, options);

    if(res.ok !== true) {
        const error = await res.json();
        throw new Error(error.message);
    };
}

async function loadCatches() {
    catches.replaceChildren();
    const res = await fetch(catchesUrl);
    const data = await res.json();
    const user = getUserAuthentication();

    data.forEach((c) => {
        let isOwner = true;

        if(!user || user.id !== c._ownerId) {
            isOwner = false;
        }

        catches.appendChild(createCatchHtml(
                                c._id, 
                                c.angler, 
                                c.weight, 
                                c.species, 
                                c.location, 
                                c.bait, 
                                c.captureTime, 
                                isOwner));        
    });       
}

async function logout() {
    const url = 'http://localhost:3030/users/logout';
    try {
        const user = getUserAuthentication();

        if(user == null) {
            throw new Error('You are currently not logged.');
        }

        const options = {
            method: 'GET',
            headers: { 'X-Authorization': user.token }
        }
        
        const res = await fetch(url, options)
    
        if(res.ok !== true || res.status !== 204) {
            throw new Error('Invalid request.');
        }
    
        sessionStorage.clear(); 
        window.location.replace("/src/index.html");

    } catch(error) {
        alert(error.message);
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

function createCatchHtml(id, angler, weight, species, location, bait, captureTime, isOwner) {

    const div = createHtmlElement('div', { className: "catch" },
        createHtmlElement('label', {}, 'Angler'),
        createHtmlElement('input', { type: "text", className: "angler", value: `${angler}`, disabled: (isOwner ? false : true) }),
        createHtmlElement('label', {}, 'Weight'),
        createHtmlElement('input', { type: "text", className: "weight", value: `${weight}`, disabled: (isOwner ? false : true) }),
        createHtmlElement('label', {}, 'Species'),
        createHtmlElement('input', { type: "text", className: "species", value: `${species}`, disabled: (isOwner ? false : true) }),
        createHtmlElement('label', {}, 'Location'),
        createHtmlElement('input', { type: "text", className: "location", value:  `${location}`, disabled: (isOwner ? false : true) }),
        createHtmlElement('label', {}, 'Bait'),
        createHtmlElement('input', { type: "text", className: "bait", value:  `${bait}`, disabled: (isOwner ? false : true) }),
        createHtmlElement('label', {}, 'Capture Time'),
        createHtmlElement('input', { type: "number", className: "captureTime", value:  `${captureTime}`, disabled: (isOwner ? false : true) }),
        createHtmlElement('button', { className:"update", id: `${id}`, disabled: (isOwner ? false : true) }, 'Update'),
        createHtmlElement('button', { className:"delete", id: `${id}`, disabled: (isOwner ? false : true) }, 'Delete'));

    return div;
}

function getUserAuthentication() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if(userData == null) {
        return null;
    }

    const user = {
        id: userData.id,
        token: userData.token
    }; 

    return user;
}

function velidateCatchInput(form, userId) {
    const data = new FormData(form);
    const angler = data.get('angler').trim();
    const weight = data.get('weight').trim();;
    const species = data.get('species').trim();
    const location = data.get('location').trim();
    const bait = data.get('bait').trim();
    const captureTime = data.get('captureTime').trim();;

    if(angler === '' 
      || weight === ''
      || species === '' 
      || location === '' 
      || bait === ''
      || captureTime === ''
      || isNaN(parseFloat(weight)
      || !Number.isInteger(parseFloat(captureTime)))) {
        throw new Error('Please fill out all fields with valid data.');
      }

    const catchData = {
        _ownerId: userId,
        angler: angler, 
        weight: weight,
        species: species,
        location: location,
        bait: bait,
        captureTime: captureTime
    }

    return catchData;
}