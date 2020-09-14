using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UserApprentice
    {
        public UserApprentice()
        {
            LinkProject = new HashSet<LinkProject>();
            TeamProject = new HashSet<TeamProject>();
        }

        public int IdApprendice { get; set; }
        public int IdUser { get; set; }
        public string NumProject { get; set; }

        public virtual UserApp IdUserNavigation { get; set; }
        public virtual ICollection<LinkProject> LinkProject { get; set; }
        public virtual ICollection<TeamProject> TeamProject { get; set; }
    }
}
