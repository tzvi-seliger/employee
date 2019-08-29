function elID(ID) {
    return document.getElementById(ID)
}

function headers() {
    let container = document.createElement("div")
    let users = document.createElement("a")
    users.setAttribute("href", "testusers.html")
    users.innerText = "See All Users"
    container.appendChild(users)
    document.body.appendChild(container)
}

function addEvent(event, target, func) {
    target.addEventListener(event, function () {
        func()
    })
}

function initListeners() {
    for (element in elements) {
        for (event in elements[element].events) {
            elements[element].events[event].forEach(function (item) {
                addEvent(event, elements[element].selector, item)
            })
        }
    }
}

function registerjs() {

    let listeners = document.createElement("script")
    listeners.setAttribute("src", "js/register_listeners.js")
    document.body.appendChild(listeners)

    let endpoints = document.createElement("script")
    endpoints.setAttribute("src", "js/endpoints.js")
    document.body.appendChild(endpoints)

}


//appends a profile thumbnail for user record in the database
function appendProfile(data, item) {
    let image = document.createElement("img")
    let content = document.createElement("div")
    let name = document.createElement("p")
    let overlay = document.createElement("div")
    let el = document.createElement("div")


    overlay.setAttribute("class", "overlay")
    content.setAttribute("class", "infooverlay")
    el.setAttribute("class", "fifth")
    name.innerText = data[item]["firstName"] + " " + data[item]["lastName"]
    image.src = `${data[item]["imagePath"]}`

    content.appendChild(name)
    el.appendChild(image)
    el.appendChild(content)
    el.appendChild(overlay)
    document.getElementById("profiles").appendChild(el)
    let clickpic = function (el, obj, key) {
        el.addEventListener("click", function () {
            window.location = `profile.html?username=${obj[key]["username"]}`
        })
    }
    clickpic(el, data, item)
}
