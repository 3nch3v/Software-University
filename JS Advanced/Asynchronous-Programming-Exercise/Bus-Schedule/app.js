function solve() {
    const departBtn = document.querySelector('#depart');
    const arriveBtn = document.querySelector('#arrive');
    const info = document.querySelector('.info');
    let nextStop = 'depot';
    let currStopName = '';

    async function depart() {
        try {
            const res = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStop}`);

            if(res.ok !== true && res.status !== 200) {
                throw new Error('Bad request.');
            }

            const data = await res.json();

            currStopName = data.name;
            nextStop = data.next;
            info.textContent = `Next stop ${currStopName}`;

            departBtn.disabled = true;
            arriveBtn.disabled = false;
            
        } catch(error) {
            info.textContent = 'Error';
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    function arrive() {
        info.textContent = `Arriving at ${currStopName}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();