#pragma checksum "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\Acheter\Charge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69a016dab68b4aa18b25613e4c57ee09d927c35c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Acheter_Charge), @"mvc.1.0.view", @"/Views/Acheter/Charge.cshtml")]
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
#line 1 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\Acheter\Charge.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69a016dab68b4aa18b25613e4c57ee09d927c35c", @"/Views/Acheter/Charge.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37937b1fdfdbd3d0138c66c0cd98884fc97b5693", @"/Views/_ViewImports.cshtml")]
    public class Views_Acheter_Charge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieToGo.Models.Acheter>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\Acheter\Charge.cshtml"
  
    ViewData["Title"] = "Acheter";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Merci de votre achat du film : ");
#nullable restore
#line 8 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\Acheter\Charge.cshtml"
                              Write(ViewBag.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral(" prix :  <strong>");
#nullable restore
#line 8 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\Acheter\Charge.cshtml"
                                                           Write(ViewBag.Prix);

#line default
#line hidden
#nullable disable
            WriteLiteral(" CHF</strong> </h2>\r\n\r\n<button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 293, "\"", 340, 3);
            WriteAttributeValue("", 303, "window.location.href=\'", 303, 22, true);
#nullable restore
#line 10 "C:\Users\maxpichonnat\Desktop\MovieToGoNew-9.6.20 - lclc\MovieToGo-New\MovieToGo\Views\Acheter\Charge.cshtml"
WriteAttributeValue("", 325, ViewBag.link, 325, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 338, "\';", 338, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n    Télécharger\r\n</button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieToGo.Models.Acheter> Html { get; private set; }
    }
}
#pragma warning restore 1591
