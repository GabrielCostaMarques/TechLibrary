namespace TechLibrary.Api.Domain.Entities
{
    public class User
    {
        //assim, que criar um user ele ja cria um ID
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty; //operação para a string ser vazia e nao nula
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
