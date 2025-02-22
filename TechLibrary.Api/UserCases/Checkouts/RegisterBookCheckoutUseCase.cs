using Microsoft.IdentityModel.Tokens;
using TechLibrary.Api.Infrastructure.DataAccess;
using TechLibrary.Exception;

namespace TechLibrary.Api.UserCases.Checkouts
{
    public class RegisterBookCheckoutUseCase
    {
        private const int MAX_LOAN_DAYS = 7;
        public void Execute(Guid bookId)
        {

            var dbContext = new TechLibraryDbContext();

            Validate(dbContext, bookId);

            var entity = new Domain.Entities.Checkout
            {

                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_LOAN_DAYS),
            };

           
        }

        private void Validate(TechLibraryDbContext dbContext, Guid bookId)
        {
            var book = dbContext.Books.FirstOrDefault(book => book.Id == bookId);
            if (book is null)
            {
                throw new NotFoundException("Livro Não encontrado");
            }

            var amountBooksNotReturned = dbContext
                .Checkouts
                .Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            if (amountBooksNotReturned == book.Amount)
            {
                throw new ConflictException("Livro Não está disponível para empréstimo");

            }
        }
    }




}
