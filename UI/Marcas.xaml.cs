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

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarMarcas rm = new RegistrarMarcas();
            rm.Show();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos();            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListadoMarcas.SelectedItem != null)
            {
                int id = int.Parse(dtgListadoMarcas.SelectedValue.ToString());
                MessageBoxResult result = MessageBox.Show("¿Desea eliminar el cliente?", "Aviso",
                    MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes) m.eliminar(id);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            cargarDatos();
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListadoMarcas.SelectedItem != null)
            {
                int id = int.Parse(dtgListadoMarcas.SelectedValue.ToString());
                RegistrarMarcas a = new RegistrarMarcas(id);
                a.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para editar.");
            }
        }
    }
}
