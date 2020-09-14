using System;

namespace SystemSp.Core.Entities
{
    public partial class LinkProject
    {
        public int IdLink { get; set; }
        public int? IdCompany { get; set; }
        public int? IdUser { get; set; }
        public string CompanyName { get; set; }
        public string ApprendiceName { get; set; }
        public DateTime? DateLinked { get; set; }

        public virtual UserCompany IdCompanyNavigation { get; set; }
        public virtual UserApprentice IdUserNavigation { get; set; }
    }
}
