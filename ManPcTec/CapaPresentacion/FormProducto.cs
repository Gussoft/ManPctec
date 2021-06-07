using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FormProducto : Form
    {
        N_Producto pro = new N_Producto();
        public FormProducto()
        {
            InitializeComponent();
            LlenarTabla();
            OcultarColumns();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {

        }

        private void LlenarTabla()
        {
            tabla.DataSource = pro.ListarProductos();
        }

        private void OcultarColumns()
        {
            tabla.Columns[2].Visible = false;
            tabla.Columns[5].Visible = false;
            tabla.Columns[7].Visible = false;

            tabla.Columns[0].Width = 80;
            tabla.Columns[1].Width = 80;
            tabla.Columns[3].Width = 80;
            tabla.Columns[4].Width = 150;
            tabla.Columns[6].Width = 150;
            tabla.Columns[8].Width = 150;

            tabla.Columns[0].DisplayIndex = 11;
            tabla.Columns[1].DisplayIndex = 11;
        }
    }
}
