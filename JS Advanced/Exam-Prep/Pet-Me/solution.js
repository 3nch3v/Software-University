function solve() {
    let inputFields = document.querySelectorAll('#container input');
    let adoptionUl = document.querySelector('#adoption ul');
    let adoptedUl = document.querySelector('#adopted ul');

    let btn = document.querySelector('#container button');
    btn.addEventListener('click', addPet);

    let name = inputFields[0];
    let age = inputFields[1];
    let kind = inputFields[2];
    let owner = inputFields[3];

    function addPet(event) {
        event.preventDefault();

        if(name.value == '' 
           || age.value == ''
           || isNaN(age.value) 
           || kind.value == '' 
           || owner.value == '') {
            return;
        }
 
        let p = e('p', {},
                    e('strong', {}, `${name.value}`),
                    ' is a ',
                    e('strong', {}, `${age.value}`),
                    ' year old ',
                    e('strong', {}, `${kind.value}`));

        let span = e('span', {}, `Owner: ${owner.value}`);
        let contactButton = e('button', {}, 'Contact with owner');

        contactButton.addEventListener('click', contact);

        let pet = e('li', {}, p, span, contactButton);

        adoptionUl.appendChild(pet);

        name.value = '';
        age.value = '';
        kind.value = '';
        owner.value = '';

        function contact() {
            let takeItBtn = e('button', {}, 'Yes! I take it!');
            let newOwner = e('input', { placeholder: 'Enter your names'});

            takeItBtn.addEventListener('click', adopt.bind(null, newOwner, pet))

            let div = e('div', {}, newOwner, takeItBtn);

            contactButton.remove();

            pet.appendChild(div);
        }
    }

    function adopt(newOwner, pet) {
        if(newOwner.value == '') {
            return;
        }

        pet.querySelector('div').remove();
        pet.querySelector('span').textContent = `New Owner: ${newOwner.value}`;

        let ckeckBtn = e('button', {}, 'Checked');
        ckeckBtn.addEventListener('click', check);

        pet.appendChild(ckeckBtn);
        adoptedUl.appendChild(pet);
    }

    function check(e) {
        e.target.parentElement.remove();
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }
        for (let item of content) {
            if (typeof item == 'string' 
               || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}

