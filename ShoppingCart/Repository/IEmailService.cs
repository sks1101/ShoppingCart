using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IEmailService
    {
        public Task SendEmailAsync(MailRequest mailrequest);
    }
}
