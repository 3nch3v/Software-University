import { showAllTopicsPage } from './showAllTopics.js';
import { showTopic } from './showTopic.js';

showAllTopicsPage();

document.querySelector('#home').addEventListener('click', showAllTopicsPage);
document.querySelector('.topic-title').addEventListener('click', loadTopic);

async function loadTopic(event) {
    const currTarget = event.target;
    
    if(currTarget.tagName == 'H2') {
        showTopic(currTarget.parentElement.id);
    }
};