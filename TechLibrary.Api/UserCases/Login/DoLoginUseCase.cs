using TechLibrary.Api.Infrastructure.DataAccess;
using TechLibrary.Api.Infrastructure.Security;
using TechLibrary.Api.Infrastructure.Security.Tokens.Access;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UserCases.Login
{
    public class DoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new TechLibraryDbContext();
            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email));

            if (user is null)
            {
                throw new InvalidLoginException();
            }


            var cryptograph = new BCryptAlgorithme();
            var passwordIsValid = cryptograph.Verify(request.Password, user);

            if (passwordIsValid == false)
            {
                throw new InvalidLoginException();
            }

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = tokenGenerator.Generate(user)
            };
        }
    }
}
