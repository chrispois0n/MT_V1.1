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
using System.Data.SqlClient;
using miLibreria;
using System.Data; 


namespace MT_V1._1
{
    public partial class LogIn : Form
    {
        public static string Ustr = " ";
        public static bool permisos = false;
        public static string codigo = " ";
        //esta variable nos sirve para almacenar el usuario que se loggeo
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try {
                string CMD = string.Format("select * from usuarios where account = '" + txtU.Text + "' and password = '" + txtP.Text + "' ");
                //EL .TRIM() SIRVE PARA EVITAR ESPACIOS

                DataSet ds = Utilidades.Ejecutar(CMD);

                codigo = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string password = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                if (cuenta == txtU.Text.Trim() && password== txtP.Text.Trim())
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["status_admin"]) == true)
                    {
                        permisos = true;
                    }
                    else
                    {
                        permisos = false;
                    }
                    //esta condicional la usare mas tarde para brindar accesos al usuario ingresado


                    MessageBox.Show("Sesion iniciada");
                    DineroCaja abrir = new DineroCaja();
                    abrir.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }

                    //esto lo hace una matriz
            }catch(Exception error)
            {
                MessageBox.Show("" + error.Message);
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
            /*
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=prueba; UId=root; pwd=Hyper130; SslMode = none "); //tambien puede funcionar con
            //server =localhost
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("select * from usuario where nombre ='"+ txtU.Text +"' and password = '"+ txtP.Text +"' ");

            Ustr = txtU.ToString().Trim();
            MySqlDataReader leer = codigo.ExecuteReader();
            if(leer.Read())
            {
             
                MessageBox.Show("Bienvenido");
                DineroCaja abrir = new DineroCaja();
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto");
            }
            conectar.Close();

           */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

           // Utilidades.Ejecutar("Select * from clientes where id = 1");

         /*   try
            {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6DH3H6C\\SQLSERVER;Initial Catalog=MT;Integrated Security=True");
            con.Open();

               // MessageBox.Show("Conectado");
            }
            catch(Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error.Message );
                MessageBox.Show("Porfavor contacte con el administrador del sistema o llame al 6182003575");
            }
             
    */
        }
    }
}
