function validate() {
    document.querySelector('#company').addEventListener('change', company);
    document.querySelector('#submit').addEventListener('click', validateInput);

    let isChecked = false;

    function validateInput(event) {
        event.preventDefault();

        let username = document.querySelector('#username');
        let email = document.querySelector('#email');
        let password = document.querySelector('#password');
        let confirmPassword = document.querySelector('#confirm-password');

        const usernamePattern = /^[a-zA-Z0-9]{3,20}$/;
        const passwordPattern = /^[\w]{5,15}$/;
        const emailPattern = /^[^@.]+@[^@]*\.[^@]*$/;

        let isValid = true;

        if(!usernamePattern.test(username.value)) {
            username.style.borderColor = "red";
            isValid = false;
        } else {
            username.style.borderColor = "";
        }

        if(!emailPattern.test(email.value)) {
            email.style.borderColor = "red";
            isValid = false;
        } else {
            email.style.borderColor = "";
        }

        if(!passwordPattern.test(password.value) 
            || !passwordPattern.test(confirmPassword.value) 
            || (password.value != confirmPassword.value)) {

                password.style.borderColor = "red";
                confirmPassword.style.borderColor = "red";
                isValid = false;
        } else {
            password.style.borderColor = "";
            confirmPassword.style.borderColor = "";
        }

        if(isChecked) {
            let companyNumber = document.querySelector('#companyNumber');
            let number = Number(companyNumber.value);
            let invalidNumber = Number.isNaN(companyNumber.value);

            if(invalidNumber 
                || number < 1000 
                || number > 9999) {
                    
                companyNumber.style.borderColor = "red";
                isValid = false;
            } else {
                companyNumber.style.borderColor = "";
            }
        }

        let valid = document.querySelector('#valid');

        if(isValid) {
            valid.style.display = 'block'
        } else {
            valid.style.display = 'none'
        }
    }

    function company(e) {
        let isCompany = e.currentTarget.checked;
        let companyInfo = document.querySelector('#companyInfo');

        if(isCompany) { 
            companyInfo.style.display = 'block';
            isChecked = true;    
        } else {
            companyInfo.style.display = 'none';
            isChecked = false;    
        }
    }
}