#pragma checksum "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "518c395675806065179d6095ab527c39f2ff4955"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FaitParties_Index), @"mvc.1.0.view", @"/Views/FaitParties/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"518c395675806065179d6095ab527c39f2ff4955", @"/Views/FaitParties/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37937b1fdfdbd3d0138c66c0cd98884fc97b5693", @"/Views/_ViewImports.cshtml")]
    public class Views_FaitParties_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieToGo.Models.FaitPartie>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "518c395675806065179d6095ab527c39f2ff49554097", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdFilmNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdGenreNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdFilmNavigation.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdGenreNavigation.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 35 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 36 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 39 "C:\Users\Marco\OneDrive\Documents\GERBER\MovieToGoNew-8.6.20 - Maxime\MovieToGo-New\MovieToGo\Views\FaitParties\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieToGo.Models.FaitPartie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
