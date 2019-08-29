{/* <div id="header">
    <div id="logo">
        <a href="landing.html">
            <img id="logoimg" src="https://static1.squarespace.com/static/55ef2da9e4b03f6e1ef0cd28/t/5a2857720d9297ab4724efd5/1555346130603/?format=1500w" />
        </a>
    </div>

    <div id="loginform">
        <form>
            <input id="username" type="text" placeholder="username">
                <input id="password" type="password" placeholder="password">
                    <div id="validate">login</div>
    </form>
</div>
</div>
 */}
function banner() {
    let logo = document.createElement("div")
    let header = document.createElement("div")
    let home = document.createElement("a")
    let logoimg = document.createElement("img")
    let loginform = document.createElement("div")
    let usernamelogin = document.createElement("input")
    let passwordlogin = document.createElement("input")
    let validate = document.createElement("div")







    logo.setAttribute("id", "logo")

    header.setAttribute("id", "header")

    home.setAttribute("href", "landing.html")

    logoimg.setAttribute("src", "https://static1.squarespace.com/static/55ef2da9e4b03f6e1ef0cd28/t/5a2857720d9297ab4724efd5/1555346130603/?format=1500w")
    logoimg.setAttribute("id", "logoimg")

    loginform.setAttribute("id", "loginform")

    let form = document.createElement("form")

    usernamelogin.setAttribute("id", "usernamelogin")
    usernamelogin.setAttribute("placeholder", "uername")

    passwordlogin.setAttribute("id", "passwordlogin")
    passwordlogin.setAttribute("type", "password")
    passwordlogin.setAttribute("placeholder", "password")

    validate.setAttribute("id", "validate")
    validate.innerText = "Login"

    home.appendChild(logoimg)
    logo.appendChild(home)

    form.appendChild(usernamelogin)
    form.appendChild(passwordlogin)
    form.appendChild(validate)

    loginform.appendChild(form)

    header.appendChild(logo)
    header.appendChild(loginform)

    document.getElementById("body").appendChild(header)
}










