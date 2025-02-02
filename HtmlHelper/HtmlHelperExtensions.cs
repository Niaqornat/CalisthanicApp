using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using System.Linq.Expressions;

public static class HtmlHelperExtensions
{
    public static IHtmlContent FormGroupFor<TModel, TProperty>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        string inputCssClass = "form-control",
        string labelCssClass = "control-label",
        string validationCssClass = "text-danger")
    {
        // Label
        var label = htmlHelper.LabelFor(expression, new { @class = labelCssClass }).GetString();
        // Input
        var input = htmlHelper.TextBoxFor(expression, new { @class = inputCssClass }).GetString();
        // Validation Message
       

        // Combine into a form group div
        var formGroupHtml = $@"
            <div class='form-group'>
                {label}
                {input}
                
            </div>";

        return new HtmlString(formGroupHtml);
    }

    // Extension method to render IHtmlContent as string
    private static string GetString(this IHtmlContent content)
    {
        using (var writer = new System.IO.StringWriter())
        {
            content.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
