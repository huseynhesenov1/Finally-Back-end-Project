using LineConstruction.BLa.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace LineConstruction.BLa.Services.Implementations
{
	public class EmailService : IEmailService
	{
		private readonly IConfiguration _configration;
		public EmailService(IConfiguration configration)
		{
			_configration = configration;
		}



		public void SendEmail(string toUser)
		{
			SmtpClient smtp = new SmtpClient(_configration["Email:Host"], Convert.ToInt32(_configration["Email:Port"]));
			smtp.EnableSsl = true;
			smtp.Credentials = new NetworkCredential(_configration["Email:Login"], _configration["Email:Passcode"]);
			MailAddress from = new MailAddress("huseynzh-ab205@code.edu.az");
			MailAddress to = new MailAddress(toUser);
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Hello from Line Construction WebSite";
			message.IsBodyHtml = false;
			message.Body = "Welcome to Our Page";
			smtp.Send(message);
		}

		public void SendEmailConfirm(string toUser, string confirmUrl)
		{
			SmtpClient smtp = new SmtpClient(_configration["Email:Host"], Convert.ToInt32(_configration["Email:Port"]));
			smtp.EnableSsl = true;
			smtp.Credentials = new NetworkCredential(_configration["Email:Login"], _configration["Email:Passcode"]);
			MailAddress from = new MailAddress("huseynzh-ab205@code.edu.az");
			MailAddress to = new MailAddress(toUser);
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Confirm Email";
			message.IsBodyHtml = true;
			message.Body = $"<a href={confirmUrl}> Click here </a>";
			//message.Body = "Welcome to Our Page";

			smtp.Send(message);
		}
	}
}
