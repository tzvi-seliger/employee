const submitButton = document.getElementById('submitButton');
var confirmationCode = '';
var user;

function GetUser(){
    fetch('https://localhost:44358/api/CurrentUser/', {
        method: "GET", // *GET, POST, PUT, DELETE, etc.
    })
    .then(response => {
        return response.json();
    })
    .then((data) => {
        user = data;
    })
    .catch((err) => console.log(err));
}

function SendCode(emailField){
    fetch('https://localhost:44358/api/Invitations/', {
        method: "POST", // *GET, POST, PUT, DELETE, etc.
        headers: {
            email: emailField
        }
    })
    .then(response => {
        return response.json();
    })
    .then((data) => {
        console.log(data);
    })
    .catch((err) => console.log(err));
}

function Login(username, password){
    fetch('https://localhost:44358/api/CurrentUser/' + username + '/' + password, {
    method: "GET" // *GET, POST, PUT, DELETE, etc.
})
.then(response => {
    return response.json();
})
.then((data) => {
    user = data;
})
.catch((err) => console.log(err));
}


document.addEventListener('DOMContentLoaded', () => {
    const validateButton = document.getElementById('validate');
    validateButton.addEventListener('click', () =>{
        let usernameInput = document.getElementById('username').value;
        let passwordInput = document.getElementById('password').value;
        Login(usernameInput, passwordInput);
    })

    submitButton.addEventListener('click', () => {
        let emailValue = document.getElementById('emailtext').value;
        SendCode(emailValue);
        //SendCode(emailValue);
    })

})