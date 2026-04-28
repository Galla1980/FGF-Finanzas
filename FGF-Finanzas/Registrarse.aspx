<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="FGF_Finanzas.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Cree una cuenta nueva.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DniUsuario" CssClass="col-md-2 control-label">DNI</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="DniUsuario" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DniUsuario" 
                    CssClass="text-danger" ErrorMessage="El campo de DNI es obligatorio."/>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="DniUsuario"
                    CssClass="text-danger" ValidationExpression="^\d{8}$" ErrorMessage="El DNI deben ser 8 (ocho) dígitos." />
            </div>
        </div>
                 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nombre" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre" 
                    CssClass="text-danger" ErrorMessage="El campo de Nombre es obligatorio."/>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Nombre"
                    CssClass="text-danger" ValidationExpression="^[A-ZÁÉÍÓÚ]{1}[a-záéíóú]{2,} [A-ZÁÉÍÓÚ]{1}[a-záéíóú]{2,}$" ErrorMessage="Ingrese su nombre." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Apellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Apellido" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Apellido" 
                    CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio."/>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Apellido"
                    CssClass="text-danger" ValidationExpression="^[A-ZÁÉÍÓÚ]{1}[a-záéíóú]{2,} [A-ZÁÉÍÓÚ]{1}[a-záéíóú]{2,}$" ErrorMessage="Ingrese su apellido." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Nombre de usuario</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="El campo de nombre de usuario es obligatorio." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />

                <!--ControlToCompare="Password" ControlToValidate="ConfirmPassword" compara ambos textbox "CompareValidator"-->
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />

                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblError" CssClass="text-danger"/>
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
