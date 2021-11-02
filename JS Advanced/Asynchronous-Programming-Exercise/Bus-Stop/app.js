async function getInfo() {
    const stopId = document.querySelector('#stopId');
    const stopName = document.querySelector('#stopName');
    const buses = document.querySelector('#buses');

    stopId.textContent = '';
    buses.replaceChildren();

    try {
        const res = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`);

        if(res.ok !== true && res.status !== 200) {
            throw new Error('Bad request.');
        }

        const data = await res.json();
        stopName.textContent = data.name;

        for(const [bus, minutes] of Object.entries(data.buses)) {
            const busInfo = document.createElement('li');
            busInfo.textContent = `Bus ${bus} arrives in ${minutes} minutes`;
            buses.appendChild(busInfo);
        }
    } catch(error) {
        stopName.textContent = 'Error';
    }    
}