<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MultimediaJobProcessorClientDemo.Default" %>
   
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
   <meta name="robots" content="index, follow" />
   <title>Default Page</title>
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
      .style6
      {
         height: 177px;
      }
      .style7
      {
         direction: ltr;
      }
      .style8
      {
         height: 134px;
      }
      .style1
      {
         height: 35px;
      }
      .style9
      {
         width: 6px;
      }
      .style10
      {
         height: 35px;
         width: 6px;
      }
      .style11
      {
         height: 32px;
      }
      .style12
      {
         width: 6px;
         height: 32px;
      }
   </style>

   <script language="javascript" type="text/javascript">
      function doHourglass() {
         document.body.style.cursor = 'wait';
      }
   </script>

</head>
<body dir="ltr" onbeforeunload="doHourglass();" onunload="doHourglass();">
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
               <td style="background-color: #FFFFFF" class="style8" colspan="2" align="left">
                  <table cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                     <tr>
                        <td>
                           <asp:ScriptManager ID="ScriptManager1" runat="server">
                           </asp:ScriptManager>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>
                                 <table border="0" cellpadding="0" style="background-color: #CCCCCC">
                                    <tr>
                                       <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">
                                          Client Metadata
                                       </td>
                                       <td align="center" style="color: White; background-color: #6B696B; font-weight: bold;"
                                          class="style9">
                                          &nbsp;
                                       </td>
                                    </tr>
                                    <tr>
                                       <td align="left" class="style1">
                                          &nbsp;
                                          <asp:Label ID="_lblUserName" runat="server">User Name:</asp:Label>
                                       </td>
                                       <td class="style1">
                                          <asp:TextBox ID="_tbUserName" runat="server" MaxLength="50"></asp:TextBox>
                                       </td>
                                       <td class="style10">
                                          &nbsp;
                                       </td>
                                    </tr>
                                    <tr>
                                       <td align="right" colspan="2" class="style11">
                                          <asp:Button ID="_btnEnter" runat="server" Text="Enter" PostBackUrl="~/MultimediaJobProcessorClientPage.aspx"
                                             Style="margin-left: 0px" Width="55px" />
                                       </td>
                                       <td align="right" class="style12">
                                       </td>
                                    </tr>
                                 </table>
                              </ContentTemplate>
                           </asp:UpdatePanel>
                        </td>
                     </tr>
                  </table>
               </td>
            </tr>
            <tr>
               <td style="background-color: #FFFFFF" class="style6" colspan="2">
                  <div style="text-align: left">
                     <p>
                        This demo uses LEADTOOLS WCF Job Processor service. By default this demo will look
                        for the WCF service on the localhost. If you have hosted the service somewhere else,
                        or have updated the alias name in the host application, you need to update the URL
                        in the "Web.Config" (see below):</p>
                     <pre style="text-align: left; background-color: #CCCCCC;" class="style7">
&lt;MultimediaJobProcessorClientDemo.Properties.Settings&gt;
   &lt;setting name="CSMultimediaJobProcessorClientDemo_JobService_JobService" serializeAs="String"&gt;
      &lt;value&gt;http://localhost/LEADTOOLSJobProcessorServices/JobService.svc&lt;/value&gt;
   &lt;/setting&gt;
&lt;/MultimediaJobProcessorClientDemo.Properties.Settings&gt;
                        </pre>
                  </div>
               </td>
            </tr>
         </table>
      </center>
   </div>
   </form>
</body>
</html>
