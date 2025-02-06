const formInput = document.querySelectorAll(".form-control");
(function () {
    emailjs.init({
        publicKey: "EW_BngZpDF48NcSYA",
    });
})();
window.onload = function () {
    document.getElementById('contact-form').addEventListener('submit', function (event) {
        if (localStorage.getItem("login") === "true") {
            if (!formInput[4].value) {
                alert("Please, Write Message")
            } else {
                formInput[0].value = localStorage.getItem("fullname")
                formInput[3].value = localStorage.getItem("email")
                event.preventDefault();
                emailjs.sendForm('service_7dsmngk', 'template_2rh3b2i', this)
                    .then(() => {
                        console.log('SUCCESS!');
                        alert("Succesful")
                    }, (error) => {
                        console.log('FAILED...', error);
                    });
            }
        } else {
            if (!formInput[0].value || !formInput[1].value || !formInput[2].value || !formInput[3].value || !formInput[4].value) {
                alert("Please, Fill Input");
            } else {
                event.preventDefault();
                emailjs.sendForm('service_7dsmngk', 'template_2rh3b2i', this)
                    .then(() => {
                        console.log('SUCCESS!');
                        alert("Succesful")
                    }, (error) => {
                        console.log('FAILED...', error);
                    });
            }
        }
    });
}