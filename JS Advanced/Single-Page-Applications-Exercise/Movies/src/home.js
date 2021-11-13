import { showSection, createHtmlElement} from './dom.js';
import { request } from './makeRequest.js';
import { showDetails } from './details.js';
import { create } from './createMovie.js';
import { getUser } from './getUser.js';

const url = 'http://localhost:3030/data/movies';

const section = document.querySelector('#full-home-page');
section.remove();
const movisContainer = section.querySelector('.card-deck.d-flex.justify-content-center');
movisContainer.addEventListener('click', onClick);

const welcome = document.querySelector('#welcome');
const logoutBtn = document.querySelector('#logoutBtn');
const loginBtn = document.querySelector('#loginBtn');
const registerBtn = document.querySelector('#registerBtn');

const addMovieBtn = section.querySelector('#addMovieBtn');
addMovieBtn.addEventListener('click', (event) => {
    event.preventDefault();
    create();
});

export async function showHome() {
    showSection(section);
    movisContainer.replaceChildren(createHtmlElement('p', {}, 'Loading...'));
    
    const user = getUser();

    if(user) {
        welcome.style.display = 'block';
        welcome.textContent = `Welcome, ${user.email}`;
        logoutBtn.style.display  = 'block';
        addMovieBtn.style.display  = '';
        loginBtn.style.display  = 'none';
        registerBtn.style.display  = 'none';
    } else {
        welcome.style.display  = 'none';
        logoutBtn.style.display  = 'none';
        addMovieBtn.style.display  = 'none';
        loginBtn.style.display  = 'block';
        registerBtn.style.display  = 'block';
    }

    try {
        const data = await request(url, 'GET'); 
        movisContainer.replaceChildren(...data.map(createMovieHtml));
    } catch(err) {
        console.log(err.message);
    }
}

function createMovieHtml(movie) {
    const user = getUser();

    const details = createHtmlElement('div', { className:"card-footer" },
                            createHtmlElement('a', { href: "#/details/", id: movie._id },
                                createHtmlElement('button', { type:"button", className: "btn btn-info" }, 'Details')
                            )
                    );

    const detailsBtn = user ? details : '';

    const movieHthml = createHtmlElement('div', { className:"card mb-4" },
                            createHtmlElement('img', { className:"card-img-top", src: `${movie.img}`, alt: "Card image cap", width:"400" }),
                                createHtmlElement('div', { className:"card-body" },
                                    createHtmlElement('h4', { className:"card-title" }, `${movie.title}`)
                                ),
                            detailsBtn
                        );

    return  movieHthml;
}

{/* <div class="card mb-4">
     <img class="card-img-top" src="https://pbs.twimg.com/media/ETINgKwWAAAyA4r.jpg" alt="Card image cap" width="400">
     <div class="card-body">
         <h4 class="card-title">Wonder Woman 1984</h4>
     </div>
     <div class="card-footer">
         <a href="#/details/6lOxMFSMkML09wux6sAF">
             <button type="button" class="btn btn-info">Details</button>
         </a>
     </div>

</div> */}

function onClick(event) {
    event.preventDefault();
    let currTarget = event.target;

    if(currTarget.tagName == 'BUTTON') {
        const movieId = currTarget.parentElement.id;
        showDetails(movieId);
    }
};