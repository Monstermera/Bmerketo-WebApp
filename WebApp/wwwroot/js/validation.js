function showError(elementId, errorMessage) {
    var errorElement = document.querySelector("#" + elementId + "Error");
    errorElement.innerText = errorMessage;
}

function clearError(elementId) {
    var errorElement = document.querySelector("#" + elementId + "Error");
    errorElement.innerText = "";
}

function validateText(nameId) {
    var nameElement = document.getElementById(nameId);
    var name = nameElement.value;

    if (!name) {
        showError(nameId, "Please enter this field.");
        return false;
    } else if (name.length < 2) {
        var fieldName;
        switch (nameId) {
            case "firstName":
                fieldName = "First Name";
                break;
            case "lastName":
                fieldName = "Last Name";
                break;
            case "streetName":
                fieldName = "Street Name";
                break;
            case "postalCode":
                fieldName = "Postal Code";
                break;
            case "city":
                fieldName = "City";
                break;
            default:
                fieldName = "Name";
                break;
        }
        showError(nameId, fieldName + " must be at least 2 characters long.");
        return false;
    }

    clearError(nameId);
    return true;
}

function validateEmail(emailId) {
    var emailElement = document.getElementById(emailId);
    var email = emailElement.value;

    if (!email) {
        showError(emailId, "Please enter your email.");
        return false;
    } else {
        var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!emailPattern.test(email)) {
            showError(emailId, "Please enter a valid email address");
            return false;
        }
    }

    clearError(emailId);
    return true;
}

function validatePassword(passwordId) {
    var passwordElement = document.getElementById(passwordId);
    var password = passwordElement.value;

    if (!password) {
        showError(passwordId, "Please enter a password.");
        return false;
    } else {
        var passwordPattern = /^(?=.*?[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$/;
        if (!passwordPattern.test(password)) {
            showError(passwordId, "Please enter a valid password");
            return false;
        }
    }

    clearError(passwordId);
    return true;
}

function validateConfirmPassword(confirmPasswordId) {
    var confirmPasswordElement = document.getElementById(confirmPasswordId);
    var confirmPassword = confirmPasswordElement.value;
    var password = document.getElementById("password").value;

    if (!confirmPassword) {
        showError(confirmPasswordId, "Please confirm your password.");
        return false;
    } else if (password !== confirmPassword) {
        showError(confirmPasswordId, "Passwords do not match.");
        return false;
    }

    clearError(confirmPasswordId);
    return true;
}


function validateMessage(messageId) {
    var messageElement = document.getElementById(messageId);
    var message = messageElement.value;

    if (!message) {
        showError(messageId, "Please enter a message.");
        return false;
    } else if (message.length < 5) {
        showError(messageId, "Message must be at least 5 characters long.");
        return false;
    }

    clearError(messageId);
    return true;
}

function validatePhoneNumber(phoneNumberId) {
    var phoneNumberElement = document.getElementById(phoneNumberId);
    var phoneNumber = phoneNumberElement.value;

    if (!phoneNumber) {
        showError(phoneNumberId, "Please enter a phone number.");
        return false;
    } else {
        var phoneNumberPattern = /^\d{10}$/;
        if (!phoneNumberPattern.test(phoneNumber)) {
            showError(phoneNumberId, "Please enter a valid phone number (0123456789).");
            return false;
        }
    }

    clearError(phoneNumberId);
    return true;
}

/////////////////////////////////////////////////////////////////// PRODUCT  ///////////////////////////////////////////////////////////////////

function validateArticleNumber(articleNumberId) {
    var articleNumberElement = document.getElementById(articleNumberId);
    var articleNumber = articleNumberElement.value;

    if (!articleNumber) {
        showError(articleNumberId, "Please enter an article number.");
        return false;
    } else if (articleNumber.length < 7) {
        showError(articleNumberId, "Article number must be at least 7 characters long.");
        return false;
    } else {
        var articleNumberPattern = /^(?!\s)[a-zA-Z0-9\-/_]*$/;
        if (!articleNumberPattern.test(articleNumber)) {
            showError(articleNumberId, "Please enter a valid article number (ASA-5000).");
            return false;
        }
    }

    clearError(articleNumberId);
    return true;
}

function validatePrice(priceId) {
    var priceElement = document.getElementById(priceId);
    var price = priceElement.value;

    if (!price) {
        showError(priceId, "Please enter a price.");
        return false;
    }

    var pricePattern = /^\d+$/;
    if (!pricePattern.test(price)) {
        showError(priceId, "Please enter a valid price (only digits).");
        return false;
    }

    clearError(priceId);
    return true;
}

function validateTags() {
    var tags = document.getElementsByName('Tags');
    var checkedTags = Array.from(tags).some(function (tag) {
        return tag.checked;
    });

    if (!checkedTags) {
        document.getElementById('tagsError').textContent = 'Please select at least one product tag.';
        return false;
    }

    document.getElementById('tagsError').textContent = '';
    return true;
}

// Kalla på validateTags-funktionen när formuläret skickas
document.querySelector('form').addEventListener('submit', function (event) {
    if (!validateTags()) {
        event.preventDefault(); // Förhindra formuläret från att skickas om valideringen misslyckas
    }
});


////////////////////////////////////////////////////////////////////// VALIDATE FORM ///////////////////////////////////////////////////////////////////

function validateForm(event) {
    event.preventDefault();

    var isValid = true;

    isValid = validateText("firstName") && isValid;
    isValid = validateText("lastName") && isValid;
    isValid = validateEmail("email") && isValid;
    isValid = validateText("streetName") && isValid;
    isValid = validateText("postalCode") && isValid;
    isValid = validateText("city") && isValid;
    isValid = validatePassword("password") && isValid;
    isValid = validateConfirmPassword("confirmPassword") && isValid;

    if (isValid) {
        event.target.submit();
    }
}

/////////////////////////////////////////////////////////////////// VALIDATE CONTACT FORM ///////////////////////////////////////////////////////////////////

function validateContactForm(event) {
    event.preventDefault();

    var isValid = true;

    isValid = validateText("name") && isValid;
    isValid = validateEmail("email") && isValid;
    isValid = validateMessage("message") && isValid;
    isValid = validatePhoneNumber("phoneNumber") && isValid;

    if (isValid) {
        event.target.submit();
    }
}

/////////////////////////////////////////////////////////////////// VALIDATE PRODUCT FORM ///////////////////////////////////////////////////////////////////

function validateProductForm(event) {
    event.preventDefault();

    var isValid = true;

    isValid = validateArticleNumber("articleNumber") && isValid;
    isValid = validateText("name") && isValid;
    isValid = validatePrice("price") && isValid;
    isValid = validateTags() && isValid;

    if (isValid) {
        event.target.submit();
    }
}

/////////////////////////////////////////////////////////////////// VALIDATE LOG IN FORM ///////////////////////////////////////////////////////////////////

function validateLoginForm(event) {
    event.preventDefault();

    var email = document.getElementById("loginEmail").value;
    var password = document.getElementById("loginPassword").value;

    var emailOK = validateEmail("loginEmail");
    var passwordOK = validatePassword("loginPassword");

    if (!email) {
        showError("loginEmail", "Please enter a email address.");
        return;
    }

    if (!password) {
        showError("loginPassword", "Please enter a password.");
        return;
    }

    if (!emailOK || !passwordOK) {
        showError("errorMsg", "Incorrect email or password.");
        return;
    }

    event.target.submit();
}
