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
namespace UI
{
    /// <summary>
    /// Lógica de interacción para Marcas.xaml
    /// </summary>
    public partial class Marcas : Window
    {
        BLMarca m = new BLMarca();
        public Marcas()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActual_Click(object sender, RoutedEventArgs e)
        {

        }

        void cargarDatos(int? id = null, string nombre = null)
        {
            if  (id != null)
            {
                dtgListadoMarcas.ItemsSource = null;
                dtgListadoMarcas.ItemsSource = m.lista(id: id);
            }
            else if (nombre != null)
            {
                dtgListadoMarcas.ItemsSource = null;
                dtgListadoMarcas.ItemsSource = m.lista(nombre: nombre);
            }
            else
            {
                dtgListadoMarcas.ItemsSource = null;
                dtgListadoMarcas.ItemsSource = m.lista();
            }
        }
    }
}
