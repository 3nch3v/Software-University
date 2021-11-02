function attachEvents() {
    const btnLoadPosts = document.querySelector('#btnLoadPosts');
    const btnViewPost = document.querySelector('#btnViewPost');
    const selectPost = document.querySelector('#posts');

    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', viewPost);

    async function viewPost() {
        const postTitle = document.querySelector('#post-title');
        const postBody = document.querySelector('#post-body');
        const postComments = document.querySelector('#post-comments');

        postTitle.textContent = '';
        postBody.textContent = '';
        postComments.replaceChildren();

        const postId = selectPost.value;

        try {
            const [post, comments] = await Promise.all([getData(`http://localhost:3030/jsonstore/blog/posts/${postId}`), 
                                                        getData('http://localhost:3030/jsonstore/blog/comments')]);     
            postTitle.textContent = post.title;
            postBody.textContent = post.body;

            for(const [id, commentData] of Object.entries(comments)) {
                if(commentData.postId === postId) {
                    const li = createHtmlElement('li', { id: id }, `${commentData.text}`)
                    postComments.appendChild(li);
                }
            }
        } catch(error) {
            console.log(error);
        }
    }

    async function loadPosts() {
        try {
            const posts = await getData('http://localhost:3030/jsonstore/blog/posts');

            for(const [postId, postInfo] of Object.entries(posts)) {
                const option = createHtmlElement('option', { value: `${postId}`}, `${postInfo.title}`)
                selectPost.appendChild(option);
            }
        } catch(error) {
            console.log(error);
        }
    }

    async function getData(url) {
        const res = await fetch(url);

        if(res.ok !== true || res.status !== 200) {
            throw new Error('Bad request.');
        }

        const data = await res.json();

        return data;
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

attachEvents();