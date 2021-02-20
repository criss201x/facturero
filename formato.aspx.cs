using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



namespace facturero
{
    public partial class formato : System.Web.UI.Page
    {
        public SqlCommand comando;
        public SqlConnection conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\migracion disco\\escritorio\\2020 - 3\\PROGRAMACION WEB\\bdComercial.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void listCliente_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                txtNit.Text = listCliente.SelectedValue;
                String consulta = "SELECT * FROM clientes WHERE nit=" + txtNit.Text;
                comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    txtDireccion.Text = (leer.GetString(2));
                    txtTelefono.Text = (leer.GetString(3));
                    txtCiudad.Text = (leer.GetString(4));
                }
            }
            catch (Exception ex) { }
        }

        public DataTable rellenartabla()
        {
            var dt = new DataTable();
            dt.Columns.Add("Codigo", Type.GetType("System.String"));
            dt.Columns.Add("Producto", Type.GetType("System.String"));
            dt.Columns.Add("Valor unitario", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad", Type.GetType("System.String"));
            dt.Columns.Add("Valor Total", Type.GetType("System.String"));
            return dt;
        }

        protected void listProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var codigoproducto = listProducto.SelectedValue;
                String consulta = "SELECT * FROM productos WHERE codigo=" + codigoproducto;
                comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    txtValor.Text = leer.GetSqlDecimal(3).ToString();
                }
            }
            catch(Exception ex) { }

        }
        public void limpiar()
        {
            txtFactura.Text = "";
            txtObservacion.Text = "";
            txtNit.Text = "";
            txtCiudad.Text = "";
            txtDireccion.Text = "";
            txtCantidad.Text = "";
            txtTelefono.Text = "";
            txtValor.Text = "";
            Session.Abandon();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["dt"] == null)
            {
                DataTable dt = rellenartabla();
                DataRow fila;
                fila = dt.NewRow();
                fila["Codigo"] = listProducto.SelectedValue.ToString();
                fila["Producto"] = listProducto.SelectedItem;
                fila["Valor unitario"] = txtValor.Text;
                fila["Cantidad"] = txtCantidad.Text;
                fila["Valor Total"] = int.Parse(txtCantidad.Text) * int.Parse(txtValor.Text);
                dt.Rows.Add(fila);
                grdDetalle.DataSource = dt;
                grdDetalle.DataBind();

                Session["dt"] = dt;
            }
            else
            {
                DataTable dt = (DataTable)(Session["dt"]);
                DataRow fila;
                fila = dt.NewRow();
                fila["Codigo"] = listProducto.SelectedValue.ToString();
                fila["Producto"] = listProducto.SelectedItem;
                fila["Valor unitario"] = txtValor.Text;
                fila["Cantidad"] = txtCantidad.Text;
                fila["Valor Total"] = int.Parse(txtCantidad.Text) * int.Parse(txtValor.Text);
                dt.Rows.Add(fila);
                grdDetalle.DataSource = dt;
                grdDetalle.DataBind();
                Session["dt"] = dt;
            }
        }
//no funciona 
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String insertarpedido = "Insert into pedidos values(" + txtnrofactura.Text + "," + txtnit.Text + ",'" + txtfecha.Text + "','" + txtobservacion.Text + "')";

            String insertarventa = "Insert into ventas values(@nropedido, @codigo, @cantidadvendida)";

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandText = insertarpedido;

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                foreach (GridViewRow fila in grdDetalle.Rows)
                {
                    SqlCommand insertarv = new SqlCommand(insertarventa, conexion);
                    insertarv.Parameters.Clear();
                    insertarv.Parameters.Add("@nropedido", SqlDbType.Int).Value =

                    int.Parse(txtFactura.Text);

                    insertarv.Parameters.Add("@codigo", SqlDbType.Int).Value =

                    int.Parse(fila.Cells[0].Text);
                    insertarv.Parameters.Add("@cantidadvendida", SqlDbType.Int).Value =
                    int.Parse(fila.Cells[3].Text);

                    insertarv.ExecuteNonQuery();
                }
                Response.Write("<script language='JavaScript'>alert('Registro guardado...!!!');</script>");                
                limpiar();
            }
            catch (SqlException ex) { }
            catch (Exception ex) { }
            finally
            {
                conexion.Close();
            }
        }
    }
}