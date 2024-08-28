using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 cancelar = new Form1();
            cancelar.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection("Server=DESKTOP-OFGPMFR; Database=Cajero ; Integrated security=True");
            Conexion.Open();
            SqlCommand Realiza = new SqlCommand();
            Realiza.Connection = Conexion;
            int numeroc = int.Parse(NumeroCuenta.Text);
            int pin = int.Parse(PinUser.Text);
            string cadena = "select * from registrarse where numero_cuenta = '"+numeroc+"'";
            SqlCommand comando = new SqlCommand(cadena, Conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if (registros.Read())
            {
                if (int.Parse(registros["numero_cuenta"].ToString()) == numeroc && int.Parse(registros["clave"].ToString()) == pin)
                {
                    MessageBox.Show("Se ingreso correctamente");
                }
            }
            else
            {
                MessageBox.Show("Numero de cuenta o contraseña incorrecto");
            }
        }
    }
}
