#pragma checksum "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57c6081eec6ce57b0a3c95ca916aae2e2872faa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_Report), @"mvc.1.0.view", @"/Views/Client/Report.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57c6081eec6ce57b0a3c95ca916aae2e2872faa2", @"/Views/Client/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab70b513d5bb9477a881e9ef4fc41a570a926f05", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Client_plugin/Client_Vue_Controllers/Repot.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\Report.cshtml"
  
    ViewData["Title"] = "Report";
    Layout = "~/Views/Shared/Client/Client_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"Repot\" style=\"margin-top:6%\">\r\n\r\n");
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
            WriteLiteral(@"                        <a class=""dropdown-item"" v-for=""Department in DepartmentList""
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

                        <a class=""dropdown-item"" v-for=""Audit in filterAudit"" v-on:click=Auditfilter(Audit.id,Audit.name)>

                            {{Audit.na");
            WriteLiteral("me}}\r\n\r\n                        </a>\r\n\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n\r\n");
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
                       aria-haspopup=""true"" aria-expanded=""false"">
                        {{D");
            WriteLiteral(@"ivisionSelect}}
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
                        <a class=""dropdown-item text-danger"" v-show=""isDivision"">
                            <span>Division select </span>
                        </a>
                       ");
            WriteLiteral(@" <a class=""dropdown-item"" v-for="" Distric in DistricList"" v-on:click=District(Distric.id,Distric.name)>{{Distric.name}}</a>

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
                        <a class=""dropdown-item"" v-for="" Upazila in UpazilaList"" v-on:click=Upzila(Upazila.id,Upazila.name)>{{Upazila.name}}</a>

                    </div>

                </div>
    ");
            WriteLiteral(@"        </div>

            <div class=""container r-mb-0 pt-1 "" v-show=""showsClear"">
                <div class=""float-right Clear-All"">
                    <button class=""btn btn-danger btn-sm pl-5 pr-5"" v-on:click=""ClearAll()"">Clear All</button>
                </div>
            </div>


        </div>
    </div>

        <div class="" listof-data style-table-repot mt-4 main-p-l"">
            <div class=""container"">
                <div class=""new-arrive-titel mb-4"">
                    <div class=""row"">

                        <div class=""col-md-4 mb-3"">
                            <label for=""exampleInputEmail1""> Select Your Start Date</label>
                            <div class=""input-group flex-nowrap"">

                                <div class=""input-group-prepend"">

                                    <span class=""input-group-text"" id=""addon-wrapping"">
                                        <span class=""pr-2"">
                                            <i class=""fas fa");
            WriteLiteral(@"-step-backward""></i>
                                        </span> Start Date
                                    </span>
                                </div>
                                <input v-on:change=""FlitterByStartDate()"" type=""date"" class=""form-control"" v-model=""filterObject.submissionStartDate"" autocomplete=""off"" placeholder=""startDate"">
                            </div>

                        </div>

                        <div class=""col-md-4 mb-3"">
                            <label for=""exampleInputEmail1""> Select Your End Date</label>
                            <div class=""input-group flex-nowrap"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""addon-wrapping"">
                                        <span class=""pr-2"">
                                            <i class=""fas fa-step-forward""></i>
                                        </span> End Date
                       ");
            WriteLiteral(@"             </span>
                                </div>
                                <input v-on:change=""FlitterByEndDate()"" type=""date"" class=""form-control"" v-model=""filterObject.submissionEndDate"" autocomplete=""off"" placeholder=""endDate"">
                            </div>

                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""exampleInputEmail1"">Search By Mobile-No</label>
                            <div class=""input-group flex-nowrap"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""addon-wrapping"">
                                        <span class=""pl-2 pr-2""> <i class=""fas fa-search""></i> </span>

                                    </span>
                                </div>

                                <input v-on:keyup=""FlitterBymobileNo(filterObject.mobileNo)"" type=""text"" class=""form-control"" v-model=""filterObje");
            WriteLiteral(@"ct.mobileNo"" autocomplete=""off"" placeholder=""Search"">
                            </div>
                        </div>



                    </div>


                    <div class=""progress"" style=""height: 1px; background-color:#adb5bd;"">
                        <div role=""progressbar"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100"" class=""progress-bar"">
                        </div>
                    </div>
                </div>

                <div>
                    <div id=""repotId"">
                        <table class=""table table-bordered table-striped style-table-repot"">
                            <thead>
                                <tr>
                                    <th>Sl</th>
                                    <th>Id</th>
                                    <th>Project</th>
                                    <th> Audit </th>

                                    <th>Title</th>
                                    <th>Amount</th>
             ");
            WriteLiteral(@"                       <th>Process</th>
                                    <th>Pending</th>
                                    <th>Settled</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>


                                <tr v-for=""(data, index) in finddata"">
                                    <th>{{index+1}}</th>
                                    <td> {{data.employeeId}}</td>
                                    <td>
                                        {{data.projectName}}
                                    </td>
                                    <td> {{data.auditName}}</td>
                                    <td> {{data.title}}</td>

                                    <td>Tk {{data.amount}} </td>

                                    <td>
                                        <span class="" text-danger font-weight-bolder"" v-if=""data.statusProcess==1""> Proc");
            WriteLiteral(@"ess </span>
                                    </td>

                                    <td>
                                        <span class=""text-warning font-weight-bolder"" v-if=""data.statusPending==2""> Pending </span>
                                    </td>

                                    <td>
                                        <span class=""text-success font-weight-bolder"" v-if=""data.statusSettled==3""> Settled </span>
                                    </td>

                                    <td>
                                        <button class=""btn-group btn-info btn-group-sm"" data-toggle=""modal"" data-target="".repot-modal""
                                                v-on:click=""viewObjectrion(data.id)"">
                                            <span class=""pr-2""> <i class=""fas fa-eye""></i> </span> View
                                            Details
                                        </button>
                                    </td>

       ");
            WriteLiteral(@"                         </tr>

                            </tbody>

                        </table>
                    </div>


                    <div class=""text-right"">
                        <div class=""text-right comment-btn"">
                            <button  class=""btn-msp"" ");
            WriteLiteral(@"@click=""print"">Print</button>
                        </div>

                    </div>

                </div>


                <div class=""modal fade bd-example-modal-lg repot-modal"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
                    <div class=""modal-dialog modal-lg"">
                        <div class=""modal-content"">

                            <a class=""close text-right pr-3 pt-2"" data-dismiss=""modal"" aria-label=""Close"" style=""cursor:pointer;color:red"">
                                <span aria-hidden=""true"">&times;</span>
                            </a>

                            <div class=""modal-body"" id=""printinduvisul"">

                                <div class=""padding-left-right style-ul-li"">

                                    <ul>
                                        <li> <span> <b>para : </b> </span> {{viewobjectionlist.para}}  </li>
                                        <li> <b> Name : </b> <span> </span>  {{viewobjec");
            WriteLiteral(@"tionlist.officialName}} </li>
                                        <li>  <b>Emaloyee Id : </b> <span> {{viewobjectionlist.employeeId}}</span>   </li>
                                        <li class=""w-100""> <span class=""w-100"">  <b>Objection Titel : </b>  {{viewobjectionlist.title}} </span> </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>First Designation : </b>   {{viewobjectionlist.firstdesignation}}</span>
                                            <span class=""w-50""> <b>Current Designation :  </b> {{viewobjectionlist.currentdesignation}}</span>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Date of Birth : </b>   {{viewobjectionlist.dateofBirth}} </span>
                                            <span class=""w-50""> <b>Joining Date : </b>  {{viewobjectionlist.joining");
            WriteLiteral(@"Date}}  </span>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Department Name :  </b>  {{viewobjectionlist.departmentName}} </span>
                                            <span class=""w-50""> <b>Audit Name : </b> {{viewobjectionlist.auditName}}  </span>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Project Name :  </b>  {{viewobjectionlist.projectName}} </span>
                                            <span class=""w-50""> <b>Amount : </b>  {{viewobjectionlist.amount}} </span>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Address  :</b>  {{viewobjectionlist.divisionName}}, {{viewobjectionlist.dis");
            WriteLiteral(@"trictName}}, {{viewobjectionlist.upazilaName}} </span>
                                            <span class=""w-50""> <b>WorkPlace : </b>    {{viewobjectionlist.workplace}} </span>
                                        </li>
                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Mobile No :  </b>  {{viewobjectionlist.mobileNo}} </span>
                                            <span class=""w-50""> <b>Email : </b>  {{viewobjectionlist.email}} </span>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Audit objection create Date : </b>  {{viewobjectionlist.auditobjectioncreateDate}} </span>
                                            <span class=""w-50""> <b>Audit objection submissions Date : </b>  {{viewobjectionlist.auditobjectionsubmissionsDate}} </span>
                                      ");
            WriteLiteral(@"  </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-50""> <b>Year: </b> <span></span>  {{viewobjectionlist.years}}</span>
                                            <span class=""w-50"">
                                                <b>Status : </b>
                                                <span class="" text-danger font-weight-bolder"" v-if=""viewobjectionlist.statusProcess==1""> Process </span>
                                                <span class=""text-warning font-weight-bolder"" v-if=""viewobjectionlist.statusPending==2""> Pending </span>
                                                <span class=""text-success font-weight-bolder"" v-if=""viewobjectionlist.statusSettled==3""> Settled </span>
                                            </span>

                                        </li>

                                        <li>
                                            <b>Description :</b>
        ");
            WriteLiteral(@"                                    <p v-html=""viewobjectionlist.description""></p>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-100""> <b>Employee Reply Date : </b>  {{viewobjectionlist.employeeReplyDate}} </span>
                                        </li>
                                        <li class=""w-100 d-flex"">
                                            <span class=""w-100""> <b>Employee Reply: </b>  {{viewobjectionlist.employeeReply}} </span>
                                        </li>

                                        <li class=""w-100 d-flex"">
                                            <span class=""w-100""> <b>Audit Feetback Date: </b>  {{viewobjectionlist.auditFeetbackDate}} </span>
                                        </li>
                                        <li class=""w-100 d-flex"">
                                            <span class=");
            WriteLiteral(@"""w-100""> <b>Audit Feetback: </b>  {{viewobjectionlist.auditFeetback}} </span>
                                        </li>
                                    </ul>

                                </div>

                            </div>

                            <div class=""text-center"">
                                <div class=""text-right comment-btn mr-2"">
                                    <button class=""btn-msp"" ");
            WriteLiteral(@"@click=""printinduvisul"">Print</button>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>



    </div>
");
            DefineSection("RepotJs", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57c6081eec6ce57b0a3c95ca916aae2e2872faa223012", async() => {
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
                WriteLiteral("\r\n    ");
            }
            );
            WriteLiteral("\r\n");
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
