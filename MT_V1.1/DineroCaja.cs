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
    public partial class DineroCaja : Form
    {
        public DineroCaja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PV abrir = new _1.PV();
            abrir.Show();
            //PROBABLEMENTE UN DELAY
            this.Hide();
            //COMO CERRARLO 
        }

        private void DineroCaja_Load(object sender, EventArgs e)
        {
            string cmd = "select * from usuarios where id_usuario =" + LogIn.codigo;

            DataSet ds = Utilidades.Ejecutar(cmd);

            lblAccount.Text = ds.Tables[0].Rows[0]["account"].ToString().Trim();
            lblNombre.Text = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
            lblId.Text = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

            string ITurno = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm:ss tt");
            lblInicioTurno.Text = ITurno;
        }
    }
}
