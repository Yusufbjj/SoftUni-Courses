function passValidator(pasword) {

    function passLength(pass) {

        if (pass.length >= 6 && pass.length <= 10) {
            return "";
        } else {
            return "Password must be between 6 and 10 characters\n"
        }
    }

    function onlyLetterDigits(str) {
        let isLetterDigit = true;
        for (let char of str) {
            let code = char.charCodeAt();
            if (code < 48
                || code > 57 && code < 65
                || code > 90 && code < 97
                || code > 122) {
                isLetterDigit = false;
            }
        }
        return isLetterDigit ? "" : "Password must consist only of letters and digits\n";
    }

    function twoDigits(str) {
        let count = 0;
        for (let char of str) {
            let code = char.charCodeAt();
            if (code >= 48 && code <= 57) {
                count++;
            }
        }

        if(count>=2){
            return ""
        }else{
            return "Password must have at least 2 digits"
        }

    }
    let errors = passLength(pasword) + onlyLetterDigits(pasword) + twoDigits(pasword);

    return errors ? errors :"Password is valid" ;
    
}
let result = passValidator('MyPass123');
console.log(result);
