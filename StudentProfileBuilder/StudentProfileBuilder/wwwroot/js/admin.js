const submitButton = document.getElementById('submitButton');
var confirmationCode = '';
var user;


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

document.addEventListener('DOMContentLoaded', () => {
    
    submitButton.addEventListener('click', () => {
        let emailValue = document.getElementById('emailtext').value;
        SendCode(emailValue);
        //SendCode(emailValue);
    })

})