function toggle() {

    let button = document.querySelector('.button')

    if (button.textContent === 'Less') {

        button.textContent = 'More';

    } else {

        button.textContent = 'Less';

    }

    console.log(button);
}