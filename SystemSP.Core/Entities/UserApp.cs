using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UserApp
    {
        public UserApp()
        {
            UserAdmin = new HashSet<UserAdmin>();
            UserApprentice = new HashSet<UserApprentice>();
            UserCompany = new HashSet<UserCompany>();
            FormativeProject = new HashSet<FormativeProject>();
        }

        public int IdUser { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool? StateBond { get; set; }
        public string EmaiAddress { get; set; }
        public string UserPassword { get; set; }
        public int? UserType { get; set; }
        public DateTime? DateCreation { get; set; }
        public byte[] ImageUser { get; set; }

        public virtual ICollection<CompanyRequest> CompanyRequest { get; set; }
        public virtual ICollection<FormativeProject> FormativeProject { get; set; }
        public virtual ICollection<UserAdmin> UserAdmin { get; set; }
        public virtual ICollection<UserApprentice> UserApprentice { get; set; }
        public virtual ICollection<UserCompany> UserCompany { get; set; }
    }
}
