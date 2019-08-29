(function () {
    let current_user, fname_b = false, lname_b = false,
        uname_b = false, pw_b = false, cpw_b = false,
        email_b = false, cemail_b = false, username,
        selectors = {
            userButton: document.getElementById("createuserbutton"),
            userData: document.getElementById("getuserdata")
        },
        elements = {
            firstInput: {
                selector: selectors.userButton,
                events: {
                    "mouseleave": [
                    ],
                    "mouseenter": [
                    ],
                    "click": [
                        function fn_specs() {
                            let el = document.getElementById("first_name")
                            let err = document.getElementById("fn_error")
                            if (el.value.length > 5) {

                                el.style.border = "1px solid red"
                                err.style.color = "red"
                                err.innerHTML = "should be less than 5"

                            } else if (el.value.length == 0) {

                                el.style.border = "1px solid red"
                                err.style.color = "red"
                                err.innerHTML = " First name is required"

                            } else {

                                el.style.border = "none"
                                err.style.color = "black"
                                err.innerHTML = ""
                                fname_b = true

                            }
                        },
                        function un_specs() {
                            //unique in database
                            //length is less than 20, more than 5
                            let username = document.getElementById("user_name"),
                                un_err = document.getElementById("un_error")
                            if (username.value.length == 0) {
                                username.style.border = "1px solid red"
                                un_err.style.color = "red"
                                un_err.innerHTML = " Username is required"
                            } else {
                                lname_b = true
                                uname_b = true
                            }
                        },
                        function pw_specs() {
                            let pw = document.getElementById("password"),
                                pw_err = document.getElementById("pw_error")

                            if (pw.value.length == 0) {
                                pw.style.border = "1px solid red"
                                pw_err.style.color = "red"
                                pw_err.innerHTML = "Password is required"
                            } else {
                                pw_b = true
                            }
                            //length is less than 30, more than 10 
                        },
                        function pwc_specs() {
                            //matches_pw 
                            let p = document.getElementById("password")
                            let cp = document.getElementById("confirm_password")
                            let cp_err = document.getElementById("cp_error")
                            if (cp.value !== p.value) {
                                cp_err.innerHTML = "Passwords don't match"
                                cp.style.border = "1px solid red"
                                cp_err.style.color = "red"
                            } else {
                                cpw_b = true
                            }
                        },
                        function email_specs() {
                            //in valid email 
                            let email = document.getElementById("email"),
                                email_err = document.getElementById("email_error")

                            if (email.value.length == 0) {
                                email.style.border = "1px solid red"
                                email_err.style.color = "red"
                                email_err.innerHTML = "email is required"
                            } else {
                                email_b = true

                            }
                        },
                        function emailc_specs() {
                            //matches email field
                            cemail_b = true

                        },
                        function sendForm() {
                            if (fname_b && lname_b && uname_b
                                && pw_b && cpw_b && email_b && cemail_b) {
                                username = document.getElementById("user_name").value
                                
                                post(api().createUser.endpoint, 'create_user_form', function(){
                                    get(api(username).getUser.endpoint, function(data){
                                        {
                                            //window.location = `profile.html?username=${data["username"]}`
                                            window.location = `Users/${data["username"]}`
                                        }
                                    })
                                })
                                //createUserForm.submit()
                            }
                        }
                    ]
                }
            },
            windowObj: {
                selector: window,
                events: {
                    "load": [
                        function makeBlack() {
                            let body = document.querySelector("body"),
                                input = document.querySelectorAll("input"),
                                label = document.querySelectorAll("label")
                            for (i = 0; i < input.length; i++) {
                                input[i].style.display = "block"
                                input[i].style.margin = "auto"
                            }
                            for (i = 0; i < label.length; i++) {
                                label[i].style.display = "inline"
                                label[i].style.margin = "auto"
                                label[i].style.marginLeft = "40%"
                                label[i].style.color = "grey"
                            }
                            body.style.background = "black";
                            body.style.fontFamily = "verdana";
                            body.style.color = "white"
                        },
                        function makeFalse() {
                            fname_b = false, lname_b = false,
                                uname_b = false, pw_b = false, cpw_b = false,
                                email_b = false, cemail_b = false
                        }
                    ]
                }
            },
            getData: {
                selector: selectors.userData,
                events: {
                    "click": [
                    ]
                }
            },
            //validateLogin:{
            //    selector: elID("validate"),
            //    events: {
            //        click: [
            //            function(){
            //                document.getElementById("validate").addEventListener("click", function () {
            //                    let username = elID("username1").value
            //                    let password = elID("password1").value
            //                    get(api(username).checkLoginUser.endpoint(password), function (data) {
            //                        isUserValid(data)
            //                    })
            //                })
            //            }
            //        ]
            //    }
            //}
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
    initListeners()
}())