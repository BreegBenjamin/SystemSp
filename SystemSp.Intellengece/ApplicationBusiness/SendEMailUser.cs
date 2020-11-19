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
                mailMessage.From = new MailAddress("");

                //server host
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Credentials = new NetworkCredential("", "");
                //puerto de email
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;

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
