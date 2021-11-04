function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const submitBtn = document.querySelector('#submit');
    const refreshBtn = document.querySelector('#refresh');
    
    submitBtn.addEventListener('click', getInput)
    refreshBtn.addEventListener('click', getMessages)

    async function getInput(event) {
        event.preventDefault();

        var authorName = document.querySelector('input[name="author"]');
        var msgText = document.querySelector('input[name="content"]');

        if(authorName.value === ''|| msgText.value === '') {
            return;
        }

        try {
            const msg = {
                author: authorName.value,
                content: msgText.value,
            };
    
            const options = {
                method: 'POST',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(msg)
            }

            const res = await fetch(url, options);

            if(res.ok !== true || res.status !== 200) {
                throw new Error('Bad request');
            }

            authorName.value = '';
            msgText.value = '';

        } catch(error) {
            console.log(error.message);
        }     
    }

    async function getMessages() {
        const messages = document.querySelector('#messages');

        try {
            const res = await fetch(url);

            if(res.ok !== true && res.status !== 200) {
                throw new Error('Bad request');
            }

            const data = await res.json();
            let output = [];

            for(const [key, msgData] of Object.entries(data)) {
                output.push(`${msgData.author}: ${msgData.content}`);
            }

            messages.textContent = output.join('\n');

        } catch(error) {
            console.log(error.message);
        }       
    }
}

attachEvents();