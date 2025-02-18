namespace TechLibrary.Comunication.Requests
{
    public class RequestUserJson
    {
        public string Name { get; set; } = string.Empty; //operação para a string ser vazia e nao nula
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;



    }
}
