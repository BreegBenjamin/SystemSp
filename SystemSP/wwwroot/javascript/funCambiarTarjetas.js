'use strict'

class CambiarTarjetas
{
    CambiarBotones(numeroEntrada)
    {
        switch (numeroEntrada) {

            case "0":
                this.CambiarEstilos(1, 'team-No.svg')
                this.CambiarEstilos(2, 'project-No.svg')
                this.CambiarEstilos(3, 'work-No.svg')
                this.CambiarEstilos(0, 'work.svg', true)
                break

            case "1":
                this.CambiarEstilos(0, 'work-No.svg')
                this.CambiarEstilos(2, 'project-No.svg')
                this.CambiarEstilos(3, 'work-No.svg')
                this.CambiarEstilos(1, 'team.svg', true)
                break

            case "2":
                this.CambiarEstilos(0, 'work-No.svg')
                this.CambiarEstilos(1, 'team-No.svg')
                this.CambiarEstilos(3, 'work-No.svg')
                this.CambiarEstilos(2, 'project.svg', true)
                break

            case "3":
                this.CambiarEstilos(0, 'work-No.svg')
                this.CambiarEstilos(1, 'team-No.svg')
                this.CambiarEstilos(2, 'project-No.svg')
                this.CambiarEstilos(3, 'work.svg', true)
                break
        }
    }
    CambiarEstilos(numEntrada, imagen, cambiar) {
        const urlImage = "/images/IconosCategorias/AdminIcons/";
        const boton = document.getElementById("botonAdmin_" + numEntrada)
        const div = document.getElementById("divCard_" + numEntrada)
        const image = document.getElementById("ImageAdmin_" + numEntrada)
        if (cambiar) {
            boton.classList = "botonInfoAdmin  ColorBotonHanddler"
            div.classList = "CategoriaAdminBorder colorCategoriAdmin"
            image.src = `${urlImage}${imagen}`
        }
        else
        {
            boton.classList = "botonInfoAdmin  ColorBotonNoHanddler"
            div.classList = "CategoriaAdminBorder colorCategoriaUnAdmin"
            image.src = `${urlImage}${imagen}`
        }
    }
    CambiarColorCategoria(numeroEntrada)
    {
        switch (numeroEntrada)
        {
            case "1":
                this.CambiarEstilosCategoria(1, true)
                this.CambiarEstilosCategoria(2)
                this.CambiarEstilosCategoria(3)
                this.CambiarEstilosCategoria(4)
                break;
            case "2":
                this.CambiarEstilosCategoria(1)
                this.CambiarEstilosCategoria(2, true)
                this.CambiarEstilosCategoria(3)
                this.CambiarEstilosCategoria(4)
                break;
            case "3":
                this.CambiarEstilosCategoria(1)
                this.CambiarEstilosCategoria(2)
                this.CambiarEstilosCategoria(3, true)
                this.CambiarEstilosCategoria(4)
                break;
            case "4":
                this.CambiarEstilosCategoria(1)
                this.CambiarEstilosCategoria(2)
                this.CambiarEstilosCategoria(3)
                this.CambiarEstilosCategoria(4, true)
                break;
        }
    }
    CambiarEstilosCategoria(numeroEntrada, cambiar = false)
    {
        const image = document.getElementById("tick_" + numeroEntrada)
        const silueta = document.getElementById("silueta_" + numeroEntrada)
        const contenedor = document.getElementById("categoriaDiv_" + numeroEntrada)
        if (cambiar) {
            image.src = "/images/IconosCategorias/IconosColor/tick.svg"
            silueta.classList = "siluetaColor"
            contenedor.classList = "colorCategoriaSelect BorderStyleCategoria"
        }
        else {

            image.src = "/images/IconosCategorias/tick.svg"
            silueta.classList = "siluetaSinColor"
            contenedor.classList = "colorCategoriaUnSelect BorderStyleCategoria"
        }
    }
}
var tarjetasApp = new CambiarTarjetas();
