using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms3
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ContactButton.Enabled = false;
                var body = "<p>Contact received from {0}</p><p>Message:</p><p>{1}</p>";
                var message = new MailMessage();
                //message.From = new MailAddress("ivanginovdev@gmail.com");
                message.To.Add(new MailAddress(EmailControl.Text));
                message.Subject = "Contact form";
                message.Body = string.Format(body, EmailControl.Text, MessageControl.Text);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    //var credentials = new NetworkCredential
                    //{
                    //    UserName = "ivanginovdev@gmail.com",
                    //    Password = "Raynor1!"
                    //};
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = credentials;
                    //smtp.Host = "smtp.gmail.com";
                    //smtp.Port = 587;
                    //smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(message);

                        EmailControl.Text = null;
                        MessageControl.Text = null;
                        SuccessMessage.Visible = true;
                        SucessText.Text = "Email successfully sent";
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage.Visible = true;
                        FailureText.Text = ex.Message;
                    }
                    finally
                    {
                        ContactButton.Enabled = true;
                    }
                }

            }
        }
    }
}