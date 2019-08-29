let fname_b = false;
let lname_b = false;
let uname_b = false;
let pw_b = false;
let confirmationCode = false;





function fn_specs(event) {
    const fn_err = document.getElementById("fn_error");

    if (event.target.value.length == 0) {

        event.target.style.border = "1px solid red"
        fn_err.style.color = "red"
        fn_err.innerHTML = " First name is required"
    } else {
        event.target.style.border = "none"
        fn_err.style.color = "black"
        fn_err.innerHTML = ""
        fname_b = true
    }
}

function ln_specs(event) {
    const ln_err = document.getElementById("ln_error");

    if (event.target.value.length == 0) {

        event.target.style.border = "1px solid red"
        ln_err.style.color = "red"
        ln_err.innerHTML = " Last name is required"
    } else {
        event.target.style.border = "none"
        ln_err.style.color = "black"
        ln_err.innerHTML = ""
        lname_b = true
    }
}


function un_specs(event) {
    //unique in database
    //length is less than 20, more than 5
    const un_err = document.getElementById("un_error");

    if (event.target.value.length == 0) {
        event.target.style.border = "1px solid red"
        un_err.style.color = "red"
        un_err.innerHTML = " Username is required"
    } else {
        uname_b = true
    }
}

function pw_specs(event) {
    const pw_err = document.getElementById("pw_error");

    if (event.target.value.length < 7) {
        event.target.style.border = "1px solid red"
        pw_err.style.color = "red"
        pw_err.innerHTML = "Password must be 8 or more characters"
    } else {
        pw_b = true
    }
    //length is less than 30, more than 10 
}

//function pwc_specs(event, pword) {
//    const cp_err = document.getElementById("cp_error");

//    //matches_pw 
//    if (event.target.value !== pword) {
//        cp_err.innerHTML = "Passwords don't match"
//        event.target.style.border = "1px solid red"
//        cp_err.style.color = "red"
//    } else {
//        cpw_b = true
//    }
//}

function email_specs(event) {
    //in valid email 
    const email_err = document.getElementById("email_error");
    if (event.target.value.length == 0) {
        event.target.style.border = "1px solid red"
        email_err.style.color = "red"
        email_err.innerHTML = "email is required"
    } else {
        email_b = true

    }
}

function sendForm(email, invkey, username, password, confirm, first, last, home, cell, linkedin) {
    if (fname_b && lname_b && uname_b
            && pw_b && email_b) {
        fetch('https://localhost:44358/api/Users/', {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(
                {
                    Email: email,
                    InvKey: invkey,
                    UserName: username,
                    Password: password,
                    ConfirmPassword: confirm,
                    FirstName: first,
                    LastName: last,
                    HomePhone: home,
                    CellPhone: cell,
                    LinkedIn: linkedin
                })
        })
            .then((response) => {
                return response;
            })
            .then((response) => {
                if (response.ok)
                    confirmationCode = true;
            })
            .catch((err) => console.log(err))
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const emailField = document.getElementById('email');
    const codeField = document.getElementById('InvitationCode');
    const firstField = document.getElementById('first_name');
    const lastField = document.getElementById('last_name');
    const userField = document.getElementById('user_name');
    const pwordField = document.getElementById('password');
    const confirmField = document.getElementById('confirm_password');
    const homeField = document.getElementById('home_phone');
    const cellField = document.getElementById('cell_phone');
    const linkField = document.getElementById('LinkedIn');
    const createButton = document.getElementById('createuserbutton');
    emailField.addEventListener('blur', email_specs);
    firstField.addEventListener('blur', fn_specs);
    lastField.addEventListener('blur', ln_specs);
    pwordField.addEventListener('blur', pw_specs);
    //confirmField.addEventListener('blur', pwc_specs(pwordField.value)); 
    userField.addEventListener('blur', un_specs);
    createButton.addEventListener('click', () => {
        sendForm(emailField.value, codeField.value, userField.value, pwordField.value, confirmField.value,
            firstField.value, lastField.value, homeField.value, cellField.value, linkField.value);
        if (confirmationCode == true)
            window.location = "profile.html";
        else {
            const invalidMsg = document.getElementById('invalidMsg');
            invalidMsg.innerText = "Unable to add user please re check your information.";
        }
    })
})