using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SystemSp.Intellengece.ApplicationBusiness
{
    public class SendEMailUser
    {
        public void SendEmail() 
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("direccionDestino");
            mailMessage.Subject = "Asunto";
            //Tipo de codificación del asunto
            mailMessage.SubjectEncoding = Encoding.UTF8;

            //Cuerpo del Mensaje en formato UTF8
            mailMessage.Body = _createHtmlText();
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("Email destino");

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("Direccion orign","contrseña");
            //puerto de email
            smtpClient.Port = 000;
            smtpClient.EnableSsl = true;

            //Puerto de salida del servidor de salida
            smtpClient.Host = "smtp.gmail.com"; //dominio
        }
        private string _createHtmlText() 
        {
            return $"";
        }
    }
}
