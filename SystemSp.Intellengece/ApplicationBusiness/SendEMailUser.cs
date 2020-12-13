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
                var rand = new Random();

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.Subject = "Recuperación Contraseña SystemSP";
                //Tipo de codificación del asunto
                mailMessage.SubjectEncoding = Encoding.UTF8;

                //Cuerpo del Mensaje en formato UTF8
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = _createHtmlText(rand.Next(999, 214748));
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.From = new MailAddress("systemSp2020@gmail.com");

                //server host, ´puerto y configuración del SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("systemSp2020@gmail.com", "1821996Kajar."),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
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
        private string _createHtmlText(int numRam) 
        {
            string cssContainer = $"box-shadow:0px 0px 1px 0px #CDCDCD; border:1px solid #CDCDCD;border-radius:5px";
            string cssH2 = "color:#fff;Font-size:1em;background-color:#28D1F2;box-size:border-box;padding:45px;margin:0;";
            string csscontainer = "text-align:justify;height:200px;padding:45px;background-color:#fff;";
            string cssCoder = "font-size:1em; text-align:center;";

            return $"<div style='{cssContainer}'>" +
                    $"<h2 style='{cssH2}'>Código de recuperación de contraseña </br> SystemSP</h2> " +
                     $"<div style='{csscontainer}'> " +
                           $"<label>Esté correo electronico se encuentra registrado en SystemSP </br>" +
                           $"Se ha solicitado el cambio de contraseña, ingrese el </br>" +
                           $"siguiente código en la plataforma : </label>" +
                           $"<b style='{cssCoder}'>{numRam}</b>" +
                    $"</div>  " +
                $"</div>";
        }
    }
}
