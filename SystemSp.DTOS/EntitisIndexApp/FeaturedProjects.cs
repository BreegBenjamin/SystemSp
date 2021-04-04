using System.Collections.Generic;

namespace SystemSp.DTOS.EntitisIndexApp
{
    public class FeaturedProjects
    {
        public List<ProjectCard> ProjectCardList { get; set; }
    }
    public class ProjectCard
    {
        public string TituloProyecto { get; set; }
        public string ImagenUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NumeroCelular { get; set; }
        public string DireccionEmail { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }
    }
}
