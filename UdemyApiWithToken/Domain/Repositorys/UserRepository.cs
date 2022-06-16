using Microsoft.Extensions.Options;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class UserRepository :BaseRepository<UdemyApiWithTokenContext,User>, IUserRepository
    {
        // bu token options bizim yadığımız token options dır
        private readonly TokenOptions tokenOptions;
        public UserRepository(IOptions<TokenOptions> options,UdemyApiWithTokenContext context) : base(context)
        {
           tokenOptions = options.Value;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            return context.Users.Where
                (u => u.Email == email && u.Password == password)
                .FirstOrDefault();
        }

        public User FindById(int id)
        {
            //return context.Users.Find(id);
            return context.Users.Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return context.Users.FirstOrDefault
                (U => U.RefreshToken == refreshToken);

        }

        public void RemoveRefreshToken(User user)
        {
            User newUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
            newUser.RefreshToken = null;
            newUser.RefreshTokenEndDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User user = context.Users.FirstOrDefault(
                u => u.Id == userId);
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate =
                DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
        }
    }
}
