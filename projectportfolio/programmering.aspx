<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="programmering.aspx.cs" Inherits="projectportfolio.programmering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="toppadding">
        <div class="srcbx">
            <div id="srcbar">
                <asp:TextBox ID="txtPortSrc" ClientIDMode="Static" runat="server"></asp:TextBox>
                <asp:ImageButton ID="lnkSrc" ImageUrl="../graphic/icons/src-loop-blck.svg" OnClick="btnSrc_Click" runat="server" />
            </div>

            <div id="srctags">
                <p>Søg via: </p>
                <asp:RadioButtonList ID="chkFilter" runat="server"></asp:RadioButtonList>
            </div>
        </div>
        <asp:Literal ID="litSQL" runat="server"></asp:Literal>
        <div id="pageNm">
            <asp:Literal ID="sidenav" runat="server"></asp:Literal>
        </div>
    </section>
</asp:Content>
