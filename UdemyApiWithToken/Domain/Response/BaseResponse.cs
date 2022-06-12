namespace UdemyApiWithToken.Domain.Response
{
    public class BaseResponse<TEntity> : IBaseResponse<TEntity>
        where TEntity : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TEntity Entity { get; set; }

        private BaseResponse(bool success, string message, TEntity entity)
        {
            Success = success;
            Message = message;
            Entity = entity;
        }
        //public BaseResponse(TEntity entity)
        public BaseResponse(TEntity entity) : this(true, String.Empty, entity) { }
        public BaseResponse(String message) : this(false, message, null) { }
    }
}
