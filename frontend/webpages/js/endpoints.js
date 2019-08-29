//add in all endpoints
/*****Pending*****/
// GET: api/Search/5
// POST: api/Search
// PUT: api/Search/5
// DELETE: api/ApiWithActions/5

/// Will update user info based on fields entered. 
// PUT: api/Users/exampleUsername

// DELETE: api/ApiWithActions/5

function api(id) {
    return {
        /// Creates a user and adds it to the database, requires a form to POST
        // returns bool
        // POST: api/Users
        createUser: {
            endpoint: "https://localhost:44358/api/Users"
        },
        /// Gets a users' information based on a username. Get via URI
        //return object
        // GET: api/Users/exampleUsername
        getUser: {
            endpoint: `https://localhost:44358/api/users/${id}`
        },
        /// Retrieves a list of all users from our database. Get
        //GET: api/Users
        //returns object
        getUsers: {
            endpoint: `https://localhost:44358/api/Users`
        },
        /// Checks if a users' login information matches what is in the database
        // returns bool
        // GET: api/Users/username/password
        checkLoginUser: {
            // endpoint: function (password) {
                // return `https://localhost:44358/api/Users/${id}/${password}`
            // }
            endpoint: `https://localhost:44358/api/Login`
        },
        updateUser: {
            endpoint: `https://localhost:44358/api/Users/${id}`
        },

        deleteUser: {
            endpoint: `https://localhost:44358/api/ApiWithActions/${id}`
        }
    }
};

let fetchFuncs = {
    responseFuncs: {
        std(response) {
            return response.json();
        }
    },
    dataFuncs: {
        std(data) {
        }
    },
    errorFuncs: {
        std(err) {
            if (err) console.log(err);
        }
    }
}

function get(endpoint, func) {
    fetch(endpoint)
        .then(fetchFuncs.responseFuncs.std)
        .then(function (data) {
            func(data)
        })
        .then(fetchFuncs.errorFuncs.std)
}

function post(endpoint, formID, func) {
    let formData = new FormData(document.getElementById(formID));
    fetch(endpoint, {
        body: formData,
        method: "POST"
    }).then(function (response) {
        console.log(response)
    }).then(function (data) {
        if (func) func(data)
    })
}

function put(endpoint, formID, func) {
    let formData = new FormData(document.getElementById(formID));
    fetch(endpoint, {
        body: formData,
        method: "PUT"
    }).then(function (response) {
        console.log(response)
    }).then(function (data) {
        if (func) func(data)
    })
}

function decodeuserparam() {
    let spliturl = window.location.href.split("?")[1]
    return decodeURIComponent(spliturl).split("=")[1]
}

function isUserValid(data) {
    if (data) {
        console.log(data)
        window.location = `profile.html?username=${elID("loginusername").value}`
    } else {
        elID("loginusername").style.border = "1px solid red"
        elID("loginpassword").style.border = "1px solid red"
        document.body.innerHTML += "<span>login is incorrect</span>"
    }
}

let allUsers = (data) => data.forEach(element => elID("users").innerHTML += `<td><a href='userprofile.html?username=${element["username"]}'>${element["username"]}</a></td>`)

function UsersSearch(data, dbfield, searchfieldID, resultsFieldID) {
    console.log(data)
    elID(resultsFieldID).innerHTML = ""
    data.forEach(element => {
        if (element[dbfield]) {
            if (element[dbfield].substring(0, elID(searchfieldID).value.length).toLowerCase() ===
                elID(searchfieldID).value.toLowerCase()) {
                elID(resultsFieldID).innerHTML += `<li><a href='userprofile.html?username=${element["username"]}'>${element[dbfield]}</a></li>`
            } else {
                console.log("NOT A MATCH")
            }
        }
    })
}

function UsersSearchUpdated(data, dbfield, searchfieldID) {
    let collection = []
    data.forEach(element => {
        if (element[dbfield]) {
            if (element[dbfield].substring(0, elID(searchfieldID).value.length).toLowerCase() ===
                elID(searchfieldID).value.toLowerCase()) {
                collection.push(element)
            } else {
                console.log("NOT A MATCH")
            }
        }
    })
    return collection
}


function getUser(data) {
    elID("firstName").innerHTML = data["firstName"]
}

