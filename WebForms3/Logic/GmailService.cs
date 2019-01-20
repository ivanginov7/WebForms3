using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebForms3.Logic
{
    public class GmailService:SmtpClient
    {
        public GmailService() : base()
        {

        }
    }
}