using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using EN;
namespace UI
{
    /// <summary>
    /// Lógica de interacción para RegistrarMarcas.xaml
    /// </summary>
    public partial class RegistrarMarcas : Window
    {
        ENMarca m2 = new ENMarca();
        BLMarca m = new BLMarca();
        int? id = null;
        string msg = "";
        public RegistrarMarcas(int? id = null)
        {
            InitializeComponent();
            txNombreMarca.Focus();
            if (id != null)
            {
                btnNuevaMarca.Visibility = Visibility.Hidden;
                this.id = id;
                cargarDatos();
            }
        }

        void cargarDatos()
        {
            m2 = m.buscar(id) as ENMarca;
            txNombreMarca.Text = m2.Nombre;
            txtComentario.Text = m2.Comentario;
        }

        private void btnGuardarMarca_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txNombreMarca.Text) ||
                string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                MessageBox.Show("Por favor rellene todos los campos obligatorios", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                m2.Nombre = txNombreMarca.Text;
                m2.Comentario = txtComentario.Text;

                try
                {
                    if (id != null)
                    {
                        msg = m.actualizar(id: id, marca: m2);
                        MessageBoxResult r =
                        MessageBox.Show($"{msg}\n¿Desea cerrar el editor?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                        if (r == MessageBoxResult.Yes) Close();
                    }
                    else
                    {

                        msg = m.registrar(marca: m2);
                        MessageBox.Show(msg, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                catch (Exception error)
                {

                    MessageBox.Show($"Ha ocurrido un error.\n{error.Message}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void btnNuevaMarca_Click(object sender, RoutedEventArgs e)
        {
            txNombreMarca.Text = "";
            txtComentario.Text = "";
            txNombreMarca.Focus();
        }
    }
}
