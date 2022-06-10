namespace UdemyApiWithToken.Domain.Response
{
    public class BaseResponse<TEntity> : IBaseResponse<TEntity>
        where TEntity : class
    {
        public virtual bool Success { get; set; }
        public virtual string Message { get; set; }
        public virtual TEntity Entity { get; set; }

        private BaseResponse(bool success, string message, TEntity entity)
        {
            Success = success;
            Message = message;
            Entity = entity;
        }

        //başarılı olursa
        public BaseResponse(TEntity entity) : this(true, String.Empty, entity) { }

        //başarısız olursa
        public BaseResponse(String message) : this(false, message, null) { }
    }
}
