using System.Collections.Generic;

namespace SystemSp.Intellengece.Entities
{
    public partial class UserCompany
    {
        public int IdCompany { get; set; }
        public int IdUser { get; set; }
        public string CompanyName { get; set; }
        public string AddressCompany { get; set; }
        public int? NumRequest { get; set; }
    }
}
