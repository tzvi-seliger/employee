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

function deleteCookie(cname) {
    document.cookie = cname + "=;expires=Thu, 01 Jan 1970 00:00:00 UTC; " + "path=/";
}

function Login(username, password) {
    fetch('https://localhost:44358/api/login/', {
        method: "POST", // *GET, POST, PUT, DELETE, etc.
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ UserName: username, Password: password })
    })
        .then(response => {
            return response;
        })
        .then((response) => {
            console.log(response);
            if (response.ok === true) {
                document.cookie = `username=${username}`;
                window.location = "profile.html";
            }
        })
        .catch((err) => console.log(err));
}

function Logout() {
    fetch('https://localhost:44358/api/logout/', {
        method: "POST" // *GET, POST, PUT, DELETE, etc.
    })
        .then(response => {
            console.log(response);
            return response;
        })
        .then((data) => {
            console.log(data);
            deleteCookie('username');
            window.location = "index.html";
        })
        .catch((err) => console.log(err));
}


document.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.getElementById('loginformform');
    const validateButton = document.getElementById('validate');
    const errorMsg = document.getElementById('errormsg');
    const username = document.getElementById('username');
    const password = document.getElementById('password');
    if (getCookie('username') !== '') {
        validateButton.innerText = 'Logout';
        username.style.display = 'none';
        password.style.display = 'none';
        validateButton.addEventListener('click', () => Logout());
    } else {
        validateButton.addEventListener('click', () => {
            Login(username.value, password.value);
            loginForm.reset();
            errorMsg.innerText = "Invalid Credentials";
        });
    }
})