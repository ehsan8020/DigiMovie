#pragma checksum "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "689bf6312ea426aa09ae244a3be892850814947e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Delete), @"mvc.1.0.view", @"/Views/Categories/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Delete.cshtml", typeof(AspNetCore.Views_Categories_Delete))]
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
#line 1 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\_ViewImports.cshtml"
using HiShop;

#line default
#line hidden
#line 2 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\_ViewImports.cshtml"
using HiShop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"689bf6312ea426aa09ae244a3be892850814947e", @"/Views/Categories/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de869a20bf865f147f1447ec25d5858d4fa88d9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HiShop.Models.Category>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteDone", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
  
    ViewData["Title"] = "حذف دسته بندی";

#line default
#line hidden
            BeginContext(82, 44, true);
            WriteLiteral("<br class=\"my-3\" />\r\n<h2 class=\"text-right\">");
            EndContext();
            BeginContext(127, 17, false);
#line 7 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
                  Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(144, 309, true);
            WriteLiteral(@" </h2>
<hr />

<table class=""table table-bordered table-hover table-striped table-info text-center table-sm"">
    <thead>
        <tr>
            <td colspan=""2"">آیا از حذف دسته بندی زیر اطمینان دارید ؟</td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td class=""align-middle"">");
            EndContext();
            BeginContext(454, 37, false);
#line 18 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
                                Write(Html.DisplayNameFor(m => m.ImagePath));

#line default
#line hidden
            EndContext();
            BeginContext(491, 27, true);
            WriteLiteral("</td>\r\n            <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 518, "\"", 540, 1);
#line 19 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
WriteAttributeValue("", 524, Model.ImagePath, 524, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 541, "\"", 574, 5);
            WriteAttributeValue("", 547, "سایت", 547, 4, true);
            WriteAttributeValue(" ", 551, "های", 552, 4, true);
            WriteAttributeValue(" ", 555, "شاپ", 556, 4, true);
            WriteAttributeValue(" ", 559, "-", 560, 2, true);
#line 19 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
WriteAttributeValue(" ", 561, Model.Title, 562, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 575, "\"", 610, 5);
            WriteAttributeValue("", 583, "سایت", 583, 4, true);
            WriteAttributeValue(" ", 587, "های", 588, 4, true);
            WriteAttributeValue(" ", 591, "شاپ", 592, 4, true);
            WriteAttributeValue(" ", 595, "-", 596, 2, true);
#line 19 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
WriteAttributeValue(" ", 597, Model.Title, 598, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(611, 55, true);
            WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(667, 33, false);
#line 22 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
           Write(Html.DisplayNameFor(m => m.Title));

#line default
#line hidden
            EndContext();
            BeginContext(700, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(724, 11, false);
#line 23 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(735, 52, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(788, 39, false);
#line 26 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
           Write(Html.DisplayNameFor(m => m.Description));

#line default
#line hidden
            EndContext();
            BeginContext(827, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(851, 17, false);
#line 27 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
           Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(868, 49, true);
            WriteLiteral(" </td>\r\n        </tr>\r\n\r\n    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(917, 372, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44f025f32df8463dbe4e74206c834450", async() => {
                BeginContext(947, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(953, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d16e5e3486cd47779fc31b7f7c43d70a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 33 "C:\Users\Ehsan\Desktop\HiShop\HiShop\Views\Categories\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(989, 142, true);
                WriteLiteral("\r\n    <button type=\"submit\" class=\"btn btn-danger\">\r\n        <i class=\"fas fa-trash align-middle\"></i>\r\n        حذف نهایی\r\n    </button>\r\n    ");
                EndContext();
                BeginContext(1131, 149, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d7eaf9aedad44369226f3b2400764f6", async() => {
                    BeginContext(1182, 94, true);
                    WriteLiteral("\r\n        <i class=\"fas fa-share align-middle\"></i>\r\n        بازگشت به لیست دسته بندی ها\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1280, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1289, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HiShop.Models.Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
