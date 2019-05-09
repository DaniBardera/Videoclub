using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Videoclub
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();

            String texto1 = textBox1.Text;
            String texto2 = textBox2.Text;

            MySqlCommand comando = new MySqlCommand("" +
                "SELECT * FROM usuarios WHERE" +
                " usuario = '" + texto1 +
                "' AND pass = '" + texto2 +
                "' ;", conexion);

            if (texto1.Contains("'") || texto2.Contains("'"))
            {
                MessageBox.Show("Accceso Denegado", "USUARIO O CONTRASEÑA ERRONEOS");
            }
            else
            {
                MySqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    // ocultamos la ventana en la que estamos
                    this.Visible = false;

                    // creamos una nueva ventana del tipo VentanaPrincipal
                    VentanaInicio ventana = new VentanaInicio();
                    ventana.Visible = true;

                    MessageBox.Show("Acceso Correcto", "USUARIO OK");
                    this.Visible = false; //Oculta la ventana de login
                }

                else
                {
                    MessageBox.Show("Accceso Denegado", "USUARIO O CONTRASEÑA ERRONEOS");
                }
            }
        }
    }

}