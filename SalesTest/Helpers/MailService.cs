using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace SalesTest.Helpers
{
    /// <summary>
    /// Clase para envio de correos
    /// </summary>
    public class MailService
    {
        /// <summary>
        /// Variables de inyeccion
        /// </summary>
        IConfiguration _configuration;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration"></param>
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Envia un correo para alertar desabasto de mercancia
        /// </summary>
        /// <param name="idProducto">Identificador del producto</param>
        /// <param name="stock">Numero de productos que quedan</param>
        public void SendEmail(int idProducto, int stock)
        {
            try
            {
                String userEmail = this._configuration["Email:User"];
                String passwordEmail = this._configuration["Email:Password"];

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(userEmail);
                mail.To.Add(new MailAddress(this._configuration["Email:Receiver"]));
                mail.Subject = "Aviso de desabasto de mercancias";
                mail.Body = $"Quedan {stock} piezas en stock del producto con el identificador {idProducto}";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                String smtpserver = this._configuration["Email:Host"];
                int port = int.Parse(this._configuration["Email:Port"]);
                bool ssl = bool.Parse(this._configuration["Email:SslGmail"]);
                bool defaultCredential = bool.Parse(this._configuration["Email:DefaultcredentialsGmal"]);

                SmtpClient smtpClient = new SmtpClient
                {
                    Host = smtpserver,
                    EnableSsl = ssl,
                    Port = port,
                    UseDefaultCredentials = defaultCredential
                };

                NetworkCredential userCredential = new NetworkCredential(userEmail, passwordEmail);
                smtpClient.Credentials = userCredential;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {

                ;
            }
        }
    }
}
