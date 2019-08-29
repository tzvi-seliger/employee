var user;

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