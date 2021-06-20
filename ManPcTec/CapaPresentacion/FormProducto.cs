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

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla.Rows[e.RowIndex].Cells["delete"].Selected)
            {
                DialogResult dialogResult = MessageBox.Show("Desea Eliminar este Registro?", "Mensaje del Sistema", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int delete = Convert.ToInt32(tabla.Rows[e.RowIndex].Cells[2].Value.ToString());
                    pro.EliminarProducto(delete);
                    LlenarTabla();
                }
            }
            else if(tabla.Rows[e.RowIndex].Cells["edit"].Selected)
            {
                FormPro producto = new FormPro();
                producto.Update = true;
                producto.txtId.Text = tabla.Rows[e.RowIndex].Cells["idproducto"].Value.ToString();
                producto.txtCodigo.Text = tabla.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                producto.txtNombre.Text = tabla.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                producto.txtpcompra.Text = tabla.Rows[e.RowIndex].Cells["precioc"].Value.ToString();
                producto.txtpventa.Text = tabla.Rows[e.RowIndex].Cells["preciov"].Value.ToString();
                producto.txtStock.Text = tabla.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                producto.cbcat.Text = tabla.Rows[e.RowIndex].Cells["categoria"].Value.ToString();
                producto.cbmar.Text = tabla.Rows[e.RowIndex].Cells["marca"].Value.ToString();

                producto.ShowDialog();
                LlenarTabla();
            }
        }

        private void btnnewpro_Click(object sender, EventArgs e)
        {
            FormPro pro = new FormPro();
            pro.ShowDialog();
            pro.Update = false;
            LlenarTabla();
        }
    }
}
