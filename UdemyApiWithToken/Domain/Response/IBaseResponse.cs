namespace UdemyApiWithToken.Domain.Response
{
    public interface IBaseResponse<TEntity>where TEntity : class
    {
        bool Success { get; set; }
        string Message { get; set; }
        TEntity Entity { get; set; }
    }
}
