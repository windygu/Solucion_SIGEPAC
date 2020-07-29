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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using EN;
using BL;
using System.ComponentModel;
using MahApps.Metro.Controls;
using WPFColorPickerLib;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static BLCliente c = new BLCliente();

        public MainWindow()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            
            RegistrarClientes rc = new RegistrarClientes();
            rc.Show();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListadoClientes.SelectedItem != null)
            {
                int id = int.Parse(dtgListadoClientes.SelectedValue.ToString());
                RegistrarClientes a = new RegistrarClientes(id);
                a.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para editar.");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListadoClientes.SelectedItem != null)
            {
                try
                {
                    int id = int.Parse(dtgListadoClientes.SelectedValue.ToString());
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el cliente?", "Aviso",
                        MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes) c.eliminar(id);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            cargarDatos();
        }

        private void btnActual_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos(int? id = null, string nombre = null, string apellido = null, string dui = null)
        {
            try
            {
                if (nombre != null)
                {
                    cboMostrando.SelectedItem = null;
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(nombre: nombre);
                }
                else if (apellido != null)
                {
                    cboMostrando.SelectedItem = null;
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(apellido: apellido);
                }
                else if (id != null)
                {
                    cboMostrando.SelectedItem = null;
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(id: id);
                }
                else if (dui != null)
                {
                    cboMostrando.SelectedItem = null;
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(dui: dui);
                }
                else
                {
                    if (cboiConPedidos.IsSelected == true)
                    {
                        dtgListadoClientes.ItemsSource = null;
                        dtgListadoClientes.ItemsSource = c.listaConPedido();
                    }
                    else if (cboiSinPedidos.IsSelected == true)
                    {

                    }
                    else if (cboiTodos.IsSelected == true)
                    {
                        dtgListadoClientes.ItemsSource = null;
                        dtgListadoClientes.ItemsSource = c.lista();
                    }
                    else if (cboMostrando.SelectedItem == null)
                    {
                        cboiTodos.IsSelected = true;
                        dtgListadoClientes.ItemsSource = null;
                        dtgListadoClientes.ItemsSource = c.lista();
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rdbId.IsChecked == true)
            {
                int? id;
                try
                {
                    id = int.Parse(txtBuscador.Text);
                    cargarDatos(id: id);
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else if (rdbNombre.IsChecked == true)
            {
                string nombre = txtBuscador.Text;
                cargarDatos(nombre: nombre);
            }
            else if (rdbApellido.IsChecked == true)
            {
                string apellido = txtBuscador.Text;
                cargarDatos(apellido: apellido);
            }
            else if (rdbDUI.IsChecked == true)
            {
                string dui = txtBuscador.Text;
                cargarDatos(dui: dui);
            }
            else if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                MessageBox.Show("Ingrese la palabra clave para buscar");
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (rdbId.IsChecked== true)
            {
                if
                (
                   e.Key >= Key.D0 && e.Key <= Key.D9 ||
                   e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9
                )
                    e.Handled = false;
                else e.Handled = true;
            }
        }

        private void txtBuscador_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBuscador.Text.Length == 0)
            {
                tbMarca.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbMarca.Visibility = Visibility.Collapsed;
            txtBuscador.Focus();
        }

        private void txtBuscador_GotFocus(object sender, RoutedEventArgs e)
        {
            tbMarca.Visibility = Visibility.Collapsed;
        }

        private void txtBuscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgListadoClientes.ItemsSource = c.lista(nombre: txtBuscador.Text);
        }

        private void btnColorFondo_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog w = new ColorDialog();
            w.Owner = this;
            if (w.ShowDialog()==true)
            {
                Background = new SolidColorBrush(w.SelectedColor);
            }
        }
    }
}
