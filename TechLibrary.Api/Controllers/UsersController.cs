using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UserCases.Users.Register;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //método da função
        [HttpPost]
        //código da resposta, isso para melhorar a documentação
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        //Retornar o resultado da chamada (200,400, 404)
        public IActionResult Register(RequestUserJson request)

        {
            var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
