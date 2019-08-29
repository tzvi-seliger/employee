var user;

fetch('https://localhost:44358/api/CurrentUser/', {
    method: "GET", // *GET, POST, PUT, DELETE, etc.
})
.then(response => {
    return response.json();
})
.then((data) => {
    user = data;
})
.catch((err) => console.log(err));

function UploadFile(files){
    fetch('https://localhost:44358/api/Files/', {
    method: "POST", // *GET, POST, PUT, DELETE, etc.
    headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
    },
    body: files
})
.then(response => {
    return response.json();
})
.then((data) => {
    console.log(data);
})
.catch((err) => console.log(err));
}

function RemoveStuff(user){
   
        let container = document.querySelector('#pic');
        let resumeForm = document.querySelector('#resume');
        let imgForm = document.querySelector('#img');
        container.removeChild(resumeForm);
    
}

document.addEventListener('DOMContentLoaded', () => {

    // const resumeSubmit = document.getElementById('resumeSubmitButton');
    // const resumeFile = document.getElementById('resumeFile');
    // resumeSubmit.addEventListener('click', () =>{
    //     UploadFile(resumeFile.value)
    // })

    // const imgSubmit = document.getElementById('imgSubmitButton');
    // const imgFile = document.getElementById('imgFile');
    // imgSubmit.addEventListener('click', () =>{
    //     UploadFile(imgFile.value)
    // })
})