#pragma checksum "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd2f9d9df57b4c424f0e50752d35fba927505081"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Film_Acheter), @"mvc.1.0.view", @"/Views/Film/Acheter.cshtml")]
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
#line 1 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd2f9d9df57b4c424f0e50752d35fba927505081", @"/Views/Film/Acheter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37937b1fdfdbd3d0138c66c0cd98884fc97b5693", @"/Views/_ViewImports.cshtml")]
    public class Views_Film_Acheter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieToGo.Models.Acheter>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
  
    ViewData["Title"] = "Acheter";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!-- inject IOptions<StripeMovieToGo.Data.StripeSittings> Stripe est utilisé pour ne pas devoir rajouter les clef Stripe ici-->\r\n<div class=\"text-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd2f9d9df57b4c424f0e50752d35fba9275050814415", async() => {
                WriteLiteral("\r\n        <article>\r\n            <label>Amount: ");
#nullable restore
#line 14 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
                      Write(ViewBag.Displayprice);

#line default
#line hidden
#nullable disable
                WriteLiteral(".-</label>\r\n        </article>\r\n        <script src=\"//checkout.stripe.com/v2/checkout.js\"\r\n                class=\"stripe-button\"\r\n                data-key=\"");
#nullable restore
#line 18 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
                     Write(Stripe.Value.PublishableKey);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"\r\n                data-locale=\"auto\"\r\n                data-description=\"");
#nullable restore
#line 20 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
                             Write(ViewBag.name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"\r\n                data-amount=\"");
#nullable restore
#line 21 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
                        Write(ViewBag.price);

#line default
#line hidden
#nullable disable
                WriteLiteral(".-\">\r\n        </script>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 389, "/Acheter/Charge/?searchID=", 389, 26, true);
#nullable restore
#line 12 "C:\Users\emix\Desktop\MovieToGoNew-6.6.20\MovieToGo-New\MovieToGo\Views\Film\Acheter.cshtml"
AddHtmlAttributeValue("", 415, ViewBag.id, 415, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<MovieToGo.Models.Acheter> Stripe { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieToGo.Models.Acheter> Html { get; private set; }
    }
}
#pragma warning restore 1591