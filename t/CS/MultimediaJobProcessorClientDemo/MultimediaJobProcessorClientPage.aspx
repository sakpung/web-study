<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MultimediaJobProcessorClientPage.aspx.cs"
   Inherits="MultimediaJobProcessorClientDemo.MultimediaJobProcessorClientPage" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
   <meta name="robots" content="index, follow" />
   <title>MultimediaJobProcessorClient Main Page</title>
   <meta name="description" content="" />
   <meta name="keywords" content="" />
   <link href="Resources/css/main.css" rel="stylesheet" type="text/css" />
   <style type="text/css">
      .style3
      {
         height: 110px;
         width: 751px;
      }
      .style5
      {
         height: 110px;
         width: 172px;
      }
      .style7
      {
         height: 168px;
      }
      .style8
      {
         width: 150px;
      }
      .style9
      {
         width: 316px;
         margin-left: 40px;
      }
      #Button1
      {
         height: 23px;
      }
      .style11
      {
         height: 306px;
      }
      .style12
      {
         height: 18px;
      }
      .style17
      {
         width: 1px;
      }
      .style18
      {
         width: 52px;
      }
      .style16
      {
         width: 124px;
      }
      .style19
      {
         width: 133px;
      }
      .style20
      {
         width: 195px;
      }
   </style>
