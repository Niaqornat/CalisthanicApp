using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CalisthenicsApp.TagHelpers
{
    [HtmlTargetElement("form-input", Attributes = "asp-for")]
    public class FormInputTagHelper : TagHelper
    {
        public ModelExpression AspFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Set the wrapper div
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "form-group");

            // Generate the label
            var label = $"<label for='{AspFor.Name}' class='control-label'>{AspFor.Metadata.DisplayName ?? AspFor.Name}</label>";

            // Generate the input
            var input = $"<input id='{AspFor.Name}' name='{AspFor.Name}' type='password' class='form-control' />";

            // Generate the validation message
            var validationMessage = $"<span class='text-danger' asp-validation-for='{AspFor.Name}'></span>";

            // Combine all into the output
            output.Content.SetHtmlContent(label + input + validationMessage);
        }
    }
}
