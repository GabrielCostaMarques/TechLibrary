using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UserCases.Login;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
        public IActionResult DoLogin(RequestLoginJson request) 
        {
            var userCase = new DoLoginUseCase();

            var response = userCase.Execute(request);

            return Ok(response);    
        }
    }
}
