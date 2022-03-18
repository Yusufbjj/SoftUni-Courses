async function solution() {

    const main = document.getElementById('main');

    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    const response = await fetch(url);

    const data = await response.json();

    data.forEach(element => {
        let divAccordion = createElement('div', '', ['class', 'accordion']);

        let divHead = createElement('div', '', ['class', 'head']);

        let span = createElement('span', element.title);

        let button = createElement('button', 'More', ['class', 'button', 'id', element._id]);

        let divExtra = createElement('div', '', ['class', 'extra']);

        let p = createElement('p');

        button.addEventListener('click', toggle);

        main.appendChild(divAccordion);
        divAccordion.appendChild(divHead);
        divAccordion.appendChild(divExtra);
        divHead.appendChild(span);
        divHead.appendChild(button);
        
        divExtra.appendChild(p);
        

    });

    async function toggle(ev) {

        const accordion = ev.target.parentNode.parentNode;

        const p = ev.target.parentNode.parentNode.children[1].children[0];
        console.log(p);

        const extra = ev.target.parentNode.parentNode.children[1];

        const id = ev.target.id;
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;

        const response = await fetch(url);
        const data = await response.json();

        p.textContent = data.content;

        const hidden = ev.target.textContent === 'More';

        extra.style.display = hidden ? 'block' : 'none';
        ev.target.textContent = hidden ? 'Less' : 'More';

    }

    function createElement(type, content, attributes = []) {

        const element = document.createElement(type);

        if (content) {
            element.textContent = content;
        }

        if (attributes.length > 0) {

            for (let index = 0; index < attributes.length; index += 2) {

                element.setAttribute(attributes[index], attributes[index + 1])

            }
        }

        return element;
    }

}
solution();