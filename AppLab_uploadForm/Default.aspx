<%@ Page Title="BLABLA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppLab_uploadForm.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div style="height: 100%">
        <p>Default page</p>
        <form id="file_upload_form" runat="server">
            <asp:FileUpload id="file_upload_control" runat="server" />
            <asp:Button runat="server" id="upload_button" text="Upload" onclick="upload_button_click" />
            <br /><br />
            <asp:Label runat="server" id="upload_status_label" text="Upload status: " />
            

        <div>
            <asp:Label ID="Label1" runat="server" Text="Label">Details:</asp:Label>
            <asp:Table ID="file_upload_details_table" runat="server" BorderWidth="1" GridLines="both"/>
        </div>
            

        </form>
        
    </div>
</asp:Content>


