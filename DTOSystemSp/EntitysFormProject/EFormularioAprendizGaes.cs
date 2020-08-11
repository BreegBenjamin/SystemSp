using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DTOSystemSp.EntitysFormProject
{
    public class EFormularioAprendizGaes
    {
        [Required]
        [StringLength(60, ErrorMessage = "Nombre Sena")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-z]+$")]
        public string NombreDireccionSena { get; set; }
        public EIntegrantesGaes IntegrantesGaes { get; set; }
    }
}
