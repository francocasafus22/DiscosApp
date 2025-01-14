using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using tienda;

namespace DiscosApp
{
    public partial class FormModificar : Form
    {

        private Disco discoRecibido;
        public FormModificar(Disco disco)
        {
            InitializeComponent();
            discoRecibido = disco;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            Disco nuevo = new Disco();
            DiscoTienda tienda = new DiscoTienda();

            try
            {
                nuevo.Id = discoRecibido.Id;
                nuevo.Titulo = txtTitulo.Text;
                nuevo.Fecha = dtpFecha.Value;
                nuevo.Cant_Canciones = int.Parse(txtCanciones.Text);
                nuevo.Url_Imagen = txtImagen.Text;

                tienda.modificar(nuevo);
                MessageBox.Show("Modificado exitosamente.");
                Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormModificar_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = discoRecibido.Titulo;
            dtpFecha.Value = discoRecibido.Fecha;
            txtCanciones.Text = discoRecibido.Cant_Canciones.ToString();
            txtImagen.Text = discoRecibido.Url_Imagen;
        }
    }
}
