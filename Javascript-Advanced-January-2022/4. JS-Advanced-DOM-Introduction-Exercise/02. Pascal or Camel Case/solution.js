function solve() {
  let text = document.getElementById('text').value;

  let convention = document.getElementById('naming-convention').value;

  let result = [];

  text = text.split(" ");

  if (convention === 'Camel Case') {

    for (let index = 0; index < text.length; index++) {

      let word = text[index];

      let wordAfterChange = '';

      if (index > 0) {

        for (let index = 0; index < word.length; index++) {

          if (index == 0) {

            wordAfterChange += word[index].toUpperCase();

          } else {

            wordAfterChange += word[index].toLowerCase();

          }

        }

      } else {

        for (let index = 0; index < word.length; index++) {

            wordAfterChange += word[index].toLowerCase();

        }
        result.push(wordAfterChange);
        continue;
      }

      result.push(wordAfterChange);

    }

    result = result.join("");
  } else if (convention === 'Pascal Case') {

    for (let index = 0; index < text.length; index++) {

      let word = text[index];

      let wordAfterChange = '';

      for (let index = 0; index < word.length; index++) {

        if (index == 0) {

          wordAfterChange += word[index].toUpperCase();

        } else {

          wordAfterChange += word[index].toLowerCase();

        }
      }

      result.push(wordAfterChange);
    }

    result = result.join("");

  } else {
    result = 'Error!';
  }
  let resultEle = document.getElementById('result');
  resultEle.textContent = result;

}