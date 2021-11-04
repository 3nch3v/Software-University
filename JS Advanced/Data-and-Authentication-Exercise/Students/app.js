function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const form = document.querySelector('#form');
    form.addEventListener('submit', createStudent);

    async function createStudent(e) {
        e.preventDefault();

        const data = new FormData(form);
        const entries = [...data.entries()];

        const firstName = entries[0][1].trim();
        const lastName = entries[1][1].trim();
        const facultyNumber = Number(entries[2][1].trim());
        const grade = Number(entries[3][1].trim());

        if(firstName === '' 
          || lastName === ''
          || entries[2][1].trim() === ''
          || entries[3][1].trim() === ''
          || !Number.isInteger(facultyNumber)
          || isNaN(grade)) {
            return;
        }

        try {
            const student = {
                firstName: firstName,
                lastName: lastName,
                facultyNumber: facultyNumber,
                grade: grade
            };
    
            const options = {
                method: 'POST',
                headers: { 'Content-type': 'application/json'},
                body: JSON.stringify(student)
            };
    
            const res = await fetch(url, options);

            if(res.ok !== true || res.status !== 200) {
                throw new Error('Bad request.');
            }

            await loadStudents();
            form.reset();

        } catch(error) {
            console.log(error.message);
        }
    }

    async function loadStudents() {
        const tableBody = document.querySelector('#results tbody');
        tableBody.replaceChildren();

        try {
            const res = await fetch(url);

            if(res.ok !== true || res.status !== 200) {
                throw new Error('Bad request.');
            }

            const data = await res.json();

            for(const [id, student] of Object.entries(data)) {          
                const tr = createHtmlElement('tr', {},
                                createHtmlElement('td', {}, `${student.firstName}`),
                                createHtmlElement('td', {}, `${student.lastName}`),
                                createHtmlElement('td', {}, `${student.facultyNumber}`),
                                createHtmlElement('td', {}, `${student.grade.toFixed(2)}`));
                tableBody.appendChild(tr);
            }
        } catch(error) {
            console.log(error.message);
        }
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

solve();