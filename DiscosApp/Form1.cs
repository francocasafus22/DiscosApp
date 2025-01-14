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
    public partial class Form1 : Form
    {

        private List<Disco> discoList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDiscos();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {

            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.Url_Imagen);

        }
        public void cargarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://static.vecteezy.com/system/resources/thumbnails/020/995/380/small/vinyl-disc-template-isolated-on-white-background-illustration-free-vector.jpg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregar formAgregar = new FormAgregar();
            formAgregar.ShowDialog();
            cargarDiscos();
           
        }

        private void cargarDiscos()
        {
            DiscoTienda tienda = new DiscoTienda();
            discoList = tienda.listar();  //devuelve la lista tipo Disco y la guarda en discoList
            dgvDiscos.DataSource = discoList;
            dgvDiscos.Columns["Url_Imagen"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
            cargarImagen(discoList[0].Url_Imagen);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            DiscoTienda tienda = new DiscoTienda();

            try
            {
                tienda.borrar(seleccionado);
                MessageBox.Show("Disco borrado exitosamente.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cargarDiscos();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            FormModificar form = new FormModificar(seleccionado);

            try
            {
                form.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { cargarDiscos(); }
            
            
        }
    }
}
