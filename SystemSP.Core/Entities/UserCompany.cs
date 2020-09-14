using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UserCompany
    {
        public UserCompany()
        {
            CompanyRequest = new HashSet<CompanyRequest>();
            LinkProject = new HashSet<LinkProject>();
        }

        public int IdCompany { get; set; }
        public int IdUser { get; set; }
        public string CompanyName { get; set; }
        public string AddressCompany { get; set; }
        public int? NumRequest { get; set; }

        public virtual UserApp IdUserNavigation { get; set; }
        public virtual ICollection<CompanyRequest> CompanyRequest { get; set; }
        public virtual ICollection<LinkProject> LinkProject { get; set; }
    }
}
