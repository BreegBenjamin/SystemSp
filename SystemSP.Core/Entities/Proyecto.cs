using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            DocumentosProyecto = new HashSet<DocumentosProyecto>();
            ImagenesProyecto = new HashSet<ImagenesProyecto>();
            IntegrantesProyecto = new HashSet<IntegrantesProyecto>();
            TecnologiasUtilizadas = new HashSet<TecnologiasUtilizadas>();
            Vinculacion = new HashSet<Vinculacion>();
        }

        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public int IdCreacion { get; set; }
        public int? IdVinculacion { get; set; }
        public string NombreProyecto { get; set; }
        public string Categoria { get; set; }
        public string DescripcionProyecto { get; set; }
        public DateTime? FechaFormacion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaEliminado { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public bool? EstadoActivo { get; set; }
        public int? NumeroDescargas { get; set; }
        public int? NumeroVisitas { get; set; }
        public string NombreSena { get; set; }

        public virtual UsuarioCreadorProyecto IdUsuarioNavigation { get; set; }
        public virtual ICollection<DocumentosProyecto> DocumentosProyecto { get; set; }
        public virtual ICollection<ImagenesProyecto> ImagenesProyecto { get; set; }
        public virtual ICollection<IntegrantesProyecto> IntegrantesProyecto { get; set; }
        public virtual ICollection<TecnologiasUtilizadas> TecnologiasUtilizadas { get; set; }
        public virtual ICollection<Vinculacion> Vinculacion { get; set; }
    }
}
