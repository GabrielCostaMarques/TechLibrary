using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infrastructure.Security.Tokens.Access;

public class JwtTokenGenerator
{
    public string Generate(User user)
    {

        var claims = new List<Claim>()
        {
            //definindo o valor como o ID, ele precisa de uma chave - valor
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //definir a expiração do token
            Expires = DateTime.UtcNow.AddMinutes(60),

            // aqui sera quem o token precisa identificar pra atribuir o token, porém ele só recebe lista, entao criamos a lista em cima mesmo que seja apenas de 1 valor
            Subject = new ClaimsIdentity(claims),
            //para criptografar o token
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler=new JwtSecurityTokenHandler();


        //criando o token com a descrição
       var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        //chamando a função para escrever o token
        return tokenHandler.WriteToken(securityToken);
    }

    private static SymmetricSecurityKey SecurityKey()
    {
        //colocando na key apenas para representação, porém precisa estar em um ambiente seguro
        var signKey = "0r7o6TWFh4Y8Ruy6sVObEOwooqJezUlJ";

        //transformando o texto em dado
        var symmetricKey=Encoding.UTF8.GetBytes(signKey);

        return new SymmetricSecurityKey(symmetricKey);
    }
}

