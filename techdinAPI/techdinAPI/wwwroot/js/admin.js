const submitButton = document.getElementById('submitButton');
var confirmationCode = '';
var user;

//function GetUser(){
//    fetch('https://localhost:44358/api/CurrentUser/', {
//        method: "GET", // *GET, POST, PUT, DELETE, etc.
//    })
//    .then(response => {
//        return response.json();
//    })
//    .then((data) => {
//        user = data;
//    })
//    .catch((err) => console.log(err));
//}

function SendCode(emailField, typeField){
    fetch('https://localhost:44358/api/Invitations/', {
        method: "POST", // *GET, POST, PUT, DELETE, etc.
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email: emailField, type: typeField })
    })
    .then((response) => {
        return response;
    })
    .then((response) => {
        confirmationCode = response.ok;
    })
    .catch((err) => console.log(err))
}



document.addEventListener('DOMContentLoaded', () => {
    const emailerror = document.getElementById('emailerror')
    const inviteform = document.getElementById('invite');
    submitButton.addEventListener('click', () => {
        let emailValue = document.getElementById('emailtext').value;
        let typeValue = document.getElementById('accttype').value;
        SendCode(emailValue, typeValue);
        inviteform.reset();
        if (confirmationCode == true) {
            emailerror.innerText = `An invitation link has been sent to ${emailValue} for account type ${typeValue}`;
        } else {
            emailerror.innerText = 'You are not authorized to send invitations'
        }

    })
})