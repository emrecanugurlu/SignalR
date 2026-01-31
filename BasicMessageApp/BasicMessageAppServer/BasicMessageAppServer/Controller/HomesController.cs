using BasicMessageAppServer.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicMessageAppServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {

        readonly MyBusiness _myBusiness;

        public HomesController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> SendMessage(string message)
        {
            await _myBusiness.SendMessageAsync("User", message);
            return Ok("Bağlantı başarılı");
        }
    }
}
