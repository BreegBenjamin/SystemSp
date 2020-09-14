using System;

namespace SystemSp.Intellengece.Entities
{
    public partial class CompanyRequest
    {
        public int IdRequirement { get; set; }
        public int? IdUser { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string DescriptionRequest { get; set; }
        public string NameRequest { get; set; }
        public bool? StateLinked { get; set; }
        public string Category { get; set; }
    }
}
