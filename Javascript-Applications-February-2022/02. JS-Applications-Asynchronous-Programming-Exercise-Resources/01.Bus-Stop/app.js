async function getInfo() {
    //read input value
    //request to server
    //parse data
    //display data
    //error if invalid

    const stopNameElement = document.getElementById('stopName');

    const timetableElement = document.getElementById('buses');

    const stopId = document.getElementById('stopId').value;
    
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    try {
        stopNameElement.textContent = 'Loading...';

        timetableElement.replaceChildren();

        const response = await fetch(url);

        if (response.status !== 200) {
            throw new Error(`Stop ID not found!`);
        }

        const data = await response.json();

        stopNameElement.textContent = data.name;

        Object.entries(data.buses).forEach(b => {
            const liElement = document.createElement('li');

            liElement.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;

            timetableElement.appendChild(liElement);
        });

    } catch (error) {
        stopNameElement.textContent = 'Error';
    }

}