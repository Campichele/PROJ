#pragma checksum "C:\Users\Maxime\Desktop\MovieToGo-18.06 Wishlist - Final\API\Views\Wishlists\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a43fe7efad7c75b32822e9fdad446f132058bcbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wishlists_Delete), @"mvc.1.0.view", @"/Views/Wishlists/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a43fe7efad7c75b32822e9fdad446f132058bcbd", @"/Views/Wishlists/Delete.cshtml")]
    public class Views_Wishlists_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<API.Models.Wishlist>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Maxime\Desktop\MovieToGo-18.06 Wishlist - Final\API\Views\Wishlists\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Wishlist</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\Maxime\Desktop\MovieToGo-18.06 Wishlist - Final\API\Views\Wishlists\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdFilmNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\Maxime\Desktop\MovieToGo-18.06 Wishlist - Final\API\Views\Wishlists\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdFilmNavigation.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\Maxime\Desktop\MovieToGo-18.06 Wishlist - Final\API\Views\Wishlists\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdUserNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\Maxime\Desktop\MovieToGo-18.06 Wishlist - Final\API\Views\Wishlists\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdUserNavigation.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd class>
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""IdWishlist"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
");
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
