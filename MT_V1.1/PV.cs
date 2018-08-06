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
using System.Data.SqlClient;


namespace MT_V1._1
{
    public partial class PV : Form
    {
        int bdU = 0; // Bandera para update 
        string busquedaUsuario = "";
        int tipoVenta = 1;
        decimal totalPLL = 0;
        public static int cont_fila = 0;



        public PV()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
//panel
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Show();
            panelPLL.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tipoVenta = 1;
            panelReportes.Hide();
            panelPed.Hide();
            panelME.Hide();
            panelPLL.Show();

        }
        //panel

        private void button8_Click(object sender, EventArgs e)
        {
            tipoVenta = 2;
            panelReportes.Hide();
            panelPed.Hide();
            panelPLL.Hide();
            panelME.Show();
        }
        //panel

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
            tipoVenta = 3;
            panelReportes.Hide();
            panelPed.Show();
            panelPLL.Hide();
            panelME.Hide();
          
        }
        //panel

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
            panelReportes.Hide();
            panelProductos.Hide();
            panelVentas.Hide();
            panelInventarios.Show();
            DGV_I_I.DataSource = llenadoDGV("productos").Tables[0];
        }
        //panel

        private void button2_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelVentas.Hide();
            panelProductos.Show();
        }
        //panel

        private void PV_Load(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Show();


            string cmd = "select * from usuarios where id_usuario =" + LogIn.codigo;

            DataSet ds = Utilidades.Ejecutar(cmd);

            lblUturno.Text = ds.Tables[0].Rows[0]["account"].ToString().Trim();       

            lblDT.Text = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm:ss tt");
            //pone la hora y fecha actual en el formato dado

            panelVentas.Show();

            if (LogIn.permisos == true)
            {
                btnProductos.Enabled = true;
                btnInventarios.Enabled = true;
                btnReportes.Enabled = true;


            }else
            {
               
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            panelUsuarios.Hide();
            panelReportes2.Hide();
            panelSesiones.Show();


            DGVSesiones.DataSource = llenadoDGV("sesiones").Tables[0];
            //Falta hacer las llaves foraneas para que se muestre el nombre del usuario

           
            
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelReportes.Show();
            panelProductos.Hide();
            panelVentas.Hide();
            panelInventarios.Hide();
            DGVSesiones.DataSource = llenadoDGV("sesiones").Tables[0];
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];



        }
        //panel



        private void btn_R_U_Click(object sender, EventArgs e)
        {
            panelUsuarios.Show();
            panelSesiones.Hide();
            panelReportes2.Hide();
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];
        }
        public DataSet llenadoDGV(string tabla)
        {
            DataSet ds;
            string cmd = string.Format("Select * from " + tabla);
            ds = Utilidades.Ejecutar(cmd);

            return ds;
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            int v = 1;
            bdU = 1;

            consultar(v);


            // falta hacer el update de informacion con el boton actualizar


        }

        public  void consultar (int v)
        {
            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", v);

            DataSet ds = Utilidades.Ejecutar(cmd);

            txtP_IdP.Text = ds.Tables[0].Rows[0]["id_producto"].ToString().Trim();
            txtP_descripcion.Text = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            txtP_stock.Text = ds.Tables[0].Rows[0]["stock"].ToString().Trim();
            txtP_Precio.Text = ds.Tables[0].Rows[0]["precio"].ToString().Trim();
        }

        public void ActualizarProductos (int p)
        {
            try
            {
                string dP = txtP_descripcion.Text;
                int sP = Convert.ToInt32(txtP_stock.Text);
                decimal pP = Convert.ToDecimal(txtP_Precio.Text);

                string cmd = string.Format("update productos set descripcion = '{0}', stock = '{1}',precio='{2}' where id_producto = '{3}'", dP, sP, pP, bdU);

                DataSet ds = Utilidades.Ejecutar(cmd);

                
            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("Llame al 6182003575 para recibir soporte");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //borrar omg
        
        }


        private void button10_Click(object sender, EventArgs e)
        {
            bool existe = false;
            int num_fila = 0;
            if (cont_fila == 0)
            {
                DGV_V_L.Rows.Add("Asado Rojo", 13, 2, 8.00);
                double importe = Convert.ToDouble(DGV_V_L.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(DGV_V_L.Rows[cont_fila].Cells[3].Value);
                DGV_V_L.Rows[cont_fila].Cells[4].Value = importe;

                cont_fila++;
            }
            else
            {
                foreach(DataGridViewRow fila  in DGV_V_L.Rows)
                {
                    if(fila.Cells[0].ToString()=="Asado Rojo")
                    {
                        existe = true;
                        num_fila = fila.Index;
                       
                    }
                }

            }
        }

        #region Como hacer una region
        #endregion

        #region Botones de productos
        private void button44_Click(object sender, EventArgs e)
        {
            int v = 2;
            bdU = 2;

            consultar(v);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            int v = 3;
            bdU = 3;
            consultar(v);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            int v = 4;
            bdU = 4;
            consultar(v);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int v = 5;
            bdU = 5;

            consultar(v);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            int v = 6;
            bdU = 6;
            consultar(v);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            int v = 7;
            bdU = 7;
            consultar(v);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            int v = 8;
            bdU = 8;
            consultar(v);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int v = 9;
            bdU = 9;
            consultar(v);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int v = 10;
            bdU = 10;
            consultar(v);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            int v = 11;
            bdU = 11;
            consultar(v);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            int v = 12;
            bdU = 12;
            consultar(v);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            int v = 13;
            bdU = 13;
            consultar(v);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            int v = 14;
            bdU = 14;
            consultar(v);
        }

        #endregion
        private void button46_Click(object sender, EventArgs e)
        {
            if (bdU == 0)
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                consultar(bdU);
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            ActualizarProductos(bdU);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //borrar
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            //borrar
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //NuevoUsuario
            panelR_U_NU.Show();
            panelR_U_M.Hide();
        }

        private void btnModificarU_Click(object sender, EventArgs e)
        {
            panelR_U_NU.Hide();
            panelR_U_M.Show();
        }

        private void btnReportes2_Click(object sender, EventArgs e)
        {
            panelUsuarios.Hide();
            panelSesiones.Hide();
            panelReportes2.Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            //guardar nuevo usuarios
            string nombre, usuario, psw1, psw2;
           
            int status =0;
            nombre = txtNombre.Text;
            usuario = txtUsuario.Text;
            psw1 = txtPsw1.Text;
            psw2 = txtpsw2.Text;

            try
            {
                if (psw1 == psw2)
                {
                    if (rBtnA.Checked)
                    {
                        rBtnU.Checked = false;
                        status = 1;
                    }
                    else if (rBtnU.Checked)
                    {
                        rBtnA.Checked = false;
                        status = 0;
                    }

                    
                    string cmd = string.Format("insert into usuarios (nombre, account, psw,status_admin) values ('{0}','{1}','{2}','{3}')", nombre, usuario, psw2, status);
                    Utilidades.Ejecutar(cmd);                  
                    txtNombre.ResetText();
                    txtUsuario.ResetText();
                    txtPsw1.ResetText();
                    txtpsw2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Contraseñas no coinciden, revise los campos");
                    txtNombre.ResetText();
                    txtUsuario.ResetText();
                    txtPsw1.ResetText();
                    txtpsw2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }
            }catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];
        }

        private void rBtnA_CheckedChanged(object sender, EventArgs e)
        {
            //borrar
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                
                string cmd = string.Format("select * from usuarios where account = '" + txtBuscar.Text + "'");
                DataSet ds = Utilidades.Ejecutar(cmd);


                busquedaUsuario = txtBuscar.Text;
                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string password = ds.Tables[0].Rows[0]["psw"].ToString().Trim();
                string nombre = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
                string status = ds.Tables[0].Rows[0]["status_admin"].ToString().Trim();

               
                txtMU.Text = cuenta;
                txtMN.Text = nombre;
                txtMC.Text = password;
                txtMC2.Text = password;
                groupBox1.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Usuario no existe");
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            
           
            //int status = Convert.ToInt32(txtP_stock.Text);
            //decimal pP = Convert.ToDecimal(txtP_Precio.Text);
            int statusModificarUsuario=0;
            if (rBtbMA.Checked)
            {
                statusModificarUsuario = 1;
                modificarUsuario(statusModificarUsuario);
                
            }
            else if (rBtbMU.Checked)
            {
                statusModificarUsuario = 0;
                modificarUsuario(statusModificarUsuario);
                
            }
            else
            {
                MessageBox.Show("Selecciona tipo de usuario!");
            }
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];


        }
        public void modificarUsuario(int s)
        {
            string nombre = txtMN.Text;
            string account = txtMU.Text;
            string password1 = txtMC.Text;
            string password2 = txtMC2.Text;
            
            try
            {
                if (password1 == password2)
                {

                    string cmd = string.Format("update usuarios set nombre = '{0}', account = '{1}',psw ='{2}' , status_admin = '{3}' where account = '{4}'", nombre, account, password2, s, busquedaUsuario);

                    DataSet ds = Utilidades.Ejecutar(cmd);
                    txtMU.ResetText();
                    txtMN.ResetText();
                    txtMC.ResetText();
                    txtMC2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Contraseñas no coinciden, revise los campos");
                    txtMU.ResetText();
                    txtMN.ResetText();
                    txtMC.ResetText();
                    txtMC2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("Llame al 6182003575 para recibir soporte");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string cmd = string.Format("delete from usuarios where account = '{0}'", busquedaUsuario);
            DataSet ds = Utilidades.Ejecutar(cmd);
            txtMU.ResetText();
            txtMN.ResetText();
            txtMC.ResetText();
            txtMC2.ResetText();
            txtBuscar.ResetText();
            groupBox1.Enabled = false;
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];
        }

#region BOTONES VENTAS
        private void btnAsadoRojo_Click(object sender, EventArgs e)
        {
            string descripcion;
            int stock =0 , id_producto, cantidad =0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", 1);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            stock = Convert.ToInt32(ds.Tables[0].Rows[0]["stock"].ToString().Trim());
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

            if (tipoVenta == 1)
            {

                if (stock > 0)
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;

                    DGV_V_L.Rows.Add(descripcion, stock, cantidad, precio, importe);
                    total(totalPLL);
                }
                else
                {
                    MessageBox.Show("Producto insuficiente");
                }
            } else if (tipoVenta == 2)
            {
                stock = stock - 1;
                cantidad = cantidad + 1;
                importe = cantidad * precio;

                DGV_V_L.Rows.Add(descripcion, stock, cantidad, precio, importe);
            }
            else if (tipoVenta == 3){
                stock = stock - 1;
                cantidad = cantidad + 1;
                importe = cantidad * precio;

                DGV_V_L.Rows.Add(descripcion, stock, cantidad, precio, importe);
            }
        }

        public Decimal total(decimal t)
        {
            int contador = DGV_V_L.Rows.Count;
            
            for (int i = 0; i < contador ; i++)
            {
                try
                {
                    totalPLL += Convert.ToDecimal(DGV_V_L.Rows[i].Cells[4].Value.ToString());
                }
                catch (Exception)
                {
                    totalPLL += 0;
                    MessageBox.Show("Nada se cor");
                }
            }
            lblTotal.Text = Convert.ToString("$" + totalPLL);
            return (totalPLL);
        }
        
        public void consultaVentas(int id_p)
        {


        }

        private void btnRajas_Click(object sender, EventArgs e)
        {
            bool existe = false;
            int num_fila = 0;

            string descripcion;
            int stock = 0, id_producto, cantidad = 0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", 2);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            stock = Convert.ToInt32(ds.Tables[0].Rows[0]["stock"].ToString().Trim());
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

            if (cont_fila == 0)
            {
                stock = stock - 1;
                cantidad = cantidad + 1;
                importe = cantidad * precio; 
                DGV_V_L.Rows.Add(descripcion, stock, cantidad, precio, importe);

                cont_fila++;
            }
            else
            {
                foreach(DataGridViewRow fila in DGV_V_L.Rows)
                {
                    if(fila.Cells[0].Value.ToString() == descripcion)
                    {
                        existe = true;
                        num_fila = fila.Index;
                    }
                }
                if (existe == true)
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;
                    DGV_V_L.Rows[num_fila].Cells[2].Value = (Convert.ToDouble(DGV_V_L.Rows[num_fila].Cells[2].Value) + 1).ToString();
                    DGV_V_L.Rows[num_fila].Cells[1].Value = (Convert.ToInt32(DGV_V_L.Rows[num_fila].Cells[1].Value) - 1);
                    //int c = Convert.ToInt32(DGV_V_L.Rows[num_fila].Cells[2].ToString().Trim());
                   // decimal p = Convert.ToDecimal(DGV_V_L.Rows[num_fila].Cells[3].ToString().Trim());
                    DGV_V_L.Rows[num_fila].Cells[4].Value = (Convert.ToInt32(DGV_V_L.Rows[num_fila].Cells[2].Value) * Convert.ToDecimal(DGV_V_L.Rows[num_fila].Cells[3].Value));
                }
                else
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;
                    DGV_V_L.Rows.Add(descripcion, stock, cantidad, precio, importe);

                    cont_fila++; 
                }
            }
        }

        private void btnSalsaVerde_Click(object sender, EventArgs e)
        {

        }

        private void btnChicharron_Click(object sender, EventArgs e)
        {

        }

        private void btnAsadoVerde_Click(object sender, EventArgs e)
        {

        }

        private void btnPina_Click(object sender, EventArgs e)
        {

        }

        private void btnFresa_Click(object sender, EventArgs e)
        {

        }

        private void btnCajeta_Click(object sender, EventArgs e)
        {

        }

        private void btnZarzamora_Click(object sender, EventArgs e)
        {

        }

        private void btnRompope_Click(object sender, EventArgs e)
        {

        }

        private void btnCapuchino_Click(object sender, EventArgs e)
        {

        }

        private void btnChocorrol_Click(object sender, EventArgs e)
        {

        }

        private void btnChampurrado_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresco_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnProductos_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelProductos.Show();
            panelVentas.Hide();
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Show();
            panelProductos.Hide();
            panelVentas.Hide();
            DGV_I_I.DataSource = llenadoDGV("productos").Tables[0];

        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            panelReportes.Show();
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Hide();
            DGVSesiones.DataSource = llenadoDGV("sesiones").Tables[0];
            panelSesiones.Show();


        }
    }
}
