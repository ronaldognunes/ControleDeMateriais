using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class MainController : ControllerBase
    {
    }
}
