<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formato.aspx.cs" Inherits="facturero.formato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 610px">
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderStyle="Groove" Text="Sistema de facturacion - cargar informacion clientes"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Numero de factura:  "></asp:Label>
            <asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
            fecha de venta:&nbsp;
            <asp:TextBox ID="txtFechaFactura" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Observacion:  "></asp:Label>
            <asp:TextBox ID="txtObservacion" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Seleccionar cliente:  "></asp:Label>
            <asp:DropDownList ID="listCliente" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="empresa" DataValueField="nit" OnSelectedIndexChanged="listCliente_SelectedIndexChanged1">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bdComercialConnectionString %>" SelectCommand="SELECT * FROM [clientes]"></asp:SqlDataSource>
            <asp:Label ID="Label5" runat="server" Text="nit:  "></asp:Label>
            <asp:TextBox ID="txtNit" runat="server" style="z-index: 1; left: 251px; top: 112px; position: absolute; width: 220px; height: 18px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Direccion:  "></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Telefono:  "></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Ciudad:  "></asp:Label>
            <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Seleccionar producto:  "></asp:Label>
            <asp:DropDownList ID="listProducto" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="nombre" DataValueField="codigo" OnSelectedIndexChanged="listProducto_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bdComercialConnectionString %>" SelectCommand="SELECT * FROM [productos]"></asp:SqlDataSource>
            <asp:Label ID="Label10" runat="server" Text="Valor unitario:  "></asp:Label>
            <asp:TextBox ID="txtValor" runat="server" Width="73px"></asp:TextBox>
            <asp:Label ID="Label11" runat="server" Text="Cantidad a comprar:  "></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server" Width="76px"></asp:TextBox>
            <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
            <br />
            <br />
            <asp:GridView ID="grdDetalle" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnGuardar" runat="server" BorderStyle="None" OnClick="btnGuardar_Click" Text="Guardar" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
