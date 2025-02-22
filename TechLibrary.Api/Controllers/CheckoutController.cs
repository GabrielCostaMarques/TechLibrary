using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UserCases.Checkouts;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutController : ControllerBase
    {
        [HttpPost]
        //fazer o ID fazer parte da rota
        [Route("{bookId}")]

        public IActionResult BookCheckout(Guid bookId)
        {
            var useCase = new RegisterBookCheckoutUseCase();

            useCase.Execute(bookId);

            return NoContent();
        }
    }
}
