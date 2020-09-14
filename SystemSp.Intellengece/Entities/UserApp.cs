using System;

namespace SystemSp.Intellengece.Entities
{
    public partial class UserApp
    {
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
    }
}
