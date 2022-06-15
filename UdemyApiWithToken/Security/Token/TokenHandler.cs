using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        TokenOptions _tokenOptions;
        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securitiyKey = SignHandler.GetSecurityKey(_tokenOptions.SecurityKey);
            
            SigningCredentials signingCredentials = 
                new SigningCredentials(securitiyKey,SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:_tokenOptions.Issuer,
                audience:_tokenOptions.Audience,
                expires:accessTokenExpiration,
                notBefore:DateTime.Now,//ilgili zamandan sonra kullanılmaya başlansın
                signingCredentials: signingCredentials,
                claims: GetClaims(user)
                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var accessToken = new AccessToken();

            
            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
        }

        private string CreateRefreshToken()
        {
            //return Guid.NewGuid().ToString(); //tahmin edilebiliyor...
            var numberByte = new Byte[64];

            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);

                return Convert.ToBase64String(numberByte);
            }
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {   // şekillerde claimler oluşturabiliriz
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Name",$"{user.Name} {user.SurName}"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        } 

        public void RevokeRefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
