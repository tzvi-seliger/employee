let user = '';
let isOwner = false; 
let avatar = '';
let name = '';
let description = '';
let linkedin = '';
let email = '';
let homephone = '';
let cellphone = '';

function changeStyle(selector, prop, val) {
    var elems = document.querySelectorAll(selector);
    Array.prototype.forEach.call(elems, function (ele) {
        ele.style[prop] = val;
    });
}
function GetUser(username) {
    fetch(`https://localhost:44358/api/Users/${username}`  , {
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

function ReloadUser() {
    let currentUser = window.location.hash;
    if (currentUser == '') {
        GetUser(getCookie('username'));
        isOwner = true;
    } else {
        GetUser(currentUser);
        isOwner = false;
    }
}

function Rebuild() {
    if (!isOwner)
        changeStyle('.edit', 'visibility', 'hidden');
    else
        changeStyle('.edit', 'visibility', 'visible')
    name.innerText = `${user.firstName} ${user.lastName}`;
    description.innerText = user.description;
    //avatar.setAttribute('src', user.imagePath);
    linkedin.setAttribute('href', user.linkedIn);
    email.innerText = `Email: ${user.email}`;
    homephone.innerText = `Home Phone: ${user.homePhone}`;
    cellphone.innerText = `Cell Phone: ${user.cellPhone}`;
}

document.addEventListener('DOMContentLoaded', () => {
    avatar = document.getElementById('avatar');
    name = document.getElementById('name');
    description = document.getElementById('description');
    linkedin = document.getElementById('linkedin');
    email = document.getElementById('email');
    homephone = document.getElementById('homephone');
    cellphone = document.getElementById('cellphone');
    ReloadUser();

    window.addEventListener('hashchange', () => {
        ReloadUser();
    });
})

