import { showSection, createHtmlElement} from './dom.js';
import { request } from './makeRequest.js';
import { getUser } from './getUser.js';
import { showEdit } from './editMovie.js';
import { showHome } from './home.js';

const section = document.querySelector('#movie-example');
section.remove();
const url = 'http://localhost:3030/data/movies/';

const likesCount = section.querySelector('#likesCount');
const deleteBtn = section.querySelector('#deleteBtn');
const editBtn = section.querySelector('#editBtn');
const likeBtn = section.querySelector('#likeBtn');
const movieId = section.querySelector('#movieId'); 

hideButtons();

export async function showDetails(id) {
    const loadingMessage = createHtmlElement('p', {}, 'Loading...');
    showSection(loadingMessage);

    const user = getUser();

    try {
        const movieInfo = await request(url + id, 'GET');

        movieId.dataset.movieId = `${id}`;
        section.querySelector('h1').textContent = `Movie title: ${movieInfo.title}` ;
        section.querySelector('.img-thumbnail').src = movieInfo.img;
        section.querySelector('p').textContent = movieInfo.description;

        if(user.id !== movieInfo._ownerId) {
            hideButtons();

            const userLikesForMovieUrl = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${user.id}%22`;
            const userLikes = await request(userLikesForMovieUrl, 'GET');
           
            if(userLikes.length > 0) {
                showMovieLikes(id);
            } else {
                likeBtn.style.display = '';
                likeBtn.addEventListener('click', likeMovie);
            }

        } else if(user.id === movieInfo._ownerId) {
            deleteBtn.style.display = '';
            deleteBtn.addEventListener('click', deleteMovie);
            editBtn.style.display = '';
            editBtn.addEventListener('click', editMovie);
            likeBtn.style.display = 'none';
            showMovieLikes(id);
        }

        showSection(section)

    } catch(err) {
        console.log(err.message);
    }
};

async function deleteMovie(event) {
    event.preventDefault();
    const user = getUser();
    const id = event.target.parentElement.dataset.movieId;
    const deleteUrl = url + id;

    try {
        const res = await request(deleteUrl, 'DELETE', null, user.token);
        showHome();
    } catch(err) {
        console.error(err.message);
    }
}

function editMovie(event) {
    event.preventDefault();
    const id = event.target.parentElement.dataset.movieId;
    showEdit(id);
}

async function likeMovie(event) {
    event.preventDefault();
    const id = event.target.parentElement.dataset.movieId;
    const user = getUser();

    try {
        const url = 'http://localhost:3030/data/likes';
        const movie = {
            movieId: id
        }

        const res = await request(url, 'POST', movie, user.token);
        likeBtn.style.display = 'none';
        showMovieLikes(id);

    } catch(err) {
        console.error(err.message);
    }

}

async function showMovieLikes(id) {
    const likesUrl = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`;
    const likes = await request(likesUrl, 'GET');
    likesCount.textContent = `Liked ${likes}`;
    likesCount.style.display = '';
}

function hideButtons() {
    deleteBtn.style.display = 'none';
    editBtn.style.display = 'none';
    likeBtn.style.display = 'none';
    likesCount.style.display = 'none';
}