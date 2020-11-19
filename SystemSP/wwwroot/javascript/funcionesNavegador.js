'use strict'
class ScrollTarjetas {
    
    MovertarjetasIzquierda() {
        const plantilla = document.getElementById('plantillaProyecto');
        plantilla.scrollLeft -= plantilla.offsetWidth;
    }
    MovertarjetasDerecha() {
        const plantilla = document.getElementById('plantillaProyecto');
        plantilla.scrollLeft += plantilla.offsetWidth;
    }
    MoverCategoriasDerecha()
    {
        const navApp = document.getElementById("listaCategoriasApp");
        navApp.scrollLeft += navApp.offsetWidth;
    }
    MoverCategoriasIzquierda() {
        const navApp = document.getElementById("listaCategoriasApp");
        navApp.scrollLeft -= navApp.offsetWidth;
    }
}
class ScrollBody
{
    DeshabilitarScroll(esLogin) {
        const ModalRegistro = document.getElementById("ModalRegistro");
        const ModalLogin = document.getElementById("ModalLogin");
        if (ModalRegistro != null && esLogin === false)
            ModalRegistro.className = "fondo";
        if (ModalLogin != null && esLogin === true)
            ModalLogin.className = "fondo";
        this.DeshabilitarScrollPage();
    }
    HabilitarScroll() {
        const ModalRegistro = document.getElementById("ModalRegistro");
        const ModalLogin = document.getElementById("ModalLogin");
        if (ModalRegistro != null)
            ModalRegistro.className = "OcultarModal";
        if (ModalLogin != null)
            ModalLogin.className = "OcultarModal";
        document.getElementsByTagName('body')[0].style.overflow = null;
    }
    DeshabilitarScrollPage()
    {
        document.getElementsByTagName('body')[0].style.overflow = 'hidden';
    }
}
class AlertasApp
{
    MostrarAlerta()
    {
        const alertApp = document.querySelector("#alertApp");
        if (alertApp != null) {
            alertApp.classList.add("show");
            alertApp.classList.remove("hide");
            alertApp.classList.add("showAlert");
            setTimeout(() => {
                alertApp.classList.remove("show");
                alertApp.classList.add("hide");
            }, 5000);
        }
        else
            console.log("NoOk")
    }
    OcultarAlerta()
    {
        const alertApp = document.getElementById("alertApp");
        alertApp.classList.remove("show");
        alertApp.classList.add("hide");
    }
}
class SweetAlertMensajes
{
    SweetMensaje(msEmail,msPass, msExtra)
    {
		Swal.fire({
			//title:
			// text:
            html: `<div class="sweetAlertData">
                    <span>
                        <img src="/images/img_proyect/alert.svg" width="50" height="50"/>
                    </span>
                    <p>${msEmail}</p>
                    <p>${msPass}</p>
                    <p>${msExtra}</p>
                    </div>`,
			//icon:
			confirmButtonText: 'Aceptar',
			//footer:
			// width:
			// padding:
			// background:
			// grow:
			// backdrop:
			timer: 5000,
			timerProgressBar: true,
			toast: true,
			position: 'top-end',
            // allowOutsideClick: false,
			//allowEscapeKey: false,
			//allowEnterKey: true,
			//stopKeydownPropagation: false,

			// input:
			// inputPlaceholder:
			// inputValue:
			// inputOptions:

            customClass: {
                // 	container:
                popup: 'estilosBordes',
			    // 	header:
			    // 	title:
			    // 	closeButton:
			    // 	icon:
			    // 	image:
			    // 	content:
			    // 	input:
			    // 	actions:
                confirmButton: 'btGuardar btConfi'
			    // 	cancelButton:
			    // 	footer:	
            },

			showConfirmButton: false,
			// confirmButtonColor:
			// confirmButtonAriaLabel:

			// showCancelButton:
			// cancelButtonText:
			// cancelButtonColor:
			// cancelButtonAriaLabel:

			buttonsStyling: false
			// showCloseButton:
			// closeButtonAriaLabel:


			// imageUrl:
			// imageWidth:
			// imageHeight:
			// imageAlt:
		});
    }
    SweetMensajeAprendiz(ms)
    {
        Swal.fire({
            html: `<div class="DivUsuario">
                    <p>${ms}</p>
                    <div class="classAprendiceBoton">x</div>
                    </div>`,
            timer: 5000,
            timerProgressBar: true,
            toast: true,
            position: 'bottom-start',
            showConfirmButton: false,
        });
    }
    SweetMensajeProyecto(ms, imagen)
    {
        Swal.fire({
            html: `<div class="sweetAlertData">
                    <span>
                        <img src="/images/img_proyect/${imagen}.svg" width="50" height="50"/>
                    </span>
                    <p>${ms}</p>
                    </div>`,
            position: 'center',
            });
    }
}
class CanvasEstadisticas
{
    CrearCanvas()
    {
        const ctx = document.getElementById('chartBarra').getContext('2d');
        const ctx2 = document.getElementById('chartTorta').getContext('2d');
        const myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
                datasets: [{
                    label: '# of Votes',
                    data: [12, 19, 3, 5, 2, 3],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
        const myChart2 = new Chart(ctx2, {
            type: 'pie',
            data: {
                labels: ['Red', 'Blue', 'Yellow', 'Green'],
                datasets: [{
                    label: '# of Votes',
                    data: [12, 19, 3, 5, 2, 3],
                    backgroundColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                    ],
                    borderWidth: 1
                }]
            }
        });
    }
}
function CambiarIdInput() {
    let spam = document.getElementById("spanOcultoDocumento");
    let spam2 = document.getElementById("spanOcultoImages");
    spam.firstElementChild.id = "archivoDocumentos";
    spam2.firstElementChild.id = "archivoImage";
}
var scroll = new ScrollTarjetas();
var salirMenu = new ScrollBody();
var alerta = new AlertasApp();
var seetAlert = new SweetAlertMensajes();
var canvas = new CanvasEstadisticas();
