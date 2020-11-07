'Use Strict'

class FormLoginValidator {
    validarFormulario() {
        const inputEmail = document.getElementById("inputEmail").value;
        const mailFormat = /^[a-zA-Z0-9._-]+$+\@/;
        const salida = mailFormat.test(inputEmail)
        console.log(salida)
    }
}

var formulario = new FormLoginValidator();
