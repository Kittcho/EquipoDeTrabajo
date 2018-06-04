using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Guarderia.Acceso
{
    public partial class Acceso_usuario : Form
    {
        public Acceso_usuario()
        {
            InitializeComponent();
        }

        public bool bAcceso;
        private void btn_Acceso_Click(object sender, EventArgs e)
        {
            bAcceso = false;
            String sUsuario = txt_usuario.Text;
            String sPass = txt_password.Text;

            if (sUsuario == "")
            {
                MessageBox.Show("Por favor introduzca su usuario", "Acceso Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_usuario.Focus();
            }
            else if (sPass == "")
            {
                MessageBox.Show("Por favor introduzca su contraseña", "Acceso Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_password.Focus();
            }
            else
            {
                if (sUsuario == "admin" && sPass == "123")
                {
                    bAcceso = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, favor de verificar", "Acceso Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Acceso_usuario_Load(object sender, EventArgs e)
        {
            bAcceso = false;
        }
    }
}
