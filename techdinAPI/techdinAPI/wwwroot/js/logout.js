
function Logout(){
    fetch('https://localhost:44358/api/logout/', {
    method: "POST" // *GET, POST, PUT, DELETE, etc.
})
.then(response => {
    console.log(response);
    return response;
})
.then((data) => {
    console.log(data);
    window.location = "index.html";
})
.catch((err) => console.log(err));
}

document.addEventListener('DOMContentLoaded', () => {
    const validateButton = document.getElementById('validate');
    validateButton.addEventListener('click', () => {
        Logout();
    })
})