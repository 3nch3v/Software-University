function lockedProfile() {

    let btns = document.getElementsByTagName('button');

    Array.from(btns).forEach((b) => {
        b.addEventListener('click', showMore)
    });

    function showMore(e) {

        let btn = e.target;
        let isLocked = btn.parentElement.children[2].checked;
        
        if(!isLocked) {

            let divIdName = btn.parentElement.querySelector('div').id;
            let divElement = document.querySelector('#' + divIdName);

            if(btn.textContent === 'Show more') {
                
                divElement.style.display = 'block';
                btn.textContent = 'Hide it';

            } else if(btn.textContent === 'Hide it') {

                divElement.style.display = 'none';
                btn.textContent = 'Show more';
            }
        };
    };
}