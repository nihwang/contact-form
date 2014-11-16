using System;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
 
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //Create the msg object to be sent
            MailMessage msg = new MailMessage();
            //Add your email address to the recipients
            msg.To.Add("nihwang12@gmail.com");
            //Configure the address we are sending the mail from
            MailAddress address = new MailAddress("nihwang12@gmail.com");
            msg.From = address;
            //Append their name in the beginning of the subject
            msg.Subject = txtName.Text + " :  " + ddlSubject.Text;
            msg.Body = txtMessage.Text;
 
            //Configure an SmtpClient to send the mail.
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = false; //only enable this if your provider requires it
            //Setup credentials to login to our sender email address ("UserName", "Password")
            NetworkCredential credentials = new NetworkCredential("nihwang12@gmail.com", "toma1286!");
            client.Credentials = credentials;
 
            //Send the msg
            client.Send(msg);
 
            //Display some feedback to the user to let them know it was sent
            lblResult.Text = "Your message was sent!";
 
            //Clear the form
            txtName.Text = "";
            txtMessage.Text = "";
        }
        catch
        {
            //If the message failed at some point, let the user know
            lblResult.Text = "Your message failed to send, please try again.";
        }
    }
}