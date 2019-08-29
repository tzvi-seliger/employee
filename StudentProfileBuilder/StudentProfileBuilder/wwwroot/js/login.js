
function Login(username, password) {
    fetch('https://localhost:44358/api/CurrentUser/' + username + '/' + password, {
        method: "GET" // *GET, POST, PUT, DELETE, etc.
    })
        .then(response => {
            return response.json();
        })
        .then((data) => {
            user = data;
            console.log(data)
            //window.location = `/html/profile.html?username=${user["username"]}`

        })
        .catch((err) => console.log(err));
}

const validateButton = document.getElementById('validate');
validateButton.addEventListener('click', () => {
    let usernameInput = document.getElementById('loginusername').value;
    let passwordInput = document.getElementById('loginpassword').value;
    Login(usernameInput, passwordInput);
})
