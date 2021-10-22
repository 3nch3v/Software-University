window.addEventListener('load', solve);

function solve() {
    let form = document.querySelector('form');

    let model = form.querySelector('#model');
    let year = form.querySelector('#year');
    let description = form.querySelector('#description');
    let price = form.querySelector('#price');

    let addBtn = document.querySelector('#add');
    addBtn.addEventListener('click', add)

    function add(event) {
        event.preventDefault();

        if(model.value == '' 
          || description.value == ''
          || isNaN(year.value)
          || isNaN(price.value)
          || Number(price.value) < 0
          || Number(year.value) < 0) {

            return;
        }

        let furnitureList = document.querySelector('#furniture-list');

        let moreBtn = e('button', {}, 'More Info');
        moreBtn.classList.add("moreBtn");
        moreBtn.addEventListener('click', showInfo)

        let buyBtn = e('button', {}, 'Buy it');
        buyBtn.classList.add("buyBtn");
        buyBtn.addEventListener('click', buy)

        let tr = e('tr', { class: 'info'},
                    e('td', {}, `${model.value}`),
                    e('td', {}, `${Number(price.value).toFixed(2)}`),
                    e('td', {}, moreBtn, buyBtn));
        tr.classList.add('info');

        let itemDescription = e('td', {}, `Description: ${description.value}`)
        itemDescription.setAttribute('colspan', '3');

        let hiddenTr = e('tr', {},
                    e('td', {}, `Year: ${year.value}`),
                    itemDescription);
        hiddenTr.classList.add('hide');
       

        furnitureList.appendChild(tr);
        furnitureList.appendChild(hiddenTr);

        model.value = '';
        year.value = '';
        description.value = '';
        price.value = '';

        function showInfo() {
            if(moreBtn.textContent == 'More Info') {
                moreBtn.textContent = 'Less Info';
                hiddenTr.style.display = 'contents'
            } else {
                moreBtn.textContent = 'More Info';
                hiddenTr.style.display = 'none'
            }
           ;
        }

        function buy(event) {
            let itemPrice = event.currentTarget.parentElement.parentElement.children[1].textContent;
            tr.remove();
            hiddenTr.remove();
            let totalPrice = document.querySelector('.total-price');
            totalPrice.textContent = (Number(totalPrice.textContent) + Number(itemPrice)).toFixed(2);
        }
    }

    function e(type, attr, ...content) {
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
