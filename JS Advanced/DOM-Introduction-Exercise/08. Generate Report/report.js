function generateReport() {
    let cols = document.querySelectorAll('th');
    let indeces = [];

    for(let i = 0; i < cols.length; i++) {
        let input = cols[i].children[0].checked;
        
        if(input) {
            indeces.push(i);
        }
    }

    let result = [];

    let rows = document.querySelectorAll('tbody tr');

    for(let i = 0; i < rows.length; i++) {
        let obj = new Object();

        for(let j = 0; j < indeces.length; j++) {
            let index = indeces[j];
            let colName = cols[index].textContent.toLocaleLowerCase().trimEnd();

            obj[colName] = rows[i].children[index].textContent;
        }

        result.push(obj);
    }

    let output = document.querySelector('#output');
    output.textContent = JSON.stringify(result);
}