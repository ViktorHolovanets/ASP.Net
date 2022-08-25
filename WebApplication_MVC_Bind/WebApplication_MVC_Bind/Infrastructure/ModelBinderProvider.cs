using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication_MVC_Bind.Models;

namespace WebApplication_MVC_Bind.Infrastructure
{
    public class ModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder = new ModelBinderAccount();
        private readonly IModelBinder binderUser = new ModelBinderUser();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {

            return context.Metadata.ModelType.Name switch
            {
                "Account" => binder,
                "User" => binderUser,
                _ => null
            };

        }
    }
}
