using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;

namespace Airways.Application.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateToken(ApplicationUser user, IConfiguration configuration)
        {
            ////var secretKey = configuration.GetValue<string>("JwtConfiguration:SecretKey");

            ////var key = Encoding.ASCII.GetBytes(secretKey);

            ////var tokenHandler = new JwtSecurityTokenHandler();

            ////var tokenDescriptor = new SecurityTokenDescriptor
            ////{
            ////    Subject = new ClaimsIdentity(new[]
            ////    {
            ////        new Claim(ClaimTypes.NameIdentifier, user.Id),
            ////        new Claim(ClaimTypes.Name, user.UserName),
            ////        new Claim(ClaimTypes.Email, user.Email)
            ////    }),
            ////    Expires = DateTime.UtcNow.AddDays(7),
            ////    SigningCredentials =
            ////        new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            ////};

            ////var token = tokenHandler.CreateToken(tokenDescriptor);

            ////return tokenHandler.WriteToken(token);

            return "";
        }
    }

}
