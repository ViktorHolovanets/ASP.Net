using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using WebApplication_MVC_Bind.Models;

namespace WebApplication_MVC_Bind.Infrastructure
{
    public class ModelBinderAccount : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            var datePartValues = bindingContext.ValueProvider.GetValue("Birthdate");
            var loginPartValues = bindingContext.ValueProvider.GetValue("login");
            var passwordPartValues = bindingContext.ValueProvider.GetValue("password");
            var namePartValues = bindingContext.ValueProvider.GetValue("Name");
            var surnamePartValues = bindingContext.ValueProvider.GetValue("Surname");

            var date = datePartValues.FirstValue;
            var login = loginPartValues.FirstValue;
            var password = passwordPartValues.FirstValue;
            var name = namePartValues.FirstValue;
            var surname = surnamePartValues.FirstValue;

            DateTime.TryParse(date, out var parsedDateValue);

            DateTime fullDateTime = new DateTime(parsedDateValue.Year,
                parsedDateValue.Month,
                parsedDateValue.Day);

            bindingContext.Result = ModelBindingResult.Success(new Account
            {
                Id = Guid.NewGuid().ToString(),
                Login = string.IsNullOrEmpty(login) ? "login" : login,
                Password = string.IsNullOrEmpty(password) ? "password" : password,
                CreateAcountDate = DateAndTime.Now,
                Client = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = string.IsNullOrEmpty(name) ? "User" : name,
                    Surname = string.IsNullOrEmpty(surname) ? "" : surname,
                    Birthdate = fullDateTime
                }
            });
            return Task.CompletedTask;
        }
    }
}
