using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.SqlServer.Server;
using System.Net.Mail;
using Microsoft.SqlServer;
using System.IO;
using static System.Web.HttpServerUtilityBase;

namespace AssignmentPorfolio_MedVision.Utils
{
    public class EmailSender
    {
        
        private const String API_KEY = "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";

       
        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //string serverPath = Server.MapPath("~/Attachment.txt");
            //System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(Server.MapPath("~/Attachment.txt")); 
            var response = client.SendEmailAsync(msg);    
        }

    }
}