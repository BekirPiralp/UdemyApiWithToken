namespace UdemyApiWithToken.Domain.Response
{
    public interface IBaseResponse<TEntity>where TEntity : class
    {
        //private IBaseResponse(bool success, string message, TEntity entity)
        //{
        //    Success = success;
        //    Message = message;
        //    Entity = entity;
        //}
        bool  Success { get; set; }
        string Message { get; set; }
        TEntity Entity { get; set; }
        //public IBaseResponse(TEntity entity) : this(true, String.Empty, entity) { }
        //public IBaseResponse(String message) : this(false, message, null) { }
    }
}
