import { showSection} from './dom.js';
import { getUser } from './getUser.js';
import { request } from './makeRequest.js';
import { showHome } from './home.js';

const addMovie = document.querySelector('#add-movie');
addMovie.remove();
const form = addMovie.querySelector('form')

export async function create() {
    showSection(addMovie);
    form.addEventListener('submit', onSubmit)
}

async function onSubmit(event) {
    event.preventDefault();
    const url = 'http://localhost:3030/data/movies';

    try {
        const user = getUser();

        if(!user) {
            throw new Error('Please log in or sign in.');
        }

        const input = new FormData(form);
        const title = input.get('title').trim();
        const description = input.get('description').trim();
        const imageUrl = input.get('imageUrl').trim();
    
        if(title === '' 
          || description === '' 
          || imageUrl === '') {
            alert('Please fill out all fields.');
            return;
        }

        const movie = {
            _ownerId: user.id,
            title: title,
            description: description,
            img: imageUrl,
        }

        const res = await request(url, 'POST', movie, user.token)
        form.reset();
        showHome();

    } catch(error) {
        alert(error.message);
        console.error(error.message);
    }
}