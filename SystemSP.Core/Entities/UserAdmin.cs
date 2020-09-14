using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UserAdmin
    {
        public UserAdmin()
        {
            CompanyRequest = new HashSet<CompanyRequest>();
        }

        public int IdAdmin { get; set; }
        public int IdUser { get; set; }
        public bool? AdminType { get; set; }

        public virtual UserApp IdUserNavigation { get; set; }
        public virtual ICollection<CompanyRequest> CompanyRequest { get; set; }
    }
}
