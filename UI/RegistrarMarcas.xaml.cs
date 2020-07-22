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
        string msg = "";
        public RegistrarMarcas()
        {
            InitializeComponent();
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
                    msg = m.registrar(marca: m2);
                    MessageBox.Show(msg, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show($"Ha ocurrido un error.\n{error.Message}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            
        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            txNombreMarca.Text = "";
            txtComentario.Text = "";
            txNombreMarca.Focus();
        }
    }
}
