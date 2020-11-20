using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;

namespace SystemSp.Intellengece.ApplicationBusiness
{
    public class SendEMailUser
    {
        public async Task<bool> SendEmail(string email)=> await _sendEmail(email);
        private async Task<bool> _sendEmail(string email) 
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.Subject = "Recuperación Contraseña SystemSP";
                //Tipo de codificación del asunto
                mailMessage.SubjectEncoding = Encoding.UTF8;

                //Cuerpo del Mensaje en formato UTF8
                mailMessage.Body = _createHtmlText();
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress("systemSp2020@gmail.com");

                //server host y puerto
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential("systemSp2020@gmail.com", "1821996Kajar."),
                    EnableSsl = true
                };

                //Puerto de salida del servidor de salida
                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                string ms = ex.Message;
                return false;
            }
        }
        private string _createHtmlText() 
        {
            return $"<h1>Recuperar Contraseña</h1>";
        }
    }
}
