#pragma checksum "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\StatementofWorkingObjection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70a6f19aa379097a2996f362b4783a03b3dcf68a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_StatementofWorkingObjection), @"mvc.1.0.view", @"/Views/Client/StatementofWorkingObjection.cshtml")]
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
#line 1 "D:\TFS-Gov\ATS_Government Project\ATS\Views\_ViewImports.cshtml"
using ATS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TFS-Gov\ATS_Government Project\ATS\Views\_ViewImports.cshtml"
using ATS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70a6f19aa379097a2996f362b4783a03b3dcf68a", @"/Views/Client/StatementofWorkingObjection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab70b513d5bb9477a881e9ef4fc41a570a926f05", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_StatementofWorkingObjection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Client_plugin/Client_Vue_Controllers/ObjectionStatementofWorking.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\StatementofWorkingObjection.cshtml"
  
    ViewData["Title"] = "StatementofWorkingObjection";
    Layout = "~/Views/Shared/Client/Client_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n    <div id=\"osofw\" style=\"margin-top:6%\">\r\n\r\n");
            WriteLiteral(@"

        <div class=""container"">
            <div class=""row  filter-row"">

                <div class=""col-md-2"">
                    <div class=""dropdown"">
                        <a class="" btn btn-info btn-sm w-100 dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown""
                           aria-haspopup=""true"" aria-expanded=""false"" v-bind:class=""{ active: isproject}"">
                            {{Departmentcselect}}
                        </a>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
");
            WriteLiteral(@"                            <a class=""dropdown-item"" v-for=""Department in DepartmentList""
                               v-on:click=filterDepartment(Department.id,Department.name)>{{Department.name}}</a>
                        </div>
                    </div>
                </div>


                <div class=""col-md-2"">
                    <div class=""dropdown"">
                        <a class="" btn btn-info btn-sm w-100 dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown""
                           aria-haspopup=""true"" aria-expanded=""false"">
                            {{Aduit}}
                        </a>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item text-danger"" v-show=""isAudit"">
                                <span>Department select </span>
                            </a>

                            <a class=""dropdown-item"" v-for=""Audit in filterAudit"" v-on:click=Auditfilter");
            WriteLiteral("(Audit.id,Audit.name)>\r\n\r\n                                {{Audit.name}}\r\n\r\n                            </a>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n");
            WriteLiteral(@"
                <div class=""col-md-2"">
                    <div class=""dropdown dropdown-hover  "">
                        <a class="" btn btn-info btn-sm w-100 dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown""
                           aria-haspopup=""true"" aria-expanded=""false"">
                            {{YearsSelect}}
                        </a>
                        <div class=""dropdown-menu gg"" aria-labelledby=""dropdownMenuButton"" style=""height:300px;overflow-y:scroll;overflow-x:hidden"">
                            <a class=""dropdown-item"" v-for="" years in yearsList"" v-on:click=""filtterYears(years)"" :value=""years"">{{years}}</a>

                        </div>
                    </div>
                </div>

                <div class=""col-md-2"">
                    <div class=""dropdown dropdown-hover  "">
                        <a class="" btn btn-info btn-sm w-100 dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown""
                           aria-haspopu");
            WriteLiteral(@"p=""true"" aria-expanded=""false"">
                            {{DivisionSelect}}
                        </a>
                        <div class=""dropdown-menu gg"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item"" v-for="" division in DivisionList""
                               v-on:click=Division(division.id,division.name)>{{division.name}}</a>

                        </div>
                    </div>
                </div>
                <div class=""col-md-2"">
                    <div class=""dropdown dropdown-hover  "">
                        <a class="" btn btn-info btn-sm w-100 dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown""
                           aria-haspopup=""true"" aria-expanded=""false"">
                            {{DistrictSelect}}
                        </a>
                        <div class=""dropdown-menu gg"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item text-danger"" v-show=""is");
            WriteLiteral(@"Division"">
                                <span>Division select </span>
                            </a>
                            <a class=""dropdown-item"" v-for="" Distric in DistricList"" v-on:click=District(Distric.id,Distric.name)>{{Distric.name}}</a>

                        </div>
                    </div>
                </div>
                <div class=""col-md-2"">
                    <div class=""dropdown dropdown-hover  "">


                        <a class="" btn btn-info btn-sm w-100 dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown""
                           aria-haspopup=""true"" aria-expanded=""false"">
                            {{UpazilaSelect}}
                        </a>


                        <div class=""dropdown-menu gg"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item text-danger"" v-show=""isDistric"">
                                <span>Distric select </span>
                            </a>
                  ");
            WriteLiteral(@"          <a class=""dropdown-item"" v-for="" Upazila in UpazilaList"" v-on:click=Upzila(Upazila.id,Upazila.name)>{{Upazila.name}}</a>

                        </div>

                    </div>
                </div>

                <div class=""container r-mb-0 pt-1 "" v-show=""showsClear"">
                    <div class=""float-right Clear-All"">
                        <button class=""btn btn-danger btn-sm pl-5 pr-5"" v-on:click=""ClearAll()"">Clear All</button>
                    </div>
                </div>


            </div>
        </div>

        <div class=""listof-data mt-4 main-p-l"">
            <div class=""container"">
                <div class=""new-arrive-titel mb-4"">
                    <div class=""row"">

                        <div class=""col-md-4 mb-3"">
                            <label for=""exampleInputEmail1""> Select Your Start Date</label>
                            <div class=""input-group flex-nowrap"">

                                <div class=""input-group-prepend"">");
            WriteLiteral(@"

                                    <span class=""input-group-text"" id=""addon-wrapping"">
                                        <span class=""pr-2"">
                                            <i class=""fas fa-step-backward""></i>
                                        </span> Start Date
                                    </span>
                                </div>
                                <input v-on:change=""FlitterByStartDate()"" type=""date"" class=""form-control"" v-model=""filterObject.submissionStartDate"" name=""startDate"" autocomplete=""off"" placeholder=""startDate"">
                            </div>

                        </div>

                        <div class=""col-md-4 mb-3"">
                            <label for=""exampleInputEmail1""> Select Your End Date</label>
                            <div class=""input-group flex-nowrap"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""addon-wrapp");
            WriteLiteral(@"ing"">
                                        <span class=""pr-2"">
                                            <i class=""fas fa-step-forward""></i>
                                        </span> End Date
                                    </span>
                                </div>
                                <input v-on:change=""FlitterByEndDate()"" type=""date"" class=""form-control"" v-model=""filterObject.submissionEndDate"" name=""endDate"" autocomplete=""off"" placeholder=""endDate"">
                            </div>

                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""exampleInputEmail1"">Search Mobile No</label>
                            <div class=""input-group flex-nowrap"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""addon-wrapping"">
                                        <span class=""pl-2 pr-2""> <i class=""fas fa-search""></i> <");
            WriteLiteral(@"/span>

                                    </span>
                                </div>

                                <input v-on:keyup=""FlitterBymobileNo(filterObject.mobileNo)"" type=""text"" class=""form-control"" v-model=""filterObject.mobileNo"" name=""search"" autocomplete=""off"" placeholder=""Search"">
                            </div>
                        </div>
                    </div>

                    <div class=""progress"" style=""height: 1px; background-color:#adb5bd;"">
                        <div role=""progressbar"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar"">
                        </div>
                    </div>
                </div>



                <table class=""table table-bordered table-striped text-center"">
                    <thead>
                        <tr>
                            <th>Sl</th>
                            <th>Id</th>

                            <th> Name</th>
                            <th> Total ");
            WriteLiteral(@"Objection</th>
                            <th>Amount</th>
                            <th>Mobile No</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>


                        <tr v-for=""(data, index) in ObjectionGropbyList"">
                            <th>{{index+1}}</th>
                            <td> {{data.employeeId}}</td>
                            <td> {{data.officialName}}</td>
                            <td> <span class=""badge badge-secondary p-1"">{{data.totalObjection}} </span> </td>

                            <td>Tk {{data.amount}} </td>
                            <td>{{data.mobileNo}}</td>
");
            WriteLiteral(@"                            <td>
                                <button class=""btn-group btn-info btn-group-sm""
                                        v-on:click=""viewsingalperson(data.employeeId)"">
                                    <span class=""pr-2""> <i class=""fas fa-eye""></i> </span> View
                                    Details
                                </button>
                            </td>

                        </tr>
");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n                    </tbody>\r\n\r\n                </table>\r\n\r\n            </div>\r\n\r\n\r\n\r\n        </div>\r\n\r\n    </div>\r\n");
            DefineSection("osofwjs", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70a6f19aa379097a2996f362b4783a03b3dcf68a15087", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
