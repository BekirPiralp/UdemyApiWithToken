using UdemyApiWithToken.Domain.Repositorys;
using UdemyApiWithToken.Domain.Response;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class BaseService<TEntity, Response, ListResponse,IRepository>:IBaseService<TEntity,Response, ListResponse>
        where TEntity : class
        where Response : BaseResponse<TEntity>
        where ListResponse : BaseResponse<IEnumerable<TEntity>>
        where IRepository : IBaseRepository<TEntity>
    {
        IUnitOfWork _unitOfWork;
        IRepository _repository;
        public BaseService(IRepository repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> AddAsync(TEntity entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.ComplateAsync();
                return (Response)BaseResponse<TEntity>.Response(entity);
            }
            catch (Exception ex)
            {
                return (Response)BaseResponse<TEntity>.Response($"{nameof(TEntity)} nesnesi eklenirken hata oluştu::" +
                    $"{ex.Message}");
            }
        }

        public async Task<Response> FindByIdAsync(int entityId)
        {
            Response response;
            try
            {
                var val = await _repository.GetByIdAsync(entityId);
                if (val == null)
                    response = (Response)BaseResponse<TEntity>.Response($"{nameof(TEntity)} nesnesi bulunamadı.");
                else
                response = (Response)BaseResponse<TEntity>.Response(val);
            }
            catch (Exception ex)
            {
                response = (Response)BaseResponse<TEntity>.Response($"{nameof(TEntity)} nesnesi getirilirken hata oluştu::{ex.Message}");
            }
            return response;
        }

        public async Task<ListResponse> ListAsync()
        {
            ListResponse response;
            try
            {
                var val = await _repository.ListAsync();
                if(val == null || val.Count() < 1)
                    response = (ListResponse)BaseResponse<IEnumerable<TEntity>>.Response($"{nameof(TEntity)} nesnesi bulunamadı.");
                else
                response = (ListResponse)BaseResponse<IEnumerable<TEntity>>.Response(val);
            }
            catch (Exception ex)
            {
                response = (ListResponse)BaseResponse<IEnumerable<TEntity>>.Response($"{nameof(TEntity)} nesneleri" +
                    $" getirilirken hata oluştu::{ex.Message}");
            }
            return response;
        }

        public async Task<Response> RemoveAsync(int entityId)
        {
            Response response;
            try
            {
                var val = await _repository.GetByIdAsync(entityId);
                if (val != null)
                {
                    await _repository.RemoveAsync(entityId);
                    await _unitOfWork.ComplateAsync();
                    response = (Response)BaseResponse<TEntity>.Response(val);
                }
                else
                    response = (Response)BaseResponse<TEntity>.Response($"{nameof(TEntity)} nesnesi bulunamadı.");
                  
                

            }
            catch (Exception ex)
            {
                response = (Response)BaseResponse<IEnumerable<TEntity>>.Response($"{nameof(TEntity)} nesnesi" +
                    $" silinirken hata oluştu::{ex.Message}");
            }
            return response;
        }

        public async Task<Response> UpdateAsync(TEntity entity, int entityId)
        {
            Response response;
            try
            {
                var val = await _repository.GetByIdAsync(entityId);
                if (val != null)
                {
                    _repository.Update(entity);
                    await _unitOfWork.ComplateAsync();
                    var guncel = await _repository.GetByIdAsync(entityId);
                    response = (Response)BaseResponse<TEntity>.Response(guncel);
                }
                else
                    response = (Response)BaseResponse<TEntity>.Response($"{nameof(TEntity)} nesnesi bulunamadı.");

            }
            catch (Exception ex)
            {
                response = (Response)BaseResponse<IEnumerable<TEntity>>.Response($"{nameof(TEntity)} nesnesi" +
                    $" güncellenirken hata oluştu::{ex.Message}");
            }
            return response;
        }
    }
}
