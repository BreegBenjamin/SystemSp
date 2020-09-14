namespace SystemSp.Core.Entities
{
    public partial class TeamProject
    {
        public int IdApprendice { get; set; }
        public int IdFirstUser { get; set; }
        public int IdProject { get; set; }
        public string NameApprendice { get; set; }
        public string LastNameAprendice { get; set; }
        public string MailAddress { get; set; }
        public int? Phone { get; set; }

        public virtual UserApprentice IdFirstUserNavigation { get; set; }
        public virtual FormativeProject IdProjectNavigation { get; set; }
    }
}
