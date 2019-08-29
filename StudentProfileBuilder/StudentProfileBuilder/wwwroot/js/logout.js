
function Logout(){
    fetch('https://localhost:44358/api/CurrentUser/', {
    method: "POST" // *GET, POST, PUT, DELETE, etc.
})
.then(response => {
    console.log(response);
    return response.json();
})
.then((data) => {
    console.log(data);
})
.catch((err) => console.log(err));
}

document.addEventListener('DOMContentLoaded', () =>{
    let logoutButton = document.createElement('div');
    logoutButton.innerText = 'Logout';
    let body = document.querySelector('body');
    body.appendChild(logoutButton);
    logoutButton.setAttribute('id', 'logout');
    logoutButton.addEventListener('click', () =>{
        Logout();
    })
})