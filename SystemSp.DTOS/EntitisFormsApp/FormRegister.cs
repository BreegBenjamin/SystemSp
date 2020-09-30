using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormRegister
    {
        public string Email { get; set; }
        public string EmailConfirm { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificacionType { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string NameUser { get; set; }
        public string LastNameUser { get; set; }
        public string Telephone { get; set; }
        public int UserType { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
    }
}
