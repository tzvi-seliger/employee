let email = '';
let homephone = '';
let cellphone = '';
let errormsg = '';
let submit = '';
let user = '';

function GetUser(username) {
    fetch(`https://localhost:44358/api/Users/${username}`, {
        method: "GET", // *GET, POST, PUT, DELETE, etc.
    })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            user = data;
            Rebuild();
        })
        .catch((err) => console.log(err));
}

function UpdateUser(username) {
    fetch(`https://localhost:44358/api/Users/${username}`, {
        method: "PUT", // *GET, POST, PUT, DELETE, etc.
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(
            {
                Email: email.value,
                HomePhone: homephone.value,
                CellPhone: cellhone.value
            })

    })
        .then((response) => {
            return response;
        })
        .then((response) => {
            if (response.ok)
                window.location = 'profile.html';
        })
        .catch((err) => console.log(err));
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function Rebuild() {
    email.setAttribute('value', user.email);
    homephone.setAttribute('value', user.homePhone);
    cellphone.setAttribute('value', user.cellPhone);
}

document.addEventListener('DOMContentLoaded', () => {
    const username = getCookie('username');
    email = document.getElementById('email');
    homephone = document.getElementById('homephone');
    cellphone = document.getElementById('cellphone');
    submit = document.getElementById('submit');
    errormsg = document.getElementById('errormsg');
    GetUser(username);
    submit.addEventListener('click', () => {
        UpdateUser(username);
    });
})
