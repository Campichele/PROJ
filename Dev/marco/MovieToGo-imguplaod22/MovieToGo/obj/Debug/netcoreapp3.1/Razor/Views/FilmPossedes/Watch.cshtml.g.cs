#pragma checksum "C:\Users\Marco Pancini\Desktop\MovieToGo-imguplaod\MovieToGo\Views\FilmPossedes\Watch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "615b0cdc7ad6bed325d821e31bcf2096e3b88ffe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FilmPossedes_Watch), @"mvc.1.0.view", @"/Views/FilmPossedes/Watch.cshtml")]
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
#line 1 "C:\Users\Marco Pancini\Desktop\MovieToGo-imguplaod\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marco Pancini\Desktop\MovieToGo-imguplaod\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Marco Pancini\Desktop\MovieToGo-imguplaod\MovieToGo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"615b0cdc7ad6bed325d821e31bcf2096e3b88ffe", @"/Views/FilmPossedes/Watch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37937b1fdfdbd3d0138c66c0cd98884fc97b5693", @"/Views/_ViewImports.cshtml")]
    public class Views_FilmPossedes_Watch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieToGo.Models.FilmPossede>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Marco Pancini\Desktop\MovieToGo-imguplaod\MovieToGo\Views\FilmPossedes\Watch.cshtml"
  
    ViewData["Title"] = "Watch";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n\r\n\r\n<video width=\"100%\" controls>\r\n    <source");
            BeginWriteAttribute("src", " src=\"", 146, "\"", 169, 1);
#nullable restore
#line 12 "C:\Users\Marco Pancini\Desktop\MovieToGo-imguplaod\MovieToGo\Views\FilmPossedes\Watch.cshtml"
WriteAttributeValue("", 152, ViewBag.pathFile, 152, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"video/mp4\">\r\n    <source src=\"mov_bbb.ogg\" type=\"video/ogg\">\r\n    Your browser does not support HTML video.\r\n</video>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieToGo.Models.FilmPossede> Html { get; private set; }
    }
}
#pragma warning restore 1591