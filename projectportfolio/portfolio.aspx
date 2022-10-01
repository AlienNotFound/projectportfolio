<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="portfolio.aspx.cs" Inherits="projectportfolio.portfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="toppadding">
        <asp:Panel ID="portPgsBx" ClientIDMode="Static" runat="server">
            <asp:Literal ID="litSQL" runat="server"></asp:Literal>
        </asp:Panel>
    </section>
</asp:Content>
