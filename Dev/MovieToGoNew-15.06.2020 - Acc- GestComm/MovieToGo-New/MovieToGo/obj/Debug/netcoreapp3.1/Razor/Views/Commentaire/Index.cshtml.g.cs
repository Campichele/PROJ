#pragma checksum "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94e02243f3f462a0b0526d524016e470a10f87f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Commentaire_Index), @"mvc.1.0.view", @"/Views/Commentaire/Index.cshtml")]
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
#line 1 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94e02243f3f462a0b0526d524016e470a10f87f3", @"/Views/Commentaire/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37937b1fdfdbd3d0138c66c0cd98884fc97b5693", @"/Views/_ViewImports.cshtml")]
    public class Views_Commentaire_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieToGo.Models.Commentaire>>
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
#line 3 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Commentaires</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94e02243f3f462a0b0526d524016e470a10f87f34037", async() => {
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
#line 17 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Commentaire1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Statut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdFilmNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdUserNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 32 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Commentaire1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Statut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdFilmNavigation.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdUserNavigation.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 47 "E:\SIG2\API-Proj\MovieToGoNew-11.06.2020 -mail\MovieToGo-New\MovieToGo\Views\Commentaire\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieToGo.Models.Commentaire>> Html { get; private set; }
    }
}
#pragma warning restore 1591
