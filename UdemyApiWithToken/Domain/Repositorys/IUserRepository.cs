using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public interface IUserRepository
    {
        Task AddUSer(User user);

        User FindById(int id);

        User FindByEmailAndPassword(string email, string password);

        void SaveRefreshToken(int userId, string refreshToken);

        User GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}
