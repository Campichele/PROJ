#pragma checksum "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d45302f7621417bf7546a7257bc6025818678f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wishlists_Details), @"mvc.1.0.view", @"/Views/Wishlists/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d45302f7621417bf7546a7257bc6025818678f4", @"/Views/Wishlists/Details.cshtml")]
    public class Views_Wishlists_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<API.Models.Wishlist>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Wishlist</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdFilmNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdFilmNavigation.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdUserNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdUserNavigation.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 670, "\"", 702, 1);
#nullable restore
#line 28 "C:\Users\maxpichonnat\Desktop\MovieToGo-16.06 tout ensemble\API\Views\Wishlists\Details.cshtml"
WriteAttributeValue("", 685, Model.IdWishlist, 685, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<API.Models.Wishlist> Html { get; private set; }
    }
}
#pragma warning restore 1591
