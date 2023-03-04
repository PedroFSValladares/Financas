export default function validateForm() {
    let forms = document.querySelectorAll(".require-validation")
    forms.forEach((form) => {
        let formButton = form.querySelector("button")
        let formInputs = form.querySelectorAll("input.required")
        let inputEmail = form.querySelector("input .validate-email")
        let fieldsToCompare = form.querySelectorAll(".compare")
        let feedbacks = document.querySelectorAll(".invalid-feedback")
        
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
        form.addEventListener("submit", (event) => {
            if (formInputs !== null && formInputs !== undefined) {
                if (!validateInputs(Array.from(formInputs), Array.from(feedbacks))) {
                    event.preventDefault()
                } else {
                    if (inputEmail !== null && inputEmail !== undefined) {
                        if (!validateEmail(inputEmail)) {
                            event.preventDefault()
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
                            event.preventDefault()
                        }
                    }
                }
            }
        })
    })
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
