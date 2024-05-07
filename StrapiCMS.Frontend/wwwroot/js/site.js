window.registerScrollListener = (headerElement) => {
    window.addEventListener('scroll', () => {
        const scrollTop = window.scrollY;
        const headerHeight = headerElement.offsetHeight;

        if (scrollTop > headerHeight) {
            headerElement.classList.add('sticky');
        } else {
            headerElement.classList.remove('sticky');
        }
    });
};
function validatePassword(targetElement) {
    var confirm_password = targetElement.getAttribute('data-conf-password');
    var confirmElement = document.querySelector('#' + confirm_password);
    targetElement.style.border = '1px solid #e23c39';
    var siblings = targetElement.parentNode.querySelectorAll('span');
    siblings.forEach(function (element) {
        element.style.display = 'block';
    });

    var newpassword = targetElement.value;
    var isValid = validateCheckPassword(newpassword);

    var count_elements = targetElement.parentNode.querySelectorAll('.red').length;
    if (isValid && count_elements == 0) {
        targetElement.style.border = '1px solid #80b918';
        return true;
    } else if (newpassword.length == 0) {
        siblings.forEach(function (element) {
            element.style.display = 'none';
        });
        return false;
    } else {
        return false;
    }

    //Validate Confirm Password Match
    MatchPasswords(targetElement, confirmElement);
}


function confirmValidatePassword(confirmInput) {
    confirmInput.style.border = '1px solid red';
    var siblings = confirmInput.parentNode.querySelectorAll('span');
    siblings.forEach(function (element) {
        element.style.display = 'block';
    });

    var password = confirmInput.getAttribute('data-password');
    var passwordElem = document.querySelector('#' + password);
    var confirm_password = confirmInput.value;

    MatchPasswords(passwordElem, confirmInput);

    var count_elements = confirmInput.parentNode.querySelectorAll('.red').length;
    if (count_elements == 0 && confirm_password.length > 0) {
        confirmInput.style.border = '1px solid #ced4da';
        return true;
    } else if (confirm_password.length == 0) {
        siblings.forEach(function (element) {
            element.style.display = 'none';
        });
        return false;
    } else {
        return false;
    }
}


function validateCheckPassword(passval) {
    var upperCase = /[A-Z]/;
    var lowerCase = /[a-z]/;
    var numbers = /[0-9]/;
    var regxSpecial = /^[a-zA-Z0-9- ]*$/;
    var charLengthValidate = document.querySelector('.charlength_validate');
    var capitalValidate = document.querySelector('.capital_validate');
    var smallcaseValidate = document.querySelector('.smallcase_validate');
    var numericValidate = document.querySelector('.numeric_validate');
    var specialValidate = document.querySelector('.special_validate');

    var isValid = true;

    if (passval.length > 7) {
        charLengthValidate.classList.add('green');
        charLengthValidate.classList.remove('red');
    } else {
        charLengthValidate.classList.add('red');
        charLengthValidate.classList.remove('green');
        isValid = false;
    }

    if (upperCase.test(passval)) {
        capitalValidate.classList.add('green');
        capitalValidate.classList.remove('red');
    } else {
        capitalValidate.classList.add('red');
        capitalValidate.classList.remove('green');
        isValid = false;
    }

    if (lowerCase.test(passval)) {
        smallcaseValidate.classList.add('green');
        smallcaseValidate.classList.remove('red');
    } else {
        smallcaseValidate.classList.add('red');
        smallcaseValidate.classList.remove('green');
        isValid = false;
    }

    if (numbers.test(passval)) {
        numericValidate.classList.add('green');
        numericValidate.classList.remove('red');
    } else {
        numericValidate.classList.add('red');
        numericValidate.classList.remove('green');
        isValid = false;
    }

    if (regxSpecial.test(passval) == false) {
        specialValidate.classList.add('green');
        specialValidate.classList.remove('red');
    } else {
        specialValidate.classList.add('red');
        specialValidate.classList.remove('green');
        isValid = false;
    }

    return isValid;
}

function MatchPasswords(password, confirmPassword) {
    if (password.value === confirmPassword.value) {
        document.querySelectorAll('.match_password').forEach(function (element) {
            element.style.display = 'none';
            element.classList.remove('red');
        });
        confirmPassword.style.border = '1px solid #80b918';
        Array.from(confirmPassword.parentNode.children).forEach(function (element) {
            if (element.tagName.toLowerCase() === 'span') {
                element.style.display = 'none';
            }
        });
        return true;
    } else {
        document.querySelectorAll('.match_password').forEach(function (element) {
            element.style.display = 'none';
            element.classList.add('red');
        });
        confirmPassword.style.border = '1px solid #e23c39';
        Array.from(confirmPassword.parentNode.children).forEach(function (element) {
            if (element.tagName.toLowerCase() === 'span') {
                element.style.display = 'block';
            }
        });
        return false;
    }
}

