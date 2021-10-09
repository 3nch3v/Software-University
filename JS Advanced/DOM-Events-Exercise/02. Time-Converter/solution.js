function attachEventsListeners() {
    let divElements = document.getElementsByTagName('div');

    for(let i = 0; i < divElements.length; i++)
    {
    let btn = divElements[i].children[2];
        btn.addEventListener('click', convert);
    }

    function convert(e) {
        let value = e.target.parentElement.children[1].value;
        let inputId = e.target.parentElement.children[1].id;

        let calculatedValues = calculateValues(inputId, value);

        document.querySelector('#days').value = calculatedValues[0];
        document.querySelector('#hours').value = calculatedValues[1]; 
        document.querySelector('#minutes').value = calculatedValues[2];
        document.querySelector('#seconds').value = calculatedValues[3];
    }

    function calculateValues(id, value) {
        let values = [];

        if(id == 'days') {
            values.push(value)
            values.push(value * 24)
            values.push(value  * 24 * 60)
            values.push(value * 24 * 60 * 60)
        } else if(id == 'hours') {
            values.push(value / 24)
            values.push(value)
            values.push(value * 60)
            values.push(value * 60 * 60)
        } else if(id == 'minutes') {
            values.push(value / 24 / 60)
            values.push(value / 60)
            values.push(value)
            values.push(value * 60)
         } else if(id == 'seconds') {
            values.push(value / 24 / 60 / 60)
            values.push(value / 60 / 60)
            values.push(value / 60)
            values.push(value)
        }

        return values;
    };
};