</head>
<body dir="ltr">
   <form id="form1" runat="server">
   <div>
      <center>
         <table cellpadding="0" cellspacing="0" border="2" style="border-color: Black; width: 820px">
            <tr>
               <td align="left" style="border: 0; background-color: #808080;" dir="ltr" bgcolor="White"
                  class="style5">
                  <a href="http://leadtools.com/SDK/Raster/Raster-Internet.htm" style="background-color: #808080">
                     <img src="Resources/logo.png" alt="LEADTOOLS Product and Feature Information." border="0"
                        style="padding: 10px; height: 96px; width: 96px" />
                  </a>
               </td>
               <td align="left" style="border: 0; background-color: #808080;" dir="ltr" bgcolor="White"
                  class="style3">
                  <h1 style="background-position: center; background: #808080; font-family: Arial;
                     font-size: 22px; font-weight: bold; font-style: normal; position: static; padding-top: 10px;
                     padding-bottom: 10px; color: #FFFFFF;">
                     LEADTOOLS Multimedia JobProcessor Web Demo</h1>
               </td>
            </tr>
            <tr>
               <td style="background-color: #FFFFFF; padding-left: 5px; padding-top: 5px; height: auto;
                  bottom: auto;" class="style7" colspan="2" align="left" valign="top">
                  <asp:ScriptManager ID="ScriptManager1" runat="server" />

                  <script language="javascript" type="text/javascript">
                     // This Script is used to maintain Grid Scroll on Partial Postback
                     var scrollTop;
                     var scrollLeft;
                     //Register Begin Request and End Request 
                     Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
                     Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                     //Get The Div Scroll Position
                     function BeginRequestHandler(sender, args) {
                        var m = document.getElementById('divGridContainer');
                        scrollTop = m.scrollTop;
                        scrollLeft = m.scrollLeft;

                        // Change the Container div's CSS class to .Progress.
                        $get('spinnerContainer').className = 'Progress';
                     }
                     //Set The Div Scroll Position
                     function EndRequestHandler(sender, args) {
                        var m = document.getElementById('divGridContainer');
                        m.scrollTop = scrollTop;
                        m.scrollLeft = scrollLeft;

                        // Change the Container div's class back to .Normal.
                        $get('spinnerContainer').className = 'Normal';
                     }   
                  </script>

                  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                        <b>Source Image File Information:<br />
                        </b>
                        <br style="background-color: #808080" />
                        <table style="width: 100%;">
                           <tr>
                              <td class="style8">
                                 <asp:Label ID="Label1" runat="server" Text="Source File"></asp:Label>
                                 &nbsp;Name
                              </td>
                              <td class="style9">
                                 <asp:DropDownList ID="_cmbSourceFiles" runat="server" Width="100%">
                                 </asp:DropDownList>
                              </td>
                              <td>
                                 &nbsp;
                              </td>
                           </tr>
                           <tr>
                              <td class="style8">
                                 Conversion Profile
                              </td>
                              <td class="style9">
                                 <asp:DropDownList ID="_cmbConversionProfile" runat="server" Width="100%" Height="20px"
                                    AutoPostBack="True">
                                 </asp:DropDownList>
                              </td>
                              <td>
                                 &nbsp;
                              </td>
                           </tr>
                           <tr>
                              <td>
                                 &nbsp;
                              </td>
                              <td class="style8">
                                 The conversion profiles in this demo are 'settings' files saved using the .NET Multimedia
                                 Convert Demos. You can use the Convert Demo to modify these profiles, or create
                                 others.
                              </td>
                              <td>
                                 &nbsp;
                              </td>
                           </tr>
                           <tr>
                              <td class="style8">
                                 &nbsp;
                              </td>
                              <td class="style9">
                                 &nbsp;
                              </td>
                              <td>
                                 &nbsp;
                              </td>
                           </tr>
                           <tr>
                              <td class="style8">
                                 <asp:Button ID="_btnAddJob" runat="server" Text="Add Job" Width="107px" OnClick="_btnAddJob_Click" />
                              </td>
                              <td class="style9">
                                 &nbsp;
                              </td>
                              <td>
                                 &nbsp;
                              </td>
                           </tr>
                        </table>
                        <br />
                     </ContentTemplate>
                  </asp:UpdatePanel>
               </td>
            </tr>
            <tr>
               <td style="background-color: #FFFFFF; margin-left: 200px;" class="style11" colspan="2"
                  valign="top" align="left">
                  <b>
                     <br />
                     &nbsp;Client Jobs:<br />
                     <br />
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                           <asp:Timer ID="_timer" runat="server" Interval="5000" OnTick="_timer_Tick">
                           </asp:Timer>
                           <div id="divGridContainer" style="width: 100%; height: 100%; max-height: 500px; overflow: auto;">
                              <asp:GridView ID="_gridViewClientJobs" runat="server" Height="16px" Width="810px"
                                 Style="max-width: 99%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                 BorderWidth="1px" CellPadding="4" ForeColor="Black" RowStyle-HorizontalAlign="Center"
                                 OnPreRender="_gridViewClientJobs_PreRender" EmptyDataText="No records available"
                                 AutoGenerateColumns="False" AllowSorting="True" OnSorting="_gridViewClientJobs_Sorting">
                                 <RowStyle Height="16px" />
                                 <EmptyDataRowStyle Height="48px" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray"
                                    ForeColor="GrayText" Font-Italic="true" />
                                 <Columns>
                                    <asp:TemplateField>
                                       <HeaderTemplate>
                                          <b>
                                             <asp:CheckBox ID="_cbSelectAllRows" runat="server" OnCheckedChanged="_cbSelectAllRows_CheckedChanged"
                                                AutoPostBack="true" />
                                          </b>
                                       </HeaderTemplate>
                                       <ItemTemplate>
                                          <b>
                                             <asp:CheckBox ID="_cbSelectRow" runat="server" OnCheckedChanged="_cbSelectRow_CheckedChanged"
                                                AutoPostBack="True" />
                                          </b>
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true" HeaderText="Job ID">
                                       <ItemTemplate>
                                          <asp:Label ID="_lblJobID" runat="server" Text='<%# Eval("Job ID")%>' />
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Input File" HeaderText="Input File" SortExpression="Input File" />
                                    <asp:TemplateField HeaderText="Output File" SortExpression="Output File">
                                       <ItemTemplate>
                                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  Eval("Full Path") %>'
                                             Text='<%#  Eval("Output File") %>' Enabled='<%#  ((string)Eval("status")) == "Completed" %>'></asp:HyperLink>
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                       <ItemTemplate>
                                          <asp:Label ID="_lblStatus" runat="server" Text='<%#  Eval("Status") %>'></asp:Label>
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Worker" HeaderText="Worker" SortExpression="Worker" />
                                    <asp:BoundField DataField="Percentage" HeaderText="Percentage" SortExpression="Percentage" />
                                    <asp:BoundField DataField="Added Data/Time" HeaderText="Added Data/Time" SortExpression="Added Data/Time" />
                                    <asp:BoundField DataField="Completed Data/Time" HeaderText="Completed Data/Time"
                                       SortExpression="Completed Data/Time" />
                                    <asp:BoundField DataField="Error ID" HeaderText="Error ID" SortExpression="Error ID" />
                                    <asp:BoundField DataField="Error Message" HeaderText="Error Message" SortExpression="Error Message" />
                                    <asp:BoundField DataField="Target Format" HeaderText="Target Format" SortExpression="Target Format" />
                                 </Columns>
                                 <FooterStyle BackColor="#CCCC99" ForeColor="Black" Height="16px" />
                                 <PagerStyle BackColor="White" ForeColor="Black" Height="16px" HorizontalAlign="Right" />
                                 <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Height="16px" />
                                 <EditRowStyle Height="16px" />
                                 <AlternatingRowStyle Height="16px" />
                              </asp:GridView>
                           </div>
                        </ContentTemplate>
                     </asp:UpdatePanel>
                  </b>
               </td>
            </tr>
            <tr>
               <td style="background-color: #FFFFFF; margin-left: 200px;" class="style12" colspan="2"
                  valign="top" align="right">
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                     <ContentTemplate>
                        <br />
                        <b>
                           <table style="width: 100%;">
                              <tr>
                                 <td align="left" class="style17">
                                    &nbsp;
                                 </td>
                                 <td align="left" class="style18">
                                    <b>
                                       <asp:Button ID="_btnDeleteSelected" runat="server" Height="38px" OnClick="_btnDeleteSelected_Click"
                                          Text="Delete" Width="138px" />
                                    </b>
                                 </td>
                                 <td align="left" class="style16">
                                    <b>
                                       <asp:Button ID="_btnAbortSelected" runat="server" Height="38px" OnClick="_btnAbortSelected_Click"
                                          Text="Abort" Width="138px" />
                                    </b>
                                 </td>
                                 <td align="left" class="style19">
                                    <b>
                                       <asp:Button ID="_btnMarkAsNew" runat="server" Height="38px" OnClick="_btnMarkAsNew_Click"
                                          Text="Reset Job(s)" Width="138px" />
                                    </b>
                                 </td>
                                 <td>
                                    <b>
                                       <div id="spinnerContainer" style="height: 19px">
                                       </div>
                                    </b>
                                 </td>
                                 <td align="right" class="style20">
                                    <asp:Label ID="_lblJobsCount" runat="server" Font-Bold="True" Text="Total Jobs: 0"></asp:Label>
                                 </td>
                              </tr>
                              <tr>
                                 <td align="left" class="style17">
                                    &nbsp;
                                 </td>
                                 <td align="left" class="style18">
                                    &nbsp;
                                 </td>
                                 <td align="left" class="style16">
                                    &nbsp;
                                 </td>
                                 <td align="left" class="style19">
                                    &nbsp;
                                 </td>
                                 <td align="right" class="style20">
                                    &nbsp;
                                 </td>
                              </tr>
                           </table>
                        </b>
                     </ContentTemplate>
                  </asp:UpdatePanel>
                  <asp:HiddenField ID="_hiddenFieldClientMetadata" runat="server" />
               </td>
            </tr>
         </table>
      </center>
   </div>
   </form>
</body>
</html>
