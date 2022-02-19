function solve() {

    let firstNameElementInput = document.getElementById('fname');
    let lastNameElementInput = document.getElementById('lname');
    let emailElementInput = document.getElementById('email');
    let birthdayElementInput = document.getElementById('birth');
    let positionElementInput = document.getElementById('position');
    let salaryElementInput = document.getElementById('salary');

    let hireWorkerButton = document.getElementById('add-worker');

    let tableContainerElement = document.getElementById('tbody');

    let budgetMessageElement = document.getElementById('sum');
    let totalSalary = 0;

    hireWorkerButton.addEventListener('click', (e) => {
        e.preventDefault();

        if (firstNameElementInput.value !== '' && lastNameElementInput.value !== '' && emailElementInput.value !== '' && birthdayElementInput.value !== '' && positionElementInput.value !== '' && salaryElementInput.value !== '') {

            let currentTableRow = document.createElement('tr');

            let firstName = document.createElement('td');
            firstName.textContent = firstNameElementInput.value;
            currentTableRow.appendChild(firstName);

            let lastName = document.createElement('td');
            lastName.textContent = lastNameElementInput.value;
            currentTableRow.appendChild(lastName);

            let email = document.createElement('td');
            email.textContent = emailElementInput.value;
            currentTableRow.appendChild(email);

            let birthdate = document.createElement('td');
            birthdate.textContent = birthdayElementInput.value;
            currentTableRow.appendChild(birthdate);

            let position = document.createElement('td');
            position.textContent = positionElementInput.value;
            currentTableRow.appendChild(position);

            let salary = document.createElement('td');
            salary.textContent = salaryElementInput.value;
            currentTableRow.appendChild(salary);

            let buttons = document.createElement('td');

            let firedButton = document.createElement('button');
            firedButton.textContent = 'Fired';
            firedButton.classList.add('fired');
            buttons.appendChild(firedButton);

            firedButton.addEventListener('click',(e)=>{
                let currentSalary = 0;
                currentSalary = Number(salary.textContent);

                totalSalary -= currentSalary;

                budgetMessageElement.textContent = totalSalary.toFixed(2);
                e.target.parentElement.parentElement.remove();
            });

            let editButton = document.createElement('button');
            editButton.textContent = 'Edit';
            editButton.classList.add('edit');
            buttons.appendChild(editButton);

            editButton.addEventListener('click', (e) => {
                let currentSalary = 0;
                currentSalary = Number(salary.textContent);

                totalSalary -= currentSalary;

                budgetMessageElement.textContent = totalSalary.toFixed(2);

                firstNameElementInput.value = firstName.textContent;
                lastNameElementInput.value = lastName.textContent;
                emailElementInput.value = email.textContent;
                birthdayElementInput.value = birthdate.textContent;
                positionElementInput.value = position.textContent;
                salaryElementInput.value = salary.textContent;

                e.target.parentElement.parentElement.remove();

            });

            currentTableRow.appendChild(buttons);

            tableContainerElement.appendChild(currentTableRow);

            totalSalary += Number(salary.textContent);

            budgetMessageElement.textContent = totalSalary.toFixed(2);

            firstNameElementInput.value = '';
            lastNameElementInput.value = '';
            emailElementInput.value = '';
            birthdayElementInput.value = '';
            positionElementInput.value = '';
            salaryElementInput.value = '';
        }
    });
}
solve()