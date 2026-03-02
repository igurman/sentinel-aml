using Microsoft.AspNetCore.Mvc;

namespace SentinelAML.Web.Controllers;

[ApiController]
[Route("api")]
public class CrudController : ControllerBase {

    [HttpGet]
    public string Get() {
        return "Hello World!";
    }
    
}