#pragma checksum "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9897c834f0b29e36b01260098234737c909a7173"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_SearchPartial), @"mvc.1.0.view", @"/Views/Post/SearchPartial.cshtml")]
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
#line 1 "C:\Users\Tanya\source\MySite\MySite\Views\_ViewImports.cshtml"
using MySite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tanya\source\MySite\MySite\Views\_ViewImports.cshtml"
using MySite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9897c834f0b29e36b01260098234737c909a7173", @"/Views/Post/SearchPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c57b07ed47a13a5df47126c961e9c47f26c1ac41", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_SearchPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MySite.Models.Post>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
   int counter = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
 foreach (var post in Model)
{
    if (counter != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr />\r\n");
#nullable restore
#line 9 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-3\">\r\n");
#nullable restore
#line 12 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
             if (post.Image != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 273, "\"", 298, 2);
            WriteAttributeValue("", 280, "/viewPost/", 280, 10, true);
#nullable restore
#line 14 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
WriteAttributeValue("", 290, post.Id, 290, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img class=\"search-img-small\"");
            BeginWriteAttribute("src", " src=\"", 329, "\"", 392, 2);
            WriteAttributeValue("", 335, "data:image/jpg;base64,", 335, 22, true);
#nullable restore
#line 14 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
WriteAttributeValue("", 357, Convert.ToBase64String(post.Image), 357, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></a>\r\n");
#nullable restore
#line 15 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"col\">\r\n            <div>\r\n                <a class=\"a-title\"");
            BeginWriteAttribute("href", " href=\"", 513, "\"", 538, 2);
            WriteAttributeValue("", 520, "/viewPost/", 520, 10, true);
#nullable restore
#line 19 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
WriteAttributeValue("", 530, post.Id, 530, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h3 class=\"a-title\" style=\"font-size:15px;padding-top:10px;\">");
#nullable restore
#line 19 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
                                                                                                                     Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3></a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\Tanya\source\MySite\MySite\Views\Post\SearchPartial.cshtml"
    counter++;
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MySite.Models.Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
