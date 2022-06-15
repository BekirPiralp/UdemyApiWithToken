using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class UserRepository :BaseRepository<UdemyApiWithTokenContext,User>, IUserRepository
    {
        public UserRepository(UdemyApiWithTokenContext context) : base(context)
        {
        }

        public void AddUSer(User user)
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
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User user = context.Users.FirstOrDefault(
                u => u.Id == userId);
            user.RefreshToken = refreshToken;
        }
    }
}
