using System;

namespace SystemSp.Intellengece.Entities
{
    public partial class LinkProject
    {
        public int IdLink { get; set; }
        public int? IdCompany { get; set; }
        public int? IdUser { get; set; }
        public string CompanyName { get; set; }
        public string ApprendiceName { get; set; }
        public DateTime? DateLinked { get; set; }
    }
}
