namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IEmailService
	{
		void SendEmail(string toUser);
		void SendEmailConfirm(string toUser, string confirmUrl);
	}
}
