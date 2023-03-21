using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            UsuarioTextBox.Focus();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un usuario");
                return;
            }
            errorProvider1.Clear();
            if (ContraseñaTextBox.Text == "")
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese una contraseña");
                return;
            }
            errorProvider1.Clear();

            //Validar en la base de datos
            Login login = new Login(UsuarioTextBox.Text, ContraseñaTextBox.Text);

            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = new Usuario();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {

                if (usuario.EstaActivo)
                {
                    //Mandarlo al menu

                    Menu menuFormulario = new Menu();
                    this.Hide();
                    menuFormulario.Show();

                }
                else
                {
                    MessageBox.Show("Error", "el usuario esta inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                //Menu menuFormulario = new Menu();
                //this.Hide();
                //menuFormulario.Show();
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ContraseñaTextBox.PasswordChar == '*')
            {
                ContraseñaTextBox.PasswordChar = '\0';
            }
            else
            {
                ContraseñaTextBox.PasswordChar = '*';
            }
        }
    }
}
