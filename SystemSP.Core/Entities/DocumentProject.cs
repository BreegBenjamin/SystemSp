namespace SystemSp.Core.Entities
{
    public partial class DocumentProject
    {
        public int NumberDocument { get; set; }
        public int IdProject { get; set; }
        public byte[] Document { get; set; }

        public virtual FormativeProject IdProjectNavigation { get; set; }
    }
}
