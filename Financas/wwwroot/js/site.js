var form = document.querySelector(".login")
var formInputs = Array.from(form.querySelectorAll("input"))
console.log(formInputs)

form.addEventListener("submit", (event) => {
    event.preventDefault() }
    let formData = new FormData(form)
    let data = {
        Login: formInputs[0].value,
        Senha: formInputs[.valueue,
        RemenberformInputs[2].checked
    }
    console.log(JSON.stringify(data))
    let response = fetch(form.action, {
        method: "POST",
        credetials: "include",
        headers: {
            "Content-Type": "multipart/form-data"
        },
        redirect: "manual",
        body: JSON.stringify(data)
    }).then((response) => {
        let feedback = document.getElementById("server-feedback")
        if (response.status != 302) {
            //let message
            response.text().then((message) => {
                feedback.innerHTML = `<div class='alert alert-danger'> ${message}</div>`
            })
        }
    })

})

function createAlertDiv(text = "") {
    let div = document.createElement("div")
    div.classList.add("alert", "alert-danger")
    div.innerText = text
    return div
}

form.addEventListener("submit", (event) => {
    event.preventDefault()
    let formData = new FormData(form)
    let data = {
        Login: formInputs[0].value,
        Senha: formInputs[1].value,
        Remenber: formInputs[2].value
    }
    console.log(JSON.stringify(data))
    let response = fetch(form.action, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        redirect: "manual",
        body: JSON.stringify(data)
    }).then((response) => {
        let feedback = document.getElementById("server-feedback")
        if (response.status != 302) {
            //let message
            response.text().then((message) => {
                feedback.innerHTML = `<div class='alert alert-danger'> ${message}</div>`
            })
        }
    })

})

function createAlertDiv(text = "") {
    let div = document.createElement("div")
    div.classList.add("alert", "alert-danger")
    div.innerText = text
    return div
}

function getForm(formName) {
    let url = document.URL
    switch (formName) {
        case 'D':
            url = url.concat("Despesa/Create")
            var request = fetch(url).then(response => {
                return response.blob()
            }).then(body => {
                return body.text()
            }).then(text => {
                let formContainer = document.getElementById("formAdd")
                formContainer.innerHTML = text
            })
            console.log(request)
            break
    }

}