namespace Contract.Api.Services.Interface;

public interface IEmailService
{
    void SendEmail(string[] receiverEmail);
}