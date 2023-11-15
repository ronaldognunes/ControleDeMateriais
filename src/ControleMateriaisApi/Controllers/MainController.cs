using ControleMateriaisApi.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{

    [ApiController]
    [Authorize]
    [Produces("application/json")]
    [Consumes("application/json")]
    public abstract class MainController : ControllerBase
    {
        protected BadRequestObjectResult ErroDesconhecido()
        {
            var response = new ResponseDto<string>();
            response.Sucesso = false;
            response.MensagensDeErros.Add("Erro no Desconhecido");
            return BadRequest(response);
        }
    }
}
