var users = [];
var user;
const searchButton = document.getElementById('searchButton');
const usersContainer = document.getElementById('usersContainer')
const tableBody = document.getElementById('tableBody')

fetch('https://localhost:44358/api/CurrentUser/', {
    method: "GET" // *GET, POST, PUT, DELETE, etc.
})
.then(response => {
    return response.json();
})
.then((data) => {
    user = data;
})
.catch((err) => console.log(err));

function Search(season, location, skillName){
    fetch('https://localhost:44358/api/Search/', {
        method: "GET", // *GET, POST, PUT, DELETE, etc.
        headers: {
            season: season,
            location: location,
            skillName: skillName
            // "Content-Type": "application/x-www-form-urlencoded",
        }
    })
    .then(response => {
        return response.json();
    })
    .then((data) => {
        users = data;
        DisplayUsers();
    })
    .catch((err) => console.log(err));
}

function DisplayUsers(){
    tableBody.innerText = '';
    users.forEach((user) => {
        let tr = document.createElement('tr');
        let name = document.createElement('td');
        let username = document.createElement('td');
        
        name.innerText = user.FirstName;
        username.innerText = user.username;
        
        tr.appendChild(name);
        tr.appendChild(username);
        tableBody.appendChild(tr);
    })
}

document.addEventListener('DOMContentLoaded', () => {
    searchButton.addEventListener('click', () =>{
        let seasonInput = document.getElementById('season').value;
        let locationInput = document.getElementById('location').value;
        let skillInput = document.getElementById('skillName').value;
        Search(seasonInput, locationInput, skillInput);
    })
})