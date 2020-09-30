namespace SystemSp.DTOS.EntitisProjectsApp
{
    public class UpdateDataProject
    {
        public int IdApprentice { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
        public string Estado { get; set; }
        public AprenticeDetails  Aprentice  { get; set; }
    }
    public class AprenticeDetails 
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
