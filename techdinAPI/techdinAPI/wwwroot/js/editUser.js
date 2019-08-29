let first = '';
let last = '';
let description = '';
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
                FirstName: first.value,
                LastName: last.value,
                Description: description.value
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
    first.setAttribute('value', user.firstName);
    last.setAttribute('value', user.lastName);
    description.innerText = user.description;
}

document.addEventListener('DOMContentLoaded', () => {
    const username = getCookie('username');
    first = document.getElementById('first');
    last = document.getElementById('last');
    description = document.getElementById('description');
    submit = document.getElementById('submit');
    errormsg = document.getElementById('errormsg');
    GetUser(username);
    submit.addEventListener('click', () => {
        UpdateUser(username);
    });
})
