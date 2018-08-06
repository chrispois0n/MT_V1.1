using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_V1._1
{
    public partial class Cobrar : Form
    {
        public Cobrar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Cobrar_Load(object sender, EventArgs e)
        {
            PV pv = new PV();
            pv.total(9);
            
        }
    }
}
