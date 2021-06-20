using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FormPro : Form
    {
        FormProducto formProducto = new FormProducto();
        E_Producto epro = new E_Producto();
        N_Producto npro = new N_Producto();

        public bool Update = false;

        public FormPro()
        {
            InitializeComponent();
        }

        private void FormPro_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Update)
            {
                try
                {
                    epro.Nombre = txtNombre.Text;
                    epro.Precioc = Convert.ToDecimal(txtpcompra.Text);
                    epro.Preciov = Convert.ToDecimal(txtpventa.Text);
                    epro.Stock = Convert.ToInt32(txtStock.Text);
                    epro.Idcategoria = Convert.ToInt32(cbcat.SelectedValue);
                    epro.Idmarca = Convert.ToInt32(cbmar.SelectedValue);

                    npro.InsertarProducto(epro);
                    MessageBox.Show("Se Guardo el Producto Correctamente!", "Mensaje del sistema");
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo Guardar! Error..." + ex);
                }
            }
            else
            {
                try
                {
                    epro.Idproducto = Convert.ToInt32(txtId.Text);
                    epro.Nombre = txtNombre.Text;
                    epro.Precioc = Convert.ToDecimal(txtpcompra.Text);
                    epro.Preciov = Convert.ToDecimal(txtpventa.Text);
                    epro.Stock = Convert.ToInt32(txtStock.Text);
                    epro.Idcategoria = Convert.ToInt32(cbcat.SelectedValue);
                    epro.Idmarca = Convert.ToInt32(cbmar.SelectedValue);

                    npro.EditarProducto(epro);
                    MessageBox.Show("Se Edito el Producto Correctamente!", "Mensaje del sistema");
                    Close();
                    Update = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Editar! Error..." + ex);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
