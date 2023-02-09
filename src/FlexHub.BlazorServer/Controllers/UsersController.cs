using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlexHub.BlazorServer.Controllers;
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "ClientCertificate")]
[ApiController]
public class UsersController : ControllerBase
{
    // GET: api/<UsersController>
    [HttpGet]
    public async Task<IEnumerable<string>> Get()
    {
        var clientCertificate = await HttpContext.Connection.GetClientCertificateAsync();
        
        return new string[] { "value1", "value2" };
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
