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
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            mostrarCategoria("");
        }

        public void mostrarCategoria(string buscar)
        {
            N_Categoria categoria = new N_Categoria();
            tablaCat.DataSource = categoria.ListarCategoria(buscar);
        }
    }
}
