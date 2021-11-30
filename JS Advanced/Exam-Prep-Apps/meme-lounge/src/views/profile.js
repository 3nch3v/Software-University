import { html, getUserData, getByUserId } from '../lib.js';

const profileTemp = (memes, userData) => html`
    <section id="user-profile-page" class="user-profile">
        <article class="user-info">
            <img id="user-avatar-url" alt="user-profile" src="/images/${userData.gender}.png">
            <div class="user-content">
                <p>Username: ${userData.username}</p>
                <p>Email: ${userData.email}</p>
                <p>My memes count: ${memes.length}</p>
            </div>
        </article>

        <h1 id="user-listings-title">User Memes</h1>
        <div class="user-meme-listings">
            ${memes.length > 0 
                ? memes.map(memeCard)
                : html`<p class="no-memes">No memes in database.</p>`
            }
        </div>
    </section>
`;

const memeCard = (meme) => html`
    <div class="user-meme">
         <p class="user-meme-title">J${meme.title}</p>
         <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
         <a class="button" href="/details/${meme._id}">Details</a>
     </div>
`;

export async function profilePage(ctx) {
    const userData = getUserData();
    const memes = await getByUserId();
    ctx.render(profileTemp(memes, userData));
}