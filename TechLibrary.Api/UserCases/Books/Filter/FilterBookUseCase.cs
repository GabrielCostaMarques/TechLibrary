using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infrastructure.DataAccess;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;

namespace TechLibrary.Api.UserCases.Books.Filter
{
    public class FilterBookUseCase
    {
        private const int PAGE_SIZE = 10;
        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new TechLibraryDbContext();

            //declarando query como IQueryable porque o "Where" retorna um IQueryable entao fazemos essa manobra dizendo que o Books é Queryable
            var query = dbContext.Books.AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Title) == false)
            {
                query = query.Where(book => book.Title.Contains(request.Title));
            }

            var books = query
                //Ordenação por titulo e por autor
                .OrderBy(books => books.Title).ThenBy(books => books.Author)
                //numero da página - 1 (1-1 =0*PAGE_SIZE = 0) Não pula elementos, e assim por diante
                .Skip((request.PageNumber - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();


            var totalCount = 0;
            if (string.IsNullOrWhiteSpace(request.Title))
            {

                totalCount = dbContext.Books.Count();
            }
            else
            {
                totalCount = dbContext.Books.Count(book => book.Title.Contains(request.Title));
            }


            return new ResponseBooksJson
            {
                Pagination = new ResponsePaginationJson
                {
                    PageNumber = request.PageNumber,
                    TotalCount = totalCount,
                },
                Books = books.Select(book => new ResponseBookJson
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                }).ToList()
            };
        }
    }
}
