import { showSection, createHtmlElement } from "./dom.js";
import { request } from "./makeRequest.js";

const section = document.querySelector('#topic-main');
const userComments = section.querySelector('#comments');
const form = section.querySelector('form');
section.remove();

const commentsUrl = 'http://localhost:3030/jsonstore/collections/myboard/comments';

export async function showTopic(topicId) {
    const url = `http://localhost:3030/jsonstore/collections/myboard/posts/${topicId}`;
    const topic = await request(url, 'GET'); 

    const title = section.querySelector('h2');
    const createdBy = section.querySelector('#created-by');
    const createdOn = section.querySelector('#created-on');
    const postContent = section.querySelector('.post-content');
    
    title.textContent = topic.title;
    createdBy.textContent = topic.username;
    createdOn.textContent = topic.date;
    postContent.textContent = topic.postText;

    showSection(section);

    loadComments(topicId);
    form.querySelector('button').addEventListener('click', commentTopic);
    form.dataset.id = topicId;
}

async function commentTopic(event) {
    event.preventDefault();
    const input = new FormData(form);
    const commentText = input.get('postText').trim();
    const username = input.get('username').trim();

    if(commentText == '' || username == '') {
        alert('Please fill in all the required fields.');
        return;
    }

    const comment = {
        username: username,
        body: commentText,
        date: new Date().toLocaleString(),
        topicId: form.dataset.id
    }

    form.reset();

    const data = await request(commentsUrl, 'POST', comment);

    const commentHtml = createComment(data.username, data.date, data.body);
    userComments.appendChild(commentHtml);
};

async function loadComments(topicId) {
    userComments.replaceChildren();
    const data = await request(commentsUrl, 'GET');
    const topicComments = Object
                                .values(data)
                                .filter(t => t.topicId === topicId);

    topicComments.forEach(comment => {
        const commentHtml = createComment(comment.username, comment.date, comment.body);
        userComments.appendChild(commentHtml);
    });
}

function createComment(username, date, comment) {
    
    const commentHtml = createHtmlElement('div', { id: "user-comment"},
                            createHtmlElement('div', { className: "topic-name-wrapper"},
                                createHtmlElement('div', { className: "topic-name"},
                                    createHtmlElement('p', {}, 
                                        createHtmlElement('strong', {}, `${username}`),
                                        ' commented on ',
                                        createHtmlElement('time', {}, `${date}`)
                                    ),
                                    createHtmlElement('div', { className: "post-content"},
                                        createHtmlElement('p', {}, `${comment}`)
                                    )
                                )
                            )
                        );

    return commentHtml;
};