import { showSection, createHtmlElement } from "./dom.js";
import { request } from "./makeRequest.js";

const postsUrl = 'http://localhost:3030/jsonstore/collections/myboard/posts/';

const section = document.getElementById('topic-home');
const topicTitle = section.querySelector('.topic-title');
const publicBtn = section.querySelector('.public');
const cancel = section.querySelector('.cancel');
const form = section.querySelector('form');
section.remove();
publicBtn.addEventListener('click', postTopic);
cancel.addEventListener('click', clearForm);

export function showAllTopicsPage() {
    showSection(section);
    topicTitle.replaceChildren();
    loadTopics();
}

async function loadTopics() {
    try {
        const data = await request(postsUrl, 'GET');
        Object.values(data).forEach(t => {
            const topic = createTopicHtml(t);
            topicTitle.appendChild(topic);
        })

    } catch(err) {
        console.error(err.message);
    }
}

async function postTopic(event) {
    event.preventDefault();

    const input = new FormData(form);
    const title =input.get('topicName').trim();
    const username =input.get('username').trim();
    const postText =input.get('postText').trim();

    if(title === ''
    || username === ''
    || postText === '') {
      alert('Please fill in all the required fields.');
      return;
    }
    
    try {
        const topic = {
            title: title,
            username: username,
            postText: postText,
            date: new Date().toLocaleString()
        };

        form.reset();
        
        const data = await request(postsUrl, 'POST', topic);
        const newTopic = createTopicHtml(data);
        topicTitle.appendChild(newTopic);
        
    } catch(err) {
        console.error(err.message);
    }
}

function createTopicHtml(topic) {
    const newTopic = createHtmlElement('div', { className: "topic-container"},
                        createHtmlElement('div', { className: "topic-name-wrapper"},
                            createHtmlElement('div', { className: "topic-name"},
                                createHtmlElement('a', { href:"#", className: "normal", id: `${topic._id}`},
                                    createHtmlElement('h2', { }, `${topic.title}`)
                                ),
                                createHtmlElement('div', { className: "columns"},
                                    createHtmlElement('div', {},  
                                        createHtmlElement('p', {}, 'Date:', 
                                            createHtmlElement('time', {}, `${topic.date}`)
                                        ),
                                        createHtmlElement('div', { className: 'nick-name'}, 
                                            createHtmlElement('p', {}, 'Username: ', 
                                                createHtmlElement('span', {}, `${topic.username}`)
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    );

    return newTopic;         
}

function clearForm(event) {
    event.preventDefault();
    form.reset();
}

