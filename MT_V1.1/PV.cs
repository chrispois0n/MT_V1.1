using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using miLibreria;


namespace MT_V1._1
{
    public partial class PV : Form
    {
        public PV()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelPed.Hide();
            panelME.Hide();
            panelPLL.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelPed.Hide();
            panelPLL.Hide();
            panelME.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            CobrarPedido abrir = new CobrarPedido();
            abrir.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Salir abrir = new _1.Salir();
            abrir.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panelPed.Show();
            panelPLL.Hide();
            panelME.Hide();
          
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Cobrar abrir = new _1.Cobrar();
            abrir.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Cobrar abrir = new _1.Cobrar();
            abrir.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ArtCom abrir = new ArtCom();
            abrir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelProductos.Hide();
            panelVentas.Hide();
            panelInventarios.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelInventarios.Hide();
            panelVentas.Hide();
            panelProductos.Show();
        }

        private void PV_Load(object sender, EventArgs e)
        {

            string cmd = "select * from usuarios where id_usuario =" + LogIn.codigo;

            DataSet ds = Utilidades.Ejecutar(cmd);

            lblUturno.Text = ds.Tables[0].Rows[0]["account"].ToString().Trim();       

            lblDT.Text = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm:ss tt");
            //pone la hora y fecha actual en el formato dado

            panelVentas.Show();

            if (LogIn.permisos == true)
            {
                btnConfiguracion.Enabled = true;
                btnInventarios.Enabled = true;
                btnProductos.Enabled = true;
                btnReportes.Enabled = true;
            }else
            {

            }
        }
    }
}
