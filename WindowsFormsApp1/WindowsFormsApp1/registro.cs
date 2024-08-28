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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 cancelar = new Form1();
            cancelar.Show();
            this.Hide();
        }

        private void registro_Load(object sender, EventArgs e)
        {
            

        }
        
        private void textnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 guardar = new Form1();
            guardar.Show();
            this.Hide();

            try
            {
                SqlConnection Conexion = new SqlConnection("Server=DESKTOP-OFGPMFR; Database=Cajero ; Integrated security=True");
                SqlCommand Realiza = new SqlCommand();
                Realiza.Connection = Conexion;
                Realiza.CommandText = "insert into registrarse (nombre,apellido,edad,tipo_documento,documento,clave) values(@nombre,@apellido,@edad,@tipo_documento,@documento,@clave)";
                Realiza.CommandType = System.Data.CommandType.Text;
                Realiza.Parameters.AddWithValue("@nombre", txtname.Text);
                Realiza.Parameters.AddWithValue("@apellido", txtFirstName.Text);
                Realiza.Parameters.AddWithValue("@edad", txtEdad.Text);
                Realiza.Parameters.AddWithValue("@tipo_documento", txtTipoDocumento.Text);
                Realiza.Parameters.AddWithValue("@documento", txtDocumento.Text);
                Realiza.Parameters.AddWithValue("@clave", textnumero.Text);
                Conexion.Open();
                Realiza.ExecuteNonQuery();
                string cadena = "select top 1 * from registrarse order by numero_cuenta desc ";
                SqlCommand comando = new SqlCommand(cadena, Conexion);
                SqlDataReader registros = comando.ExecuteReader();
                if (registros.Read())
                {

                    string numeroDeCuenta = registros["numero_cuenta"].ToString();
                    MessageBox.Show($"Su número de cuenta es {numeroDeCuenta}", "Número de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                return;
            }
        }
    }
}   
