window.addEventListener('load', solution);

function solution() {
  let inputName = document.getElementById('fname');
  let inputMail = document.getElementById('email');
  let inputPhone = document.getElementById('phone');
  let inputAddress = document.getElementById('address');
  let inputPostcode = document.getElementById('code');

  let submitButton = document.getElementById('submitBTN');
  let editButton = document.getElementById('editBTN');
  let continueButton = document.getElementById('continueBTN');

  let previewSection = document.getElementById('infoPreview');

  let liArr = [];

  submitButton.addEventListener('click', (e) => {
    if (inputName.value !== '' && inputMail.value !== '') {

      liArr.push(inputName.value, inputMail.value, inputPhone.value, inputAddress.value, inputPostcode.value);

      let fullName = document.createElement('li');

      fullName.textContent = `Full Name: ${inputName.value}`;

      let email = document.createElement('li');

      email.textContent = `Email: ${inputMail.value}`;

      let phone = document.createElement('li');

      phone.textContent = `Phone Number: ${inputPhone.value}`;

      let address = document.createElement('li');

      address.textContent = `Address: ${inputAddress.value}`;

      let postcode = document.createElement('li');

      postcode.textContent = `Postal Code: ${inputPostcode.value}`;

      previewSection.appendChild(fullName);
      previewSection.appendChild(email);
      previewSection.appendChild(phone);
      previewSection.appendChild(address);
      previewSection.appendChild(postcode);

      inputName.value = '';
      inputMail.value = '';
      inputPhone.value = '';
      inputAddress.value = '';
      inputPostcode.value = '';

      e.target.disabled = true;

      editButton.disabled = false;
      continueButton.disabled = false;

    }
  });

  editButton.addEventListener('click', () => {
    inputName.value = liArr[0];
    inputMail.value = liArr[1];
    inputPhone.value = liArr[2];
    inputAddress.value = liArr[3];
    inputPostcode.value = liArr[4];
    editButton.disabled = true;
    continueButton.disabled = true;
    submitButton.disabled = false;
    previewSection.textContent = '';
  });

  continueButton.addEventListener('click', () => {
    let blockDiv = document.getElementById('block');
    blockDiv.textContent = '';

    let thankYouMessage = document.createElement('h3');

    thankYouMessage.textContent = 'Thank you for your reservation!';

    blockDiv.appendChild(thankYouMessage);
  });
}
