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
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {

        }

        private void txtIdingreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            // Create an unbound DataGridView by declaring a column count.
            dataListado.ColumnCount = 4;
            dataListado.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dataListado.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataListado.Columns[0].Name = "Codigo";
            dataListado.Columns[1].Name = "Fecha";
            dataListado.Columns[2].Name = "Proveedor";
         

          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtFecha2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
