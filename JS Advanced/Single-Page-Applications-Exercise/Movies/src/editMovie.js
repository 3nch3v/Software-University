import { showSection } from './dom.js';
import { getUser } from './getUser.js';
import { showDetails } from './details.js';
import { request } from './makeRequest.js';

const section = document.querySelector('#edit-movie');
const form = section.querySelector('form');

section.remove();

let url = 'http://localhost:3030/data/movies/';
let movieId = '';
let movieUrl = '';

export async function showEdit(id) {
    showSection(section);

    movieId = id;
    movieUrl = url + id;

    try {
        const title = form.querySelector('input[name="title"]');
        const description = form.querySelector('textarea[name="description"]');
        const img = form.querySelector('input[name="imageUrl"]');
        
        const movie = await request(movieUrl, 'GET');

        title.value = movie.title;
        description.value = movie.description;
        img.value = movie.img;

        form.addEventListener('submit', editMovie);

    } catch(err) {
        alert(err.message);
        console.error(err.message);
    }
}

async function editMovie(event) {
    event.preventDefault();

    try {
        const user = getUser();
        const data = new FormData(form);
        const title = data.get('title').trim();
        const description = data.get('description').trim();
        const imageUrl = data.get('imageUrl').trim();
    
        if(title === '' 
          || description === '' 
          || imageUrl === '') {
            alert('Please fill out all fields.');
            return;
        }

        const movie = {
            title: title,
            description: description,
            img: imageUrl
        }
        
        const res = await request(movieUrl, 'PUT', movie, user.token);

        showDetails(movieId);

    } catch(err) {
        alert(err.message);
        console.error(err.message);
    }
};