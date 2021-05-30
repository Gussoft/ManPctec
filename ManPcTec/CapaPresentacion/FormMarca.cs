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
    public partial class FormMarca : Form
    {
        private string idCategoria;
        private bool Editarse = false;
        N_Marca negocio = new N_Marca();
        E_Marca entidad = new E_Marca();

        public FormMarca()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CleanText();
            habilitar(true, false);
            Editarse = false;
        }

        public void mostrarLista(string buscar)
        {
            N_Marca marca = new N_Marca();
            tabla.DataSource = marca.ListarMarca(buscar);
            tabla.ClearSelection();
        }

        private void FormMarca_Load(object sender, EventArgs e)
        {
            mostrarLista("");
            accionTabla();
            habilitar(false, true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                Editarse = true;
                idCategoria = tabla.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tabla.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tabla.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tabla.CurrentRow.Cells[3].Value.ToString();
                habilitar(true, false);
            }
            else
            {
                MessageBox.Show("Seleccione una Fila que desea Editar!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea Eliminar este Registro?", "Mensaje del Sistema", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    entidad.IdMar = Convert.ToInt32(tabla.CurrentRow.Cells[0].Value.ToString());
                    negocio.EliminarMarca(entidad);
                    mostrarLista("");
                }
                else
                {
                    tabla.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Seleccione la Fila que desea Eliminar!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            habilitar(false, true);
            CleanText();
            tabla.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    entidad.NombreMar = txtNombre.Text.ToUpper();
                    entidad.DescripcionMar = txtDescripcion.Text.ToUpper();

                    negocio.InsertarMarca(entidad);
                    MessageBox.Show("Se Guardo Correctamente el Registro!");
                    mostrarLista("");
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
                    entidad.IdMar = Convert.ToInt32(idCategoria);
                    entidad.NombreMar = txtNombre.Text.ToUpper();
                    entidad.DescripcionMar = txtDescripcion.Text.ToUpper();

                    negocio.EditarMarca(entidad);
                    MessageBox.Show("Se Edito Correctamente el Registro!");
                    mostrarLista("");
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarLista(txtBuscar.Text);
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
            tabla.Enabled = desactivar;
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

        public void accionTabla()
        {
            tabla.Columns[0].Visible = false;
            tabla.Columns[1].Width = 60;
            tabla.Columns[2].Width = 150;
            tabla.ClearSelection();
        }
    }
}
