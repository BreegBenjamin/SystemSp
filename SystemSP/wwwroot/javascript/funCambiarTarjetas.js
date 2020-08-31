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
                this.CambiarEstilos(3, 'team.svg', true)
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
}
var tarjetasApp = new CambiarTarjetas();
