function create(words) {

   let container = document.getElementById('content');

   let elements = words;

   for (let index = 0; index < elements.length; index++) {

      let div = document.createElement('div');

      let p = document.createElement('p');

      let text = document.createTextNode(elements[index]);

      p.appendChild(text);

      p.style.display = 'none';

      div.appendChild(p);
      
      div.addEventListener('click', function (event) {
         event.target.children[0].style.display = 'block';
      });

      container.appendChild(div);
   }

}