using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tienda;

namespace DiscosApp
{
    public partial class FormAgregar : Form
    {
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco disco = new Disco();
            DiscoTienda tienda = new DiscoTienda();

            try
            {
                disco.Titulo = txtTitulo.Text;
                disco.Fecha = dtpFecha.Value;
                disco.Cant_Canciones = int.Parse(txtCanciones.Text);
                disco.Url_Imagen = txtImagen.Text;

                tienda.agregar(disco);
                MessageBox.Show("Agregado Exitosamente.");
                Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
