async function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/phonebook/';

    const phonebookUl = document.querySelector('#phonebook');
    const btnLoad = document.querySelector('#btnLoad');
    btnLoad.addEventListener('click', getPhonebook);
    const btnCreate = document.querySelector('#btnCreate');
    btnCreate.addEventListener('click', createRecord);

    async function getPhonebook() {
        try{
            const res = await fetch(url);

            if(res.ok !== true || res.status !== 200) {
                throw new Error("Bad request.");
            }

            phonebookUl.replaceChildren();
            const data = await res.json();

            for(const [id, phoneData] of Object.entries(data)) {
                const li = createPhoneLi(phoneData.person, phoneData.phone, id) 
                phonebookUl.appendChild(li);
            }
        } catch(error) {
            console.log(error);
        }
    }
    
    async function deleteRecord(e) {
        const phone = e.currentTarget.parentElement;

        try{
            const res = await fetch(url + phone.id, {
                method: 'DELETE'
              });
            
            if(res.ok !== true || res.status !== 200){
                throw new Error('Bad request.')
            }  

            phonebookUl.removeChild(phone)

        } catch(error) {
            console.log(error)
        }
    }

    async function createRecord() {
        const personInput = document.querySelector('#person');
        const phoneInput = document.querySelector('#phone');
        const person = personInput.value.trim();
        const phone = phoneInput.value.trim();

        if(person === '' || phone === '') {
            return;
        }

        const newRecord = {
            person: person,
            phone: phone
        }
          
        const options = {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(newRecord)
        }

        try{
            const res = await fetch(url, options)
            if(res.ok !== true || res.status !== 200){
                throw new Error('Bad request.')
            }

            await getPhonebook();

            personInput.value = '';
            phoneInput.value = '';

        } catch(error){
            console.log(error)
        }
    }

    function createPhoneLi(person, phone, id) {
        const deleteBtn = document.createElement('button'); 
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deleteRecord);
        
        const li = document.createElement('li');
        li.textContent = `${person}: ${phone}`;
        li.id = id;
        li.appendChild(deleteBtn);

        return li;
    }
}

attachEvents();