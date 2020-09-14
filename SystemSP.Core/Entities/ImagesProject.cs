namespace SystemSp.Core.Entities
{
    public partial class ImagesProject
    {
        public int ImageNumber { get; set; }
        public int IdProject { get; set; }
        public byte[] Imagen { get; set; }

        public virtual FormativeProject IdProjectNavigation { get; set; }
    }
}
