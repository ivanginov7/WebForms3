<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebForms3.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="SuccessMessage" Visible="false">
                    <p class="text-success">
                        <asp:Literal runat="server" ID="SucessText" />
                    </p>
                </asp:PlaceHolder>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EmailControl" CssClass="col-md-2 control-label">Your Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="EmailControl" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailControl" CssClass="text-danger" ErrorMessage="The email field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="MessageControl" CssClass="col-md-2 control-label">Your Message</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="MessageControl" CssClass="form-control" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="MessageControl" CssClass="text-danger" ErrorMessage="The message field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10 col-md-offset-2">
                        <asp:Button runat="server" Text="Send Message" ID="ContactButton" CssClass="btn btn-default" OnClick="SendMessageButton_Click"/>
                    </div>
                </div>
            </section>
        </div>
     </div>
</asp:Content>
