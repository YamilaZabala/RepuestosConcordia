using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmVenta : Form
    {

        private bool IsNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;

        private decimal totalPagado = 0;

        private static frmVenta _instancia;

        public static frmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }


        public frmVenta()
        {
            InitializeComponent();
        }

        public void setCliente(string idcliente, string nombre, string cuit,  string condicionIva, string domicilio)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtNombreCliente.Text = nombre;
            this.txtCuitCliente.Text = cuit;
            this.txtCondicionCliente.Text = condicionIva;
            this.txtDomicilioCliente.Text = domicilio;
            
        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
           
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
        }

        
        /*private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdventa.Text);

        }*/

        // creamos la tabla dtDetalle

        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_Venta", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("impuesto", System.Type.GetType("System.Int32"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void setArticulo(string idarticulo, string nombre, string precio, string stock)
        {
            this.txtIdArticulo.Text = idarticulo;
            this.txtArticulo.Text = nombre;
            this.txtPrecioVenta.Text = precio;
            this.txtStock.Text = stock;
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo vista = new frmVistaArticulo();
            vista.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdArticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty
                    || this.txtDescuento.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_Venta"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_Venta"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["impuesto"] = Convert.ToInt32(this.cbporIVA.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay Stock Suficiente");
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.crearTabla();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente vista = new frmVistaCliente();
            vista.ShowDialog();
        }
    }
}
