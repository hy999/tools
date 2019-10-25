using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace tools.Controllers
{
    public class EmailController : Controller
    {
        // GET
        [HttpPost]
        [Route("api/v1/Email/smtp")]
        public string smtp(string fromeEmail,string toEmail,string emailTitle,string emailContent,string emailPasswd,string emailHost,bool isSSL,bool isHtml,string resText)
        {
            if (string.IsNullOrEmpty(fromeEmail)||string.IsNullOrEmpty(toEmail)||string.IsNullOrEmpty(emailTitle)||string.IsNullOrEmpty(emailContent)||string.IsNullOrEmpty(emailPasswd)||string.IsNullOrEmpty(emailHost)||string.IsNullOrEmpty(isSSL.ToString())||string.IsNullOrEmpty(isHtml.ToString()))
            {
                resText = "There was an err!";
                return resText;
            }

            MailAddress from = new MailAddress(fromeEmail);
            MailMessage message = new MailMessage();
            message.Body = emailContent;
            message.IsBodyHtml = isHtml;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            //收件人地址
            message.To.Add(toEmail);
            message.Subject = emailTitle;
            message.SubjectEncoding = System.Text.Encoding.UTF8; 
            message.From = from;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Host = emailHost;
            if (isSSL == true)
            {
                client.Port = 465;
            }
            else
            {
                client.Port = 25;
            }
            //邮箱账户和密码
            client.Credentials = new System.Net.NetworkCredential(fromeEmail,emailPasswd);
            try
            {
                client.Send(message);
                resText = "success!";
            }
            catch (Exception ex)
            {
                resText = ex.ToString();
            }

            return resText;
        }
    }
}