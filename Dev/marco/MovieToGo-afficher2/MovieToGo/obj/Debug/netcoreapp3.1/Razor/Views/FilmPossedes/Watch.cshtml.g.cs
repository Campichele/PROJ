#pragma checksum "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18621faa82dbdfa621fed9c5e8f553c71c2c12d9"
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
#line 1 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\_ViewImports.cshtml"
using MovieToGo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18621faa82dbdfa621fed9c5e8f553c71c2c12d9", @"/Views/FilmPossedes/Watch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37937b1fdfdbd3d0138c66c0cd98884fc97b5693", @"/Views/_ViewImports.cshtml")]
    public class Views_FilmPossedes_Watch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieToGo.Models.Film>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
  
    ViewData["Title"] = "Watch";
    bool check = false;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
 foreach (var item in Model)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
     if (signInManager.IsSignedIn(User) && User.IsInRole("Admin") && item.IdFilm == ViewBag.idFilm)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>");
#nullable restore
#line 15 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
       Write(item.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("        <video width=\"100%\" oncontextmenu=\"return false;\" controls controlsList=\"nodownload\">\r\n            <source");
            BeginWriteAttribute("src", " src=\"", 454, "\"", 477, 1);
#nullable restore
#line 18 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
WriteAttributeValue("", 460, ViewBag.pathFile, 460, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"video/mp4\">\r\n            Your browser does not support HTML video.\r\n        </video>\r\n");
#nullable restore
#line 21 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
        check = true;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
 if (!check)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Vous devez acheter le film avant de le regarder!!!</h1>\r\n");
#nullable restore
#line 28 "C:\Users\Marco Pancini\Desktop\MovieToGo-afficher\MovieToGo\Views\FilmPossedes\Watch.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieToGo.Models.Film>> Html { get; private set; }
    }
}
#pragma warning restore 1591
