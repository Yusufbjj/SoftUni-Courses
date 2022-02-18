
window.addEventListener('load', solve);

function solve() {
    let productTypeInput = document.getElementById('type-product');
    let descriptionInput = document.getElementById('description');
    let clientNameInput = document.getElementById('client-name');
    let phoneInput = document.getElementById('client-phone');

    let sendBtn = document.querySelector('#right button');
    let clearButton = document.querySelector('.clear-btn');

    let receivedOrdersSection = document.getElementById('received-orders');

    let competedOrdersSection = document.getElementById('completed-orders');


    sendBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (clientNameInput.value !== '' && phoneInput.value !== '' && descriptionInput.value !== '') {

            let containerElement = document.createElement('div');
            containerElement.classList.add('container');

            let typeElement = document.createElement('h2');
            typeElement.textContent = `Product type for repair: ${productTypeInput.value}`;

            let clientInfo = document.createElement('h3');
            clientInfo.textContent = `Client information: ${clientNameInput.value}, ${phoneInput.value}`;

            let problemDescription = document.createElement('h4');
            problemDescription.textContent = `Description of the problem: ${descriptionInput.value}`;

            let startButton = document.createElement('button');
            startButton.classList.add('start-btn');
            startButton.textContent = 'Start repair';
            startButton.addEventListener('click', (e) => {
                e.target.disabled = true;
                finishButton.disabled = false;
            });

            let finishButton = document.createElement('button');
            finishButton.classList.add('finish-btn');
            finishButton.textContent = 'Finish repair';
            finishButton.disabled = true;
            finishButton.addEventListener('click', (e) => {
                let div = e.currentTarget.parentElement;
                e.currentTarget.parentElement.remove();
                e.currentTarget.remove();
                startButton.remove();
                competedOrdersSection.appendChild(div);
            });

            clearButton.addEventListener('click', (e) => {
                let elements = document.querySelectorAll('#completed-orders .container')
                for (let ele of elements) {
                    ele.remove();
                }
            });

            containerElement.appendChild(typeElement);
            containerElement.appendChild(clientInfo);
            containerElement.appendChild(problemDescription);
            containerElement.appendChild(startButton);
            containerElement.appendChild(finishButton);
            receivedOrdersSection.appendChild(containerElement);
        }

        productTypeInput.value = '';
        descriptionInput.value = '';
        clientNameInput.value = '';
        phoneInput.value = '';
    });
}