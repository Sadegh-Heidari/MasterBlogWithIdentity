using System.Net;
using System.Net.Mail;
using System.Text;

namespace MasterIdentity.Utility
{
    public static class EmailSender
    {
        public static async Task Execute(string UserEmail, string Body, string Subject)
        {
            await Task.Run(() =>
            {
                var client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.Credentials = new NetworkCredential("gitsadegh.heidari@gmail.com", "khpkgkpsxispaxtz");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                var MailMessage = new MailMessage("gitsadegh.heidari@gmail.com", UserEmail,Subject,Body);
                MailMessage.BodyEncoding=Encoding.UTF8;
                MailMessage.IsBodyHtml = true;
                client.Send(MailMessage);
            });
        }
    }
}
