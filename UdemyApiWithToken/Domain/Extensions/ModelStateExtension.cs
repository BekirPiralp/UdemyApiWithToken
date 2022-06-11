using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UdemyApiWithToken.Domain.Extensions
{
    public static class ModelStateExtension
    {
        // hata mesajlarını getittiriyoruz
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m=>m.Value.Errors).Select(x=>x.ErrorMessage).ToList();
        }
    }
}
