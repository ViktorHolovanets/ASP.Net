using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tag_Helper.TagHelpers
{
    public class ModalWindowTagHelper:TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "modal-window");
            var target = await output.GetChildContentAsync();
            output.Content.SetHtmlContent($"<div id='details'>{target.GetContent()}</div>");
        }
    }
}
