var form = document.querySelector(".login")
var formInputs = Array.from(form.querySelectorAll("input"))

form.addEventListener("submit", (event) => {
    event.preventDefault()
    if (validateForm(form)) {
        let data = {
            login: formInputs[0].value,
            senha: formInputs[1].value,
            remember: formInputs[2].checked
        }
        request(form.action, data)
    }
})

function request(url, data) {
    let jsonData = JSON.stringify(data)
    let response = fetch(url, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: jsonData
    }).then((response) => {
        let feedback = document.getElementById("server-feedback")
        if (response.status != 200) {
            //let message
            response.text().then((message) => {
                feedback.innerHTML = `<div class='alert alert-danger'> ${message}</div>`
            })
        } else {
            window.location.href = response.url
        }
    })
}

function validateForm(form) {
    let formButton = form.querySelector("button")
    let formInputs = form.querySelectorAll("input.required")
    let inputEmail = form.querySelector("input .validate-email")
    let fieldsToCompare = form.querySelectorAll(".compare")
    let feedbacks = document.querySelectorAll(".invalid-feedback")
    let validationResult = true

    formInputs.forEach((input, index) => {
        input.addEventListener("input", (event) => {
            feedbacks[index].innerText = "O campo deve ser preenchido."
            validate(input)
        })
    })

    /*
    formButton.addEventListener("click", (event) => {
        validate(Array.from(formInputs))
        validateEmail(formInputs[0])
    })
    */
    if (formInputs !== null && formInputs !== undefined) {
        if (!validateInputs(Array.from(formInputs), Array.from(feedbacks))) {
            validationResult = false
        } else {
            if (inputEmail !== null && inputEmail !== undefined) {
                if (!validateEmail(inputEmail)) {
                    validationResult = false
                }
            }
            if (fieldsToCompare !== null && fieldsToCompare !== undefined) {
                if (!CompareFields(Array.from(fieldsToCompare))) {
                    Array.from(fieldsToCompare).forEach((e) => {
                        e.classList.add("is-invalid")
                    })
                    Array.from(form.querySelectorAll(".feedback-compare")).forEach((e) => {
                        e.innerText = "As senhas não correspondem."
                    })
                    validationResult = false
                }
            }
        }
    }
    return validationResult
}

function validateInputs(inputs, feedbacks) {
    let validationResult = true

    inputs.forEach((e, index) => {
        if (e.value == "") {
            e.classList.add("is-invalid")
            validationResult = false
            feedbacks[index].innerText = "O campo deve ser preenchido."
        } else {
            e.classList.remove("is-invalid")
        }
    })
    return validationResult
}

function validate(inputs) {
    if (Array.isArray(inputs)) {
        inputs.forEach((e) => {
            testValue(e)
        })
    } else {
        testValue(inputs)
    }
}

function testValue(input) {
    if (input.value == "") {
        input.classList.add("is-invalid")
    } else {
        input.classList.remove("is-invalid")
    }
}

function validateEmail(input) {
    let emailRegex = /\S+@\S+\.\S+/
    let divFeedback = document.querySelector(".email-feedback")
    if (emailRegex.test(input.value)) {
        input.classList.remove("is-invalid")
        return true
    } else {
        input.classList.add("is-invalid")
        divFeedback.innerText = "Insira um Email válido."
        return false
    }
}

function CompareFields(fields) {
    let divFeedback = document.querySelector(".invalid-feedback")
    let validationResult = true
    let compareValue

    //console.log(fields)
    compareValue = fields[0].value
    fields.forEach((e) => {
        if (e.value !== compareValue) {
            validationResult = false
        }
    })
    return validationResult
}

function createAlertDiv(text = "") {
    let div = document.createElement("div")
    div.classList.add("alert", "alert-danger")
    div.innerText = text
    return div
}

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