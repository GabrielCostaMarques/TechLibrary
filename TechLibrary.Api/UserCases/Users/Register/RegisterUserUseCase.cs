using FluentValidation.Results;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infrastructure.DataAccess;
using TechLibrary.Api.Infrastructure.Security;
using TechLibrary.Api.Infrastructure.Security.Tokens.Access;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UserCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {

            var dbContext = new TechLibraryDbContext();
            Validate(request, dbContext);


            var cryptograph = new BCryptAlgorithme();
            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = cryptograph.HashPassword(request.Password),
            };

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AccessToken = tokenGenerator.Generate(entity)
            };
        }


        private void Validate(RequestUserJson request,TechLibraryDbContext dbContext)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

           var existUserWithEmail= dbContext.Users.Any(user =>user.Email.Equals(request.Email));


            if (existUserWithEmail)
            {
                result.Errors.Add(new ValidationFailure("Email", "E-mail já registrado!"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }



}
