<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projectportfolio.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function biggerHeader() {
            document.getElementsByTagName("header")[0].style.background = "none";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="hero">
        <!-- Slideshow container -->
        <div class="slideshow-container">
            <div id="slideshowimg">
                <!-- Full-width images -->
                <asp:Literal ID="litSlideshow" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
        <div id="container-hero">
            <h1>Adam Dreiøe</h1>
            <h3>Illustration • Programmering • Kreativitet</h3>
        </div>
    <section>
        <div id="abtsctn">
            <asp:Literal ID="litSQL" runat="server"></asp:Literal>
        </div>

    </section>
    <script src="../scripts/slideshow.js"></script>
</asp:Content>
