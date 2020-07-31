using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static BLCliente c = new BLCliente();
        public DispatcherTimer dt = new DispatcherTimer();
        RegistrarClientes r;
        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += Dt_Tick;
            dt.Interval = new TimeSpan(0,0,0,1);
            cargarDatos();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            cargarDatos();
            if (r.DialogResult!=null)
            {
                dt.Stop();
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            r = new RegistrarClientes();
            r.ShowDialog();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListadoClientes.SelectedItem != null)
            {
                int id = int.Parse(dtgListadoClientes.SelectedValue.ToString());
                dt.Start();
                r = new RegistrarClientes(id);
                r.ShowDialog();
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

        public void cargarDatos(int? id = null, string nombre = null, string apellido = null, string dui = null)
        {
            try
            {
                if (nombre != null)
                {
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(nombre: nombre);
                }
                else if (apellido != null)
                {
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(apellido: apellido);
                }
                else if (id != null)
                {
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(id: id);
                }
                else if (dui != null)
                {
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista(dui: dui);
                }
                else
                {
                    dtgListadoClientes.ItemsSource = null;
                    dtgListadoClientes.ItemsSource = c.lista();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
            
        }

       
        /*
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
        */

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

        private void txtBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtgListadoClientes.ItemsSource = c.lista(nombre: txtBuscador.Text);
        }
    }
}
