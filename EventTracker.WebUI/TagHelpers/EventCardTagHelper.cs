using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
public class EventCardTagHelper : TagHelper
{
    [HtmlAttributeName("name")]
    public string Name { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "card shadow-sm mb-4");

        output.Content.SetHtmlContent($@"
               <div class='card-body'>
                   <h5 class='card-title text-primary'>{Name}</h5>
               </div>
           ");
    }
}