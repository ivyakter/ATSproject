#pragma checksum "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\swoSingalperson.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd9c049b42a403fcdd63f0c418f77527c55297f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_swoSingalperson), @"mvc.1.0.view", @"/Views/Client/swoSingalperson.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd9c049b42a403fcdd63f0c418f77527c55297f4", @"/Views/Client/swoSingalperson.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab70b513d5bb9477a881e9ef4fc41a570a926f05", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_swoSingalperson : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Client_plugin/img/emp.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:50px; margin-bottom: 15px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Client_plugin/Client_Vue_Controllers/swosinglperson.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\swoSingalperson.cshtml"
  
    ViewData["Title"] = "swoSingalperson";
    Layout = "~/Views/Shared/Client/Client_Layout.cshtml";
    var getid = ViewBag.Viewid;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p style=\"display:none\" id=\"getid\">");
#nullable restore
#line 9 "D:\TFS-Gov\ATS_Government Project\ATS\Views\Client\swoSingalperson.cshtml"
                              Write(ViewBag.Viewid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<div id=\"swosinglperson\" style=\"margin-top:6%\">\r\n\r\n\r\n    <div class=\"swosinglperson\">\r\n        <div class=\"container\">\r\n            <div class=\"basic-info text-center mt-5\">\r\n                <div class=\"emp-img\"> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bd9c049b42a403fcdd63f0c418f77527c55297f45411", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" </div>
                <p style=""margin-bottom: 5px;font-weight: 600;""> Employee Name : {{commonpersondataList.officialName}}</p>
                <p>
                    <span>
                        Designation and Current Workplace : {{commonpersondataList.currentdesignation}}, {{commonpersondataList.workplace}}<br>
                        - ?????? ?????????????????????????????? ?????????????????? ???????????? ??????????????? ??? ?????????????????????????????? / ????????? ???????????? ?????????????????? ???????????????????????? / ??????????????????????????? ???????????????????????? ?????????????????? ??????????????????
                        :
                    </span>
                </p>
            </div>
        </div>
    </div>



    <div class=""listof-data mt-4 main-p-l"" id=""hhhh"">
        <div class=""container"">

            <table class=""table table-bordered table-striped"">
                <thead>
                    <tr>
                        <th>Sl</th>
                        <th>Paragraph</th>
                        <th>Project</th>
                        <th> Audit </th>
                        <th>Division</th>

                ");
            WriteLiteral(@"        <th>Title</th>
                        <th>Amount</th>
                        <th>Process</th>
                        <th>Pending</th>
                        <th>Settled</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>


                    <tr class=""text-center"" v-for=""(data, index) in individualpersonList"">
                        <td> {{index+1}} </td>
                        <th> {{data.para}}</th>
                        <td> {{data.projectName}} </td>
                        <td>{{data.auditName}} </td>

                        <td>{{data.divisionName}} </td>
                        <td> {{data.title}} </td>
                        <td>{{data.amount}} Tk  </td>

                        <td>
                            <span class="" text-danger font-weight-bolder"" v-if=""data.statusProcess==1""> Process </span>
                        </td>

                        <td>
                            <");
            WriteLiteral(@"span class=""text-warning font-weight-bolder"" v-if=""data.statusPending==2""> Pending </span>
                        </td>

                        <td>
                            <span class=""text-success font-weight-bolder"" v-if=""data.statusSettled==3""> Settled </span>
                        </td>


                        <td>
                            <button class=""btn-group btn-info btn-group-sm "" v-on:click=""Viewdata(data.id)"" data-toggle=""modal"" data-target="".modal-add"">
                                <span class=""pr-2""> <i class=""fas fa-eye""></i> </span> View Details
                            </button>
                        </td>

                    </tr>

                    <tr class=""total-count"">

                        <td colspan=""6"" class=""text-right pr-2 text-info"">  <span>Total Amount = </span>  </td>
                        <td class=""text-info"">  <span> {{totalAmount}}  Tk </span> </td>
                        <td class=""text-danger text-center""> <span> {{count");
            WriteLiteral(@"one}} </span> </td>
                        <td class=""text-warning text-center""> <span>{{counttwo}} </span>  </td>
                        <td class=""text-success text-center"">  <span>{{countthree}}  </span> </td>
                        <td>  <span class=""pl-2"">Total = {{Totalcount}} </span></td>
                    </tr>


                    <!-- <tr class=""total-count"">

                        <td colspan=""5"" class=""text-right pr-2 text-info"">  <span>Total Amount </span>  </td>
                        <td class=""text-info"">  <span> Tk {{total}} </span> </td>
                        <td class=""text-danger text-center""> <span>Process = {{countone}} </span> </td>
                        <td class=""text-warning text-center""> <span>Pending =  {{counttwo}} </span>  </td>
                        <td  class=""text-success text-center"">  <span>Settled =  {{countthree}} </span> </td>
                        <td>  <span class=""pl-2"">Status =  {{count}}</span></td>
                      </tr> -->

 ");
            WriteLiteral(@"               </tbody>

            </table>

        </div>
    </div>




    <div class=""modal fade bd-example-modal-lg modal-add"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">

                <a class=""close text-right pr-3 pt-2"" data-dismiss=""modal"" aria-label=""Close"" style=""cursor:pointer;color:red"">
                    <span aria-hidden=""true"">&times;</span>
                </a>

                <div class=""modal-body"">
                    <div id=""print"">
                        <div class=""padding-left-right style-ul-li"">

                            <ul>
                                <li> <span> <b>para : </b> </span> {{viewsinglpersondatadata.para}}  </li>
                                <li> <b> Name : </b> <span> </span>  {{viewsinglpersondatadata.officialName}} </li>
                                <li>  <b>Emaloyee Id : </b> <span> {{vi");
            WriteLiteral(@"ewsinglpersondatadata.employeeId}}</span>   </li>
                                <li>  <b>Objection Titel : </b> <span></span>  {{viewsinglpersondatadata.title}} </li>
                                <li>  <b>First Designation : </b> <span></span>  {{viewsinglpersondatadata.firstdesignation}} ,<span>Current Designation :</span>  {{viewsinglpersondatadata.currentdesignation}} </li>
                                <li>  <b>Date of Birth : </b> <span></span>  {{viewsinglpersondatadata.dateofBirth}},  <span>Joining Date :</span>  {{viewsinglpersondatadata.joiningDate}}  </li>
                                <li>  <b>Years : </b> <span></span>  {{viewsinglpersondatadata.years}} </li>
                                <li>  <b>Department Name : </b> <span></span>  {{viewsinglpersondatadata.departmentName}}, <span> <b>Audit Name : </b></span>  {{viewsinglpersondatadata.auditName}}, <span> <b> Project Name : </b></span>  {{viewsinglpersondatadata.projectName}} </li>
                                <li> <span> <b");
            WriteLiteral(@">Division Name : </b> </span>  {{viewsinglpersondatadata.divisionName}}, <span> <b> District Name : </b></span>  {{viewsinglpersondatadata.districtName}}, <span> <b> Upazila Name : </b></span>  {{viewsinglpersondatadata.upazilaName}} </li>
                                <li> <span> <b>Mobile No : </b> </span>  {{viewsinglpersondatadata.mobileNo}}, <span> <b> Email : </b></span>  {{viewsinglpersondatadata.email}}, <span> <b> WorkPlace : </b> </span>  {{viewsinglpersondatadata.workplace}}</li>
                                <li> <span> <b> Amount : </b></span>  {{viewsinglpersondatadata.amount}} </li>
                                <li> <span> <b>Audit objection create Date : </b> </span>  {{viewsinglpersondatadata.auditobjectioncreateDate}}, <span> <b>Audit objection submissions Date : </b> </span>  {{viewsinglpersondatadata.auditobjectionsubmissionsDate}} </li>
                                <li>
                                    <b>Status : </b>
                                    <span class="" t");
            WriteLiteral(@"ext-danger font-weight-bolder"" v-if=""viewsinglpersondatadata.statusProcess==1""> Process </span>
                                    <span class=""text-warning font-weight-bolder"" v-if=""viewsinglpersondatadata.statusPending==2""> Pending </span>
                                    <span class=""text-success font-weight-bolder"" v-if=""viewsinglpersondatadata.statusSettled==3""> Settled </span>
                                </li>

                                <li>
                                    <b>Description :</b>

                                    <p v-html=""viewsinglpersondatadata.description""></p>

                                </li>
                            </ul>
                        </div>

                    </div>


                    <div class=""text-center"">
                        <button class=""btn btn-outline-secondary"" ");
            WriteLiteral("@click=\"print\">Print</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("swoSingalpersonjs", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd9c049b42a403fcdd63f0c418f77527c55297f415330", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
            WriteLiteral("\r\n\r\n");
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
