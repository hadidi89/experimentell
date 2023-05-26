function footerPosition(element) {
    try {
        const _element = document.querySelector(element);
        const isTallerThanScreen = document.body.scrollHeight >= window.innerHeight;

        if (isTallerThanScreen) {
            _element.style.position = 'static';
        } else {
            _element.style.position = 'fixed';
            _element.style.bottom = '0';
            _element.style.left = '0';
            _element.style.width = '100%';
        }
    } catch (error) {
        console.error(error);
    }
}

footerPosition('footer');




function toggleMenu(attribute) {

    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }


}

toggleMenu('[data-option="toggle"]')

//-------------------------------------------------------------


// CONTACT FORM VALIDATION
function handleContactSubmit(event) {
    event.preventDefault();

    // Check if the required fields are filled
    var fullNameField = document.getElementById("FullName");
    var emailField = document.getElementById("Email");
    var commentField = document.getElementById("Comment");
    var fullNameError = document.getElementById("contactFullNameError");
    var emailError = document.getElementById("contactEmailError");
    var commentError = document.getElementById("contactCommentError");

    fullNameError.textContent = "";
    emailError.textContent = "";
    commentError.textContent = "";

    var regExFullName = /^[a-zA-Z]+(?: [a-zA-Z]+)*$/;
    if (fullNameField.value === "" || !regExFullName.test(fullNameField.value)) {
        fullNameError.textContent = "Please enter a valid full name.";
        return;
    }

    var regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (emailField.value === "" || !regExEmail.test(emailField.value)) {
        emailError.textContent = "Please enter a valid email address.";
        return;
    }

    if (commentField.value === "") {
        commentError.textContent = "Please enter a comment.";
        return;
    }

    // Submit the form if all validations pass
    event.target.submit();
}

// Get the contact form element
var contactForm = document.getElementById("contactForm");

// Add event listener to the contact form's submit event
if (contactForm) {
    contactForm.addEventListener("submit", handleContactSubmit);
}

//------------------------------------------------------------------------------------------


//LOGIN VALIDATION
function handleLoginSubmit(event) {
    event.preventDefault();

    // Check if the required fields are filled
    var emailField = document.getElementById("Email");
    var passwordField = document.getElementById("Password");
    var emailError = document.getElementById("emailError");
    var passwordError = document.getElementById("passwordError");

    // Validate email field
    var regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (emailField.value === "" || !regExEmail.test(emailField.value)) {
        emailError.textContent = "Please enter a valid email address.";
        return;
    }

    // Validate password field
    var regExPassword = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,}$/;
    if (passwordField.value === "" || !regExPassword.test(passwordField.value)) {
        passwordError.textContent = "Please enter a valid password (at least 6 characters, including uppercase, lowercase, and a number).";
        return;
    }

    event.target.submit();
}

// Get the login form element
var loginForm = document.getElementById("loginForm");

// Add event listener to the login form's submit event
loginForm.addEventListener("submit", handleLoginSubmit);

//------------------------------------------------------------------------------------------

/*REGISTER FORM VALIDATION*/
function handleRegisterSubmit(event) {
    event.preventDefault();

    // Check if the required fields are filled
    var firstNameField = document.getElementById("firstNameField");
    var lastNameField = document.getElementById("LastNameField");
    var streetNameField = document.getElementById("StreetNameField");
    var postalCodeField = document.getElementById("PostalCodeField");
    var cityField = document.getElementById("CityField");
    var emailField = document.getElementById("EmailField");
    var passwordField = document.getElementById("PasswordField");
    var firstNameError = document.getElementById("RegisterFirstNameError");
    var lastNameError = document.getElementById("RegisterLastNameError");
    var streetNameError = document.getElementById("streetNameError");
    var postalCodeError = document.getElementById("postalCodeError");
    var cityError = document.getElementById("cityError");
    var emailError = document.getElementById("RegisterEmailError");
    var passwordError = document.getElementById("RegisterPasswordError");

    // Validate first name field
    var regExName = /^[a-zA-Z]+$/;
    if (firstNameField.value === "" || !regExName.test(firstNameField.value)) {
        firstNameError.textContent = "Please enter a valid first name.";
        return;
    }

    // Validate last name field
    if (lastNameField.value === "" || !regExName.test(lastNameField.value)) {
        lastNameError.textContent = "Please enter a valid last name.";
        return;
    }

    // Validate street name field
    if (streetNameField.value === "") {
        streetNameError.textContent = "Please enter a street name.";
        return;
    }

    // Validate postal code field
    var regExPostalCode = /^[0-9]{5}$/;
    if (postalCodeField.value === "" || !regExPostalCode.test(postalCodeField.value)) {
        postalCodeError.textContent = "Please enter a valid postal code (5 digits).";
        return;
    }

    // Validate city field
    if (cityField.value === "") {
        cityError.textContent = "Please enter a city name.";
        return;
    }


    // Validate email field
    var regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (emailField.value === "" || !regExEmail.test(emailField.value)) {
        emailError.textContent = "Please enter a valid email address.";
        return;
    }

    // Validate password field
    var regExPassword = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,}$/;
    if (passwordField.value === "" || !regExPassword.test(passwordField.value)) {
        passwordError.textContent = "Please enter a valid password (at least 6 characters, including uppercase, lowercase, and a number).";
        return;
    }

    // Submit the form if all validations pass
    event.target.submit();
}

// Get the register form element
var registerForm = document.getElementById("registerForm");

// Add event listener to the register form's submit event
if (registerForm) {
    registerForm.addEventListener("submit", handleRegisterSubmit);
}

