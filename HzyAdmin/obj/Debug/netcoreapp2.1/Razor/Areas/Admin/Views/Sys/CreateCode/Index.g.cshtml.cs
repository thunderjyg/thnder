#pragma checksum "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\Sys\CreateCode\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b805ead329a0f05c8a303c926ecc55756dad26ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Sys_CreateCode_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Sys/CreateCode/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Sys/CreateCode/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Sys_CreateCode_Index))]
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
#line 1 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\_ViewImports.cshtml"
using DbFrame;

#line default
#line hidden
#line 2 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\_ViewImports.cshtml"
using DbFrame.Class;

#line default
#line hidden
#line 3 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#line 4 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\_ViewImports.cshtml"
using Common;

#line default
#line hidden
#line 5 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\_ViewImports.cshtml"
using AppHtml;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b805ead329a0f05c8a303c926ecc55756dad26ee", @"/Areas/Admin/Views/Sys/CreateCode/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c87c7303b3c68f4c1e06eea2974a3ed94f90ea30", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Sys_CreateCode_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Model", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "BLL", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "DAL", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/lib/zTree/css/metroStyle/metroStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/lib/Ko/Knockout-3.4.2.debug.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/lib/zTree/js/jquery.ztree.all.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1088, true);
            WriteLiteral(@"<div id=""hzy-container"">

    <div class=""page-content"">

        <div class=""row"">

            <!--树-->
            <div class=""col-sm-10 col-sm-offset-1"">

                <div class=""col-sm-6"">
                    <div class=""panel"">
                        <div class=""panel-body"">
                            <!--标签树-->
                            <ul id=""tree"" class=""ztree""></ul>

                        </div>

                    </div>
                </div>

                <div class=""col-sm-6"">
                    <div class=""panel"">
                        <div class=""panel-heading"">
                            <h3>配置参数</h3>
                        </div>
                        <div class=""panel-body"">

                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    <h4 class=""example-title"" style=""margin-top:11px;"">类型</h4>
                                    <select class=""form-control"" data-b");
            WriteLiteral("ind=\"value:ClassType\">\r\n                                        ");
            EndContext();
            BeginContext(1088, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90f0fb7e2fe04a5da8e4e1c8f25d2fab", async() => {
                BeginContext(1110, 5, true);
                WriteLiteral("Model");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1124, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(1166, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9098208eb4bf496b98845f759e5b2e1d", async() => {
                BeginContext(1186, 3, true);
                WriteLiteral("BLL");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1198, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(1240, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e55dc74a84241f29f2906be983c887a", async() => {
                BeginContext(1260, 3, true);
                WriteLiteral("DAL");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1272, 2140, true);
            WriteLiteral(@"
                                    </select>
                                </div>

                                <div class=""col-sm-12"">
                                    <h4 class=""example-title"" style=""margin-top:11px;"">创建后保存路径</h4>
                                    <input type=""text"" class=""form-control"" value="""" data-bind=""value:Url"" />
                                </div>

                                <div class=""col-sm-12"">
                                    <h4 class=""example-title"" style=""margin-top:11px;"">类名追加字符</h4>
                                    <input type=""text"" class=""form-control"" value="""" placeholder=""（如：M）不填则默认"" data-bind=""value:Str"" />
                                </div>

                                <div class=""col-sm-12"">
                                    <h4 class=""example-title"" style=""margin-top:11px;"">表</h4>
                                    <input type=""text"" class=""form-control"" value="""" readonly=""readonly"" data-bind=""value:Table"" />
  ");
            WriteLiteral(@"                              </div>

                                <div class=""col-sm-12"">
                                    <h4 class=""example-title"" style=""margin-top:11px;""></h4>
                                    <span style=""color:red;"">注意：<p>点击创建按钮是创建一个表（所以得选中左边要创建的表）</p>点击创建所有是创建库中所有的的表</span>
                                </div>

                                <div class=""form-group"">
                                    <div class=""col-sm-4 col-sm-offset-3"">
                                        <button class=""btn btn-primary"" type=""button"" onclick=""App.Save()"">创建</button>
                                    </div>
                                    <div class=""col-sm-2"">
                                        <button class=""btn btn-primary"" type=""button"" onclick=""App.Save('all')"">创建所有</button>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>");
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n\r\n\r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(3425, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3431, 80, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e131ad777a394a94aa0d60157d6af89b", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3511, 104, true);
                WriteLiteral("\r\n    <style type=\"text/css\">\r\n        .panel {\r\n            padding: 20px;\r\n        }\r\n    </style>\r\n\r\n");
                EndContext();
            }
            );
            DefineSection("js", async() => {
                BeginContext(3630, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3636, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d8e72ddb7d14605acc0e2b90759ef9e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3698, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3704, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7144e2ef9034161b1fbec4a1e7eea6d", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3772, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3778, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d17ee121aa4b4ecca6b2534653f83070", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3846, 355, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        model = new vModel();
        $(function () {
            ko.applyBindings(model);
            App.GetTree();
            model.Url(d);
            model.ClassType(""Model"");
        });

        var App = {
            GetTree: function () {
                admin.ajax({
                    url: """);
                EndContext();
                BeginContext(4202, 33, false);
#line 107 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\Sys\CreateCode\Index.cshtml"
                     Write(Url.Action("GetDatabaseAllTable"));

#line default
#line hidden
                EndContext();
                BeginContext(4235, 1914, true);
                WriteLiteral(@""",
                    success: function (r) {
                        var setting = {
                            check: {
                                enable: false,
                                chkboxType: { ""Y"": ""ps"", ""N"": ""ps"" }
                            },
                            view: {
                                dblClickExpand: true
                            },
                            data: {
                                simpleData: {
                                    enable: true,
                                    idKey: ""id"",
                                    pIdKey: ""pId"",
                                    rootPId: 0,
                                },
                                key: { checked: 'checked' }
                            },
                            callback: {
                                onClick: function (event, treeId, treeNode) {
                                    //console.log(treeNode.id);
                       ");
                WriteLiteral(@"             var string = treeNode.id;
                                    if (string.indexOf('$~') != -1) {
                                        string = string.split('$~')[0];
                                    }
                                    model.Table(string);
                                },
                            }
                        };
                        zTree = $.fn.zTree.init($(""#tree""), setting, r.value);
                        //zTree.expandAll(true);//展开所有
                    }
                });
            },
            Save: function (tag) {
                if (!tag) {
                    model.isall(false);
                    if (!model.Table()) {
                        return admin.msg(""要创建单个类请在左边选则要创建的表!"", ""警告"");
                    }
                }
                admin.ajax({
                    url: """);
                EndContext();
                BeginContext(6150, 18, false);
#line 150 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\Sys\CreateCode\Index.cshtml"
                     Write(Url.Action("Save"));

#line default
#line hidden
                EndContext();
                BeginContext(6168, 299, true);
                WriteLiteral(@""",
                    data: model,
                    success: function (r) {
                        if (r.status == 1) {
                            admin.msg(""创建成功!"", ""成功"");
                        }
                    }
                });
            }
        };
        var d = """);
                EndContext();
                BeginContext(6468, 16, false);
#line 160 "F:\wnmp\cms_HzyAdmin\HzyAdmin\Areas\Admin\Views\Sys\CreateCode\Index.cshtml"
            Write(ViewData["Path"]);

#line default
#line hidden
                EndContext();
                BeginContext(6484, 292, true);
                WriteLiteral(@""";
        function vModel() {
            this.ClassType = ko.observable(""Model"");
            this.Url = ko.observable(d);
            this.Str = ko.observable("""");
            this.Table = ko.observable("""");
            this.isall = ko.observable(true);
        }

    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
