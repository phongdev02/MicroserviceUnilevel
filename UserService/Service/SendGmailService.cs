using Microsoft.Extensions.Options;
using MimeKit;
using UserService.Models;
using UserService.Models.Dto;

namespace UserService.Service
{
    public class SendGmailService
    {
        private MailSettings _mailsetting;

        public SendGmailService(IOptions<MailSettings> mailSettings) {
            _mailsetting = mailSettings.Value;
        }
        public async Task<string> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();

            email.Sender = new MailboxAddress(_mailsetting.DisplayName, _mailsetting.SenderEmail);
            email.From.Add(new MailboxAddress(_mailsetting.DisplayName, _mailsetting.SenderEmail));
            email.To.Add(new MailboxAddress(mailContent.to, mailContent.to));

            email.Subject = mailContent.subject;

            //thiết lập kiểu nội dung gửi đi
            var builder = new BodyBuilder();

            builder.HtmlBody = mailContent.body;

            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                await smtp.ConnectAsync(_mailsetting.Host, _mailsetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailsetting.SenderEmail, _mailsetting.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                return ("Error: " + ex.Message);
            }

            await smtp.DisconnectAsync(true);
            return "send succes";
        }
    }
}
