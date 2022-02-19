window.addEventListener('load', solve);

function solve() {
    let inputModel = document.getElementById('model');
    let inputYear = document.getElementById('year');
    let inputDescription = document.getElementById('description');
    let inputPrice = document.getElementById('price');

    let infoTable = document.getElementById('furniture-list');

    let addBtn = document.getElementById('add');

    let totalPrice = 0;

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (inputModel.value !== '' && inputYear.value > 0 && inputDescription.value !== '' && inputPrice.value > 0) {
            let tableRowForInfo = document.createElement('tr');
            tableRowForInfo.classList.add('info');

            let model = document.createElement('td');
            model.textContent = inputModel.value;
            tableRowForInfo.appendChild(model);

            let price = document.createElement('td');
            price.textContent = Number(inputPrice.value).toFixed(2);
            tableRowForInfo.appendChild(price);

            let buttons = document.createElement('td');

            let moreInfoBtn = document.createElement('button');
            moreInfoBtn.classList.add('moreBtn');
            moreInfoBtn.textContent = "More Info";
            buttons.appendChild(moreInfoBtn);

            let buyBtn = document.createElement('button');
            buyBtn.classList.add('buyBtn');
            buyBtn.textContent = "Buy it";
            buttons.appendChild(buyBtn);

            tableRowForInfo.appendChild(buttons);

            let hiddentableRowForInfo = document.createElement('tr');
            hiddentableRowForInfo.classList.add('hide');
            hiddentableRowForInfo.style.display = 'none';

            let year = document.createElement('td');
            year.textContent = `Year: ${inputYear.value}`;
            hiddentableRowForInfo.appendChild(year);

            let description = document.createElement('td');
            description.setAttribute('colspan', '3');
            description.textContent = `Description: ${inputDescription.value}`;
            hiddentableRowForInfo.appendChild(description);

            infoTable.appendChild(tableRowForInfo);
            infoTable.appendChild(hiddentableRowForInfo);

            moreInfoBtn.addEventListener('click', (e) => {
                if (e.target.textContent == 'More info') {
                    e.target.textContent = 'Less info'
                    hiddentableRowForInfo.style.display = 'contents';
                } else if(e.target.textContent == 'Less info'){
                    e.target.textContent = 'More info'
                    hiddentableRowForInfo.style.display = 'none';
                }

            });

            buyBtn.addEventListener('click', (e) => {

                let total = document.querySelector('.total-price');
                let currentFurniture = e.target.parentElement.parentElement;
                let currPrice = currentFurniture.querySelectorAll('td');
                totalPrice += Number(currPrice[1].textContent);
                total.textContent = totalPrice.toFixed(2);
                currentFurniture.remove();
            });
        }

        inputModel.value = '';
        inputYear.value = '';
        inputDescription.value = '';
        inputPrice.value = '';
    })
}
