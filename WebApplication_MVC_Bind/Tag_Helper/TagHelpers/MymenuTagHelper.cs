using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tag_Helper.TagHelpers
{
    public class MymenuTagHelper : TagHelper
    {
        public string? PageLink { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", PageLink);
            output.Attributes.SetAttribute("class", "menu");
        }
    }
}
