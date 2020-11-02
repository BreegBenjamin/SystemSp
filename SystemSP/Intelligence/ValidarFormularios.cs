using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SystemSP.Intelligence
{
    public class ValidarFormularios
    {
        public bool ValidaEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                if (m.Address.Contains("."))
                    return true;
                else return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool ValidaPassEmail(string pass1, string pass2) 
        {
            if (pass1 == pass2) return true;
            else return false;
        }
        public void ValidaInputLogin(string type) {
        
            
        }
    }
}
