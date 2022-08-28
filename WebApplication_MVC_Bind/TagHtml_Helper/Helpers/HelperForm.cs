using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TagHtml_Helper.Helpers
{
    public static class HelperForm
    {
        public static HtmlString HelperFormUser(this IHtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.Attributes.Add("method", "post");

            TagBuilder labelName = new TagBuilder("label");
            labelName.Attributes.Add("for", "name");
            labelName.InnerHtml.Append("Name: ");
            form.InnerHtml.AppendHtml(labelName);

            TagBuilder inputName = new TagBuilder("input");
            inputName.Attributes.Add("type", "text");
            inputName.Attributes.Add("name", "name"); 
            inputName.Attributes.Add("placeholder", "Enter name");
            form.InnerHtml.AppendHtml(inputName);

            TagBuilder labelSurname = new TagBuilder("label");
            labelSurname.Attributes.Add("for", "surname");
            labelSurname.InnerHtml.Append("Surname: ");
            form.InnerHtml.AppendHtml(labelSurname);

            TagBuilder inputSurname = new TagBuilder("input");
            inputSurname.Attributes.Add("type", "text");
            inputSurname.Attributes.Add("name", "surname");
            inputSurname.Attributes.Add("placeholder", "Enter Surname");
            form.InnerHtml.AppendHtml(inputSurname);

            TagBuilder labelAge = new TagBuilder("label");
            labelAge.Attributes.Add("for", "age");
            labelAge.InnerHtml.Append("Age: ");
            form.InnerHtml.AppendHtml(labelAge);

            TagBuilder inputAge = new TagBuilder("input");
            inputAge.Attributes.Add("type", "number");
            inputAge.Attributes.Add("name", "age");
            inputAge.Attributes.Add("placeholder", "Enter age");
            form.InnerHtml.AppendHtml(inputAge);

            using var writer = new StringWriter();
            form.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
        public static HtmlString HelperViewUser(this IHtmlHelper html)
        {
            TagBuilder div = new TagBuilder("div");
            
            TagBuilder lName = new TagBuilder("p");
            lName.InnerHtml.Append("Name: User");
            div.InnerHtml.AppendHtml(lName);

            TagBuilder lSurname = new TagBuilder("p");
            lSurname.InnerHtml.Append("Surname: Surname User");
            div.InnerHtml.AppendHtml(lSurname);

            TagBuilder lAge = new TagBuilder("p");
            lAge.InnerHtml.Append("Age: 18");
            div.InnerHtml.AppendHtml(lAge);

            using var writer = new StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
    
}
