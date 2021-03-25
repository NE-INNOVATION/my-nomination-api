
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using my_nomination_api.models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PingController : Controller
{

    private IMyNominationDatabaseSettings _settings = null;
    public PingController(IMyNominationDatabaseSettings settings)
    {
        _settings = settings;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("ConnectionString") ?? _settings.ConnectionString);
            var database = client.GetDatabase(System.Environment.GetEnvironmentVariable("DatabaseName") ?? _settings.DatabaseName);

            if (database != null)
            {
                return Ok();
            }

            var apiKey = "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";
            var client1 = new SendGridClient(apiKey);
            var from = new EmailAddress("g.ravindra.bhogle@accenture.com");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("ganesh.bhogle88@gmail.com");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "and easy to do anywhere, even with C#";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client1.SendEmailAsync(msg);

            return BadRequest();

        }
        catch (System.Exception)
        {
            return BadRequest();           
        }
      
    }
}
