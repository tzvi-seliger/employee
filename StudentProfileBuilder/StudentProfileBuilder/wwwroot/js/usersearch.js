function header(id, row, text) {
    let input = document.createElement("input")
    let th = document.createElement("th")
    // let label = document.createElement("label")
    // label.innerHTML = text
    input.setAttribute("id", id)
    input.setAttribute("placeholder", text)
    th.setAttribute("class", "item")
    //th.appendChild(label)
    th.appendChild(input)
    row.appendChild(th)
}

function appendfirst() {
    let tr = document.createElement("tr")
    let thead = document.createElement("thead")

    header("searchusername", tr, "User Name");
    //header("searchfirstname", tr, "First Name");
    //header("searchlastname", tr, "Last Name");
    header("searchemail", tr, "Email");
    //header("searchheader", tr, "Header");
    header("searchhomephone", tr, "Home");
    header("searchcellphone", tr, "Cell");
    header("searchdescription", tr, "Description");
    header("searchcohortlocation", tr, "Location");
    header("searchcohortseason", tr, "Season");
    header("searchcohortstartdate", tr, "Start");
    header("searchcohortenddate", tr, "End");

    thead.appendChild(tr)
    elID("table").appendChild(thead)

}

function filter (data) {
    let filteredusername = UsersSearchUpdated(data, "username", "searchusername")
    //let  filteredfirstname = UsersSearchUpdated(filteredusername, "firstName", "searchfirstname")
    //let filteredlastname = UsersSearchUpdated(filteredfirstname, "lastName", "searchlastname")
    //let filteredemail = UsersSearchUpdated(filteredusername, "email", "searchemail")
    //let filteredheader = UsersSearchUpdated(filteredemail, "header", "searchheader")
    //let filteredhomephone = UsersSearchUpdated(filteredheader, "homePhone", "searchhomephone")
    //let filteredhomephone = UsersSearchUpdated(filteredemail, "homePhone", "searchhomephone")
    //let filteredcellphone = UsersSearchUpdated(filteredhomephone, "cellPhone", "searchcellphone")
    //let filtereddescription = UsersSearchUpdated(filteredcellphone, "description", "searchdescription")
    return filtereddescription
}


function cell(field, row, element) {
    let td = document.createElement("td")
    td.setAttribute("class", "item")
    td.innerHTML = element[field]
    row.appendChild(td)
}
let display = function (arr) {
    if (document.getElementById("table").querySelector("tbody")) {
        document.getElementById("table").querySelector("tbody").innerHTML = ""
    } else {
        tbody = document.createElement("tbody")
    }

    let tr

    arr.forEach(element => {
        tr = document.createElement("tr")

        cell("username", tr, element)
        //cell("firstName", tr, element)
        //cell("lastName", tr, element)
        //cell("email", tr, element)
        //cell("header", tr, element)
        //cell("homePhone", tr, element)
        //cell("cellPhone", tr, element)
        //cell("description", tr, element)

        tbody.appendChild(tr)
    });
    elID("table").appendChild(tbody)
}

function listen(id) {
    document.getElementById(id).addEventListener("keydown", function () {
        get(api().getUsers.endpoint, function (data) {
            console.log(filter(data))
            display(filter(data))
        })
    })
}

function listenAll() {
    listen("searchusername")
    //listen("searchfirstname")
    // listen("searchlastname")
    // listen("searchemail")
    // listen("searchheader")
    // listen("searchhomephone")
    // listen("searchcellphone")
    // listen("searchdescription")
}      

(function () {
    let tbody
    appendfirst()
    listenAll()
}())

      


      
        
      