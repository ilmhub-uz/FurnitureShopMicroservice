using Contract.Api.Entities;
using Contract.Api.Exceptions;
using Contract.Api.Services.Interface;
using JFA.DependencyInjection;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;

namespace Contract.Api.Services;

[Scoped]
public class EmailService : IEmailService
{
    private readonly EmailConfiguration emailConfig;
    private readonly EmailBody emailBody;

    public EmailService(IOptions<EmailConfiguration> emailConfig, IOptions<EmailBody> emailBody)
    {
        this.emailConfig = emailConfig.Value;
        this.emailBody = emailBody.Value;
    }

    public void SendEmail(string[] receiverEmail)
    {
        var email = CreateEmailMessage(receiverEmail);
        SendEmailMessage(email);
    }

    private MimeMessage CreateEmailMessage(string[]? receiverEmail)
    {
        var mimeMassage = new MimeMessage();

        mimeMassage.To.AddRange(receiverEmail.Select(e => new MailboxAddress("", e)));
        mimeMassage.From.Add(new MailboxAddress("email", emailConfig.From));
        mimeMassage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = emailBody.Content };
        mimeMassage.Subject = emailBody.Subject;

        return mimeMassage;
    }

    private void SendEmailMessage(MimeMessage mimeMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                var credentials = new NetworkCredential(emailConfig.UserName, emailConfig.Password);
                client.Connect(emailConfig.SmtpServer, emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(credentials);
                var response = client.Send(mimeMessage);
            }
            catch
            {
                throw new NotFoundException("Email related problem");
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}