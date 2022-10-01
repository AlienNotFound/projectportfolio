<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="projectportfolio.post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="showContent" class="toppadding">
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
    </div>
</asp:Content>
