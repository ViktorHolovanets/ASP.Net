using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using WebApplication_MVC_Bind.Models;

namespace WebApplication_MVC_Bind.Infrastructure
{
    public class ModelBinderUser : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            var datePartValues = bindingContext.ValueProvider.GetValue("Birthdate");
            var namePartValues = bindingContext.ValueProvider.GetValue("Name");
            var surnamePartValues = bindingContext.ValueProvider.GetValue("Surname");

            var date = datePartValues.FirstValue;
            var name = namePartValues.FirstValue;
            var surname = surnamePartValues.FirstValue;
            DateTime fullDateTime;
            if (string.IsNullOrEmpty(date))
            {
                fullDateTime = DateAndTime.Now;
            }
            else
            {
                DateTime.TryParse(date, out var parsedDateValue);
                fullDateTime = new DateTime(parsedDateValue.Year,
                    parsedDateValue.Month,
                    parsedDateValue.Day);
            }
            bindingContext.Result = ModelBindingResult.Success(new User {
                Id = Guid.NewGuid().ToString(),
                Name = string.IsNullOrEmpty(name) ? "NameUser" : name,
                Surname = string.IsNullOrEmpty(surname) ? "SurnameUser" : surname,
                Birthdate = fullDateTime
            });
            return Task.CompletedTask;
        }
    }

}
