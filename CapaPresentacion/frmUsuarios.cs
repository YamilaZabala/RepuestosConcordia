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
    public partial class frmUsuarios : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmUsuarios()
        {
            InitializeComponent();
            this.txtIdusuario.ReadOnly = true;
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
            this.txtIdusuario.Text = string.Empty;
            this.txtUsuarios.Text = string.Empty;
            this.txtClave.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.txtCuit.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUsuarios.ReadOnly = !valor;
            this.txtClave.ReadOnly = !valor;
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
            this.dataListado.Columns[12].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NUsuario.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            this.SetDataGridView();
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NUsuario.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NUsuario.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarCuit
        private void BuscarCuit()
        {
            this.dataListado.DataSource = NUsuario.BuscarCuit(this.txtBuscar.Text);
           // this.OcultarColumnas();
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
            errorIcono.SetError(txtTelefono, String.Empty);
            errorIcono.SetError(txtEmail, String.Empty);
            errorIcono.SetError(cbAcceso, String.Empty);
            errorIcono.SetError(txtUsuarios, String.Empty);
            errorIcono.SetError(txtClave, String.Empty);
        }

        //Método cambiar titulos de columna en datagridview

        private void SetDataGridView()
        {
            
            dataListado.Columns[1].HeaderText = "Codigo";
            dataListado.Columns[2].HeaderText = "Nombre";
            dataListado.Columns[3].HeaderText = "Apellido";
            dataListado.Columns[4].HeaderText = "Sexo";
            dataListado.Columns[5].HeaderText = "Fecha Nac.";
            dataListado.Columns[6].HeaderText = "DNI";
            dataListado.Columns[7].HeaderText = "Direccion";
            dataListado.Columns[8].HeaderText = "Teléfono";
            dataListado.Columns[9].HeaderText = "E-Mail";
            dataListado.Columns[10].HeaderText = "Acceso";
            dataListado.Columns[11].HeaderText = "Usuario";


        }

        private void frmUsuarios_Load(object sender, EventArgs e)
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
                            Rpta = NUsuario.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdusuario.Text.Equals(""))
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
            this.txtIdusuario.Text = string.Empty;

            this.BorrarErrorProvider();
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
                if (this.txtNombre.Text == string.Empty || this.txtCuit.Text == string.Empty || this.cbSexo.Text == string.Empty || this.cbAcceso.Text == string.Empty)
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
                   
                    errorIcono.SetError(txtIdusuario, String.Empty);


                }
                else
                {


                    if (this.IsNuevo)
                    {
                        rpta = NUsuario.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, dtFechaNac.Value,
                            txtCuit.Text, txtDireccion.Text.ToUpper(), txtTelefono.Text,
                            txtEmail.Text, cbAcceso.Text, txtUsuarios.Text.ToUpper(), txtClave.Text);

                        this.BorrarErrorProvider();

                    }
                    else
                    {
                        rpta = NUsuario.Editar(Convert.ToInt32(this.txtIdusuario.Text),
                           this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, dtFechaNac.Value,
                            txtCuit.Text, txtDireccion.Text.ToUpper(), txtTelefono.Text,
                            txtEmail.Text, cbAcceso.Text, txtUsuarios.Text.ToUpper(), txtClave.Text);

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
            if (dataListado.CurrentRow != null) {
                    this.BorrarErrorProvider();
                    this.txtIdusuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idusuario"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
                    this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
                    this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechaNac"].Value);
                    this.txtCuit.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cuit"].Value);
                    this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
                    this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
                    this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
                    this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
                    this.txtUsuarios.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
                    this.txtClave.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

                    this.tabControl1.SelectedIndex = 1;
                }
            else

            {
                this.MensajeError("Seleccione un Registro");

            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }


}
