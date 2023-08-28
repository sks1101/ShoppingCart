using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using System.Security.Cryptography;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountRepository accountRepository, IEmailService emailService, ILogger<AccountController> logger)
        {
            _accountRepository = accountRepository;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);
            MailRequest mailrequest = new MailRequest();
            mailrequest.ToEmail = "Sameerksahu1120@gmail.com";
            mailrequest.Subject = "Welcome To ShopKart";
            mailrequest.Body = "Hello, " + signUpModel.Name+ "- Thank you for being a member of the ShopKart community.";
            if (result.Succeeded)
            {
                await _emailService.SendEmailAsync(mailrequest);
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignIn signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
        //[HttpPost("SendMail")]
        //public async Task<IActionResult> SendMail()
        //{
        //    try
        //    {
        //        //_logger.LogInformation("start email sending");
        //        MailRequest mailrequest = new MailRequest();
        //        mailrequest.ToEmail = "sameerksahu1120@gmail.com";
        //        mailrequest.Subject = "Welcome Techiees";
        //        mailrequest.Body = "Thanks For Using";
        //        await _emailService.SendEmailAsync(mailrequest);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // _logger.LogError("not send email");
        //        throw;
        //    }
        //}
    }
}
