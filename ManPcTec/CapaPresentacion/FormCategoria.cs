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
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormCategoria : Form
    {
        private string idCategoria;
        private bool Editarse = false;
        E_Categoria entidad = new E_Categoria();
        N_Categoria negocio = new N_Categoria();
        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            mostrarCategoria("");
            accionTabla();
            habilitar(false, true);
        }

        public void mostrarCategoria(string buscar)
        {
            N_Categoria categoria = new N_Categoria();
            tablaCat.DataSource = categoria.ListarCategoria(buscar);
            tablaCat.ClearSelection();
        }

        public void accionTabla()
        {
            tablaCat.Columns[0].Visible = false;
            tablaCat.Columns[1].Width = 60;
            tablaCat.Columns[2].Width = 150;
            tablaCat.ClearSelection();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarCategoria(txtBuscar.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CleanText();
            habilitar(true, false);
            Editarse = false;
        }

        private void habilitar(bool activar, bool desactivar)
        {
            txtNombre.Enabled = activar;
            txtNombre.Focus();
            txtDescripcion.Enabled = activar;
            btnSave.Enabled = activar;
            btnCancel.Enabled = activar;

            btnNew.Enabled = desactivar;
            btnEdit.Enabled = desactivar;
            btnDelete.Enabled = desactivar;
            btnExcel.Enabled = desactivar;
            btnPrint.Enabled = desactivar;
            tablaCat.Enabled = desactivar;
            txtBuscar.Enabled = desactivar;
            txtBuscar.Focus();
        }

        private void CleanText()
        {
            
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtBuscar.Clear();
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            habilitar(false, true);
            CleanText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tablaCat.SelectedRows.Count > 0)
            {
                Editarse = true;
                idCategoria = tablaCat.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tablaCat.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaCat.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaCat.CurrentRow.Cells[3].Value.ToString();
                habilitar(true, false);
            }
            else
            {
                MessageBox.Show("Seleccione una Fila que desea Editar!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    entidad.NombreCat = txtNombre.Text.ToUpper();
                    entidad.DescripcionCat = txtDescripcion.Text.ToUpper();

                    negocio.InsertarCategoria(entidad);
                    MessageBox.Show("Se Guardo Correctamente el Registro!");
                    mostrarCategoria("");
                    habilitar(false, true);
                    CleanText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Guardar el Registro : " + ex);
                }
            }
            else
            {
                try
                {
                    entidad.IdCat = Convert.ToInt32(idCategoria);
                    entidad.NombreCat = txtNombre.Text.ToUpper();
                    entidad.DescripcionCat = txtDescripcion.Text.ToUpper();

                    negocio.EditarCategoria(entidad);
                    MessageBox.Show("Se Edito Correctamente el Registro!");
                    mostrarCategoria("");
                    habilitar(false, true);
                    CleanText();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Editar el Registro : " + ex);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tablaCat.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea Eliminar este Registro?", "Mensaje del Sistema", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    entidad.IdCat = Convert.ToInt32(tablaCat.CurrentRow.Cells[0].Value.ToString());
                    negocio.EliminarCategoria(entidad);
                    mostrarCategoria("");
                }
                else
                {
                    tablaCat.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Seleccione la Fila que desea Eliminar!");
            }
        }
    }
}
