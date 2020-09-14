using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class EFormularioAprendizIn
    {
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "ProjectName too long(30 character limit).")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-z]+$")]
        public string NombreProyecto { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100, ErrorMessage = "Descripcion proyecto")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-z]+$")]
        public string DescripcionProjecto { get; set; }

        public string Categoria { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
        public string FechaFinProyecto 
        {
            get 
            {
                return $"{Dia}/{Mes}/{Anio}";
            } 
        }
        public string Departamento { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Ciudad Límite")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-z]+$")]
        public string Ciudad { get; set; }
    }
}