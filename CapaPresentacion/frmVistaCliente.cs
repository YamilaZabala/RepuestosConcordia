using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaCliente : Form
    {
        public frmVistaCliente()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarCuit
        private void BuscarCuit()
        {
            this.dataListado.DataSource = NCliente.BuscarCuit(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
                if (cbBuscar.Text.Equals("Apellido"))
                {
                    this.BuscarApellidos();
                }
                else if (cbBuscar.Text.Equals("Nombre"))
                {
                    this.BuscarNombre();
                }
                else if (cbBuscar.Text.Equals("Cuit"))
                {
                    this.BuscarCuit();
                }
            
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2, par3, par4, par5;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value) + " " +
                Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["cuit"].Value);
            par4 = Convert.ToString(this.dataListado.CurrentRow.Cells["condicionIVA"].Value);
            par5 = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            form.setCliente(par1, par2, par3, par4, par5);
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmVistaCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
