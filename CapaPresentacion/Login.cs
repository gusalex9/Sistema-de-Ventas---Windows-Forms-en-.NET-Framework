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
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CNUsuario().Listar();
            //Llamar al metodo listar desde la capa de negocio.
            Usuario oUsuario = new CNUsuario().Listar().Where(u => u.Documento == txtNumeroDocumento.Text && u.Clave == txtContrasena.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                Inicio form = new Inicio();
                form.Show();
                //Ocultar el formulario de Login
                this.Hide();

                //Al formulario de Inicio vamos atribuirle el evento closing
                form.FormClosing += frm_Closing;
            }
            else
            {
                MessageBox.Show("Error, verifique que el usuario y contrasena esten bien escrito","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            //Limpiar los txtBox del formulario Login
            txtNumeroDocumento.Text = "";
            txtContrasena.Text = "";
            this.Show();
        }

        
    }
}
