function addItem() {
    let menu = document.querySelector('#menu');
    let text = document.querySelector('#newItemText');
    let value = document.querySelector('#newItemValue');

    let newOptionElement = document.createElement('option');
    
    newOptionElement.value = value.value;
    newOptionElement.textContent = text.value; 

    menu.appendChild(newOptionElement);

    text.value = '';
    value.value = '';
}