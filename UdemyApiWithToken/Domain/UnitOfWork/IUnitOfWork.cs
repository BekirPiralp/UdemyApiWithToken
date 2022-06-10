namespace UdemyApiWithToken.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task ComplateAsync();
    }
}
