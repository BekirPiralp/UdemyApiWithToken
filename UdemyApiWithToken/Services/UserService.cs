using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Repositorys;
using UdemyApiWithToken.Domain.Response;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository repository,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public UserResponse AddUser(User user)
        {
            UserResponse response;
            try
            {
                User userr = repository.FindByEmailAndPassword(user.Email, user.Password);
                if(userr == null)
                {
                    repository.AddUser(user);
                    unitOfWork.Complate();
                    response = new UserResponse(user);
                }
                else
                {
                    response = new UserResponse($"Bu kullanıcı daha önce eklenmiş");
                }
                
            }
            catch (Exception ex)
            {
                response = new UserResponse($"Kullanıcı eklenirken hata oluştu:{ex.Message}");
            }
            return response;
        }

        public UserResponse FindByEmailAndPassword(string email, string password)
        {
            UserResponse response;
            try
            {
                User user = repository.FindByEmailAndPassword(email, password);
                if(user == null)
                {
                    response=new UserResponse("Kullanıcı bulunamadı.");
                }else
                    response=new UserResponse(user);

            }
            catch (Exception ex)
            {
                response = new UserResponse($"Kullanıcı getirilirken hata oluştu : {ex.Message}");
            }
            return response;
        }

        public UserResponse FindById(int userId)
        {
            UserResponse response;
            try
            {
                User user = repository.FindById(userId);
                if (user == null)
                {
                    response = new UserResponse("Kullanıcı bulunamadı.");
                }
                else
                    response = new UserResponse(user);

            }
            catch (Exception ex)
            {
                response = new UserResponse($"Kullanıcı getirilirken hata oluştu : {ex.Message}");
            }
            return response;
        }

        public UserResponse GetUserWithRefreshToken(string refreshToken)
        {
            UserResponse response;
            try
            {
                User user = repository.GetUserWithRefreshToken(refreshToken);
                if (user == null)
                {
                    response = new UserResponse("Kullanıcı bulunamadı.");
                }
                else
                    response = new UserResponse(user);

            }
            catch (Exception ex)
            {
                response = new UserResponse($"Kullanıcı getirilirken hata oluştu : {ex.Message}");
            }
            return response;
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                repository.RemoveRefreshToken(user);
                unitOfWork.Complate();
            }
            catch (Exception)
            {
                //loglama yapılabilir.
                //throw;
            }
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                repository.SaveRefreshToken(userId, refreshToken);
                unitOfWork.Complate();
            }
            catch (Exception)
            {
                //loglama yapılabilir.
                //throw;
            }
        }
    }
}
