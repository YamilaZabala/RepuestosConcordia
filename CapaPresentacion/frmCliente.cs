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
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmCliente()
        {
            InitializeComponent();
            this.txtIdcliente.ReadOnly = true;
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese los Apellidos del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del Cliente");
            this.ttMensaje.SetToolTip(this.txtCuit, "Ingrese el número de Cuit del Cliente");
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtCuit.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbIVA.Enabled = valor;
            this.cbSexo.Enabled = valor;
            this.txtCuit.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

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
            this.SetDataGridView();
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

         // Método Borrar mensaje de error
        private void BorrarErrorProvider()
        {
            errorIcono.SetError(txtNombre, String.Empty);
            errorIcono.SetError(txtApellidos, String.Empty);
            errorIcono.SetError(txtCuit, String.Empty);
            errorIcono.SetError(txtDireccion, String.Empty);
            errorIcono.SetError(cbSexo, String.Empty);
            errorIcono.SetError(cbIVA, String.Empty);
            errorIcono.SetError(txtTelefono, String.Empty);
            errorIcono.SetError(txtEmail, String.Empty);
        }

        //Método cambiar titulos de columna en datagridview

            private void SetDataGridView()
        {
            dataListado.Columns[0].HeaderText = "Eliminar";
            dataListado.Columns[1].HeaderText = "Codigo";
            dataListado.Columns[2].HeaderText = "Nombre/Razon Social";
            dataListado.Columns[3].HeaderText = "Apellido";
            dataListado.Columns[4].HeaderText = "Sexo";
            dataListado.Columns[5].HeaderText = "Fecha Nac.";
            dataListado.Columns[6].HeaderText = "CUIT";
            dataListado.Columns[7].HeaderText = "Direccion";
            dataListado.Columns[8].HeaderText = "Teléfono";
            dataListado.Columns[9].HeaderText = "E-Mail";
            dataListado.Columns[10].HeaderText = "IVA";



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             this.BorrarErrorProvider();
             try
              {
                  string rpta = "";
                   
                    //verificamos que no haya texbox o comboBox vacios
                   if (this.txtNombre.Text == string.Empty || this.txtCuit.Text == string.Empty  || this.cbSexo.Text == string.Empty || this.cbIVA.Text == string.Empty)
                   {
                       MensajeError("Falta ingresar algunos datos, serán remarcados");

                    //recorremos los comboBox verificando cuales estan vacios
                    foreach (Control c in groupBox1.Controls.OfType<ComboBox>())
                    {
                        if (c is ComboBox & c.Text.Trim() == "")
                        {
                            errorIcono.SetError(c, "Ingrese un Valor");
                        }
                    }

                    //recorremos los texbox verificando cuales estan vacios
                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c is TextBox & c.Text.Trim() == "")
                        {
                            errorIcono.SetError(c, "Ingrese un Valor");
                        }
                    }
                    errorIcono.SetError(txtApellidos, String.Empty);
                    errorIcono.SetError(txtIdcliente, String.Empty);


                }
                   else
                   { 


                  if (this.IsNuevo)
                      {
                          rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                              this.txtApellidos.Text.Trim().ToUpper(),
                              this.cbSexo.Text, dtFechaNac.Value,
                              txtCuit.Text, txtDireccion.Text.ToUpper(), txtTelefono.Text,
                              txtEmail.Text.ToUpper(), cbIVA.Text);

                          this.BorrarErrorProvider();

                      }
                      else
                      {
                          rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text),
                              this.txtNombre.Text.Trim().ToUpper(),
                              this.txtApellidos.Text.Trim().ToUpper(),
                              this.cbSexo.Text, dtFechaNac.Value,
                              txtCuit.Text, txtDireccion.Text.ToUpper(), txtTelefono.Text,
                              txtEmail.Text.ToUpper(), cbIVA.Text);

                          this.BorrarErrorProvider();
                      }

                      if (rpta.Equals("OK"))
                      {
                          if (this.IsNuevo)
                          {
                              this.MensajeOk("Se Insertó de forma correcta el registro");
                          }
                          else
                          {
                              this.MensajeOk("Se Actualizó de forma correcta el registro");
                          }
                      }
                      else
                      {
                          this.MensajeError(rpta);
                      }

                      this.IsNuevo = false;
                      this.IsEditar = false;
                      this.Botones();
                      this.Limpiar();
                      this.Mostrar();

                 }

                 } 
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message + ex.StackTrace);
              }

        } 
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtIdcliente.Text = string.Empty;

            this.BorrarErrorProvider();

        }


        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

      

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                this.BorrarErrorProvider();
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechaNac"].Value);
            this.txtCuit.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cuit"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.cbIVA.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["condicionIVA"].Value);

            this.tabControl1.SelectedIndex = 1;

            }
            else

            {
                this.MensajeError("Seleccione un Registro");

            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
