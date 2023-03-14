//import { default as validate } from "./FormValidation.js"

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
//validate()