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
using MahApps.Metro.Controls;
using EN;
using BL;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para RegistrarClientes.xaml
    /// </summary>
    public partial class RegistrarClientes : MetroWindow
    {
        ENCliente c = new ENCliente();
        BLCliente c2 = new BLCliente();
        MainWindow mw = new MainWindow();
        int? id = null;

        public RegistrarClientes(int? id = null)
        {
            InitializeComponent();
            txtPrimerNombre.Focus();
            if (id != null)
            {
                btnNuevoCliente.Visibility = Visibility.Hidden;
                this.id = id;
                cargarDatos();
            }
        }
        
        void cargarDatos()
        {
            c = c2.buscar(id) as ENCliente;
            txtPrimerNombre.Text = c.primerNombre;
            txtSegundoNombre.Text = c.segundoNombre;
            txtPrimerApellido.Text = c.primerApellido;
            txtSegundoApellido.Text = c.segundoApellido;
            txtDui.Text = c.dui;
            txtDireccion.Text = c.direccion;
            txtTelefono.Text = c.telefono;
            txtCorreo.Text = c.correo;
        }

        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            string msj = "";
            ValidarClientess ob = new ValidarClientess();
            ObservableObjects ob1 = new ObservableObjects();
            if
            (
                 string.IsNullOrWhiteSpace(txtPrimerNombre.Text) ||
                 string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                 string.IsNullOrWhiteSpace(txtSegundoApellido.Text) ||
                 string.IsNullOrWhiteSpace(txtDui.Text) ||
                 string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                 string.IsNullOrWhiteSpace(txtTelefono.Text)
            )
            {
                MessageBox.Show("Por favor, rellene los campos obligatorios.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if
            (
               txtCorreo.IsFocused == false &&
               (string.IsNullOrWhiteSpace(txtDui.Text) == false) &&
               (ob1.buscarDui(txtDui.Text) == "No se ha encontrado dui")
            )
            {
                MessageBox.Show("Por favor, corrija el DUI", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if
            (
               txtCorreo.IsFocused == false && 
               (string.IsNullOrWhiteSpace(txtCorreo.Text)==false) && 
               (ob1.buscaCorreo(txtCorreo.Text) == "No se ha encontrado correo")
            )
            {
                MessageBox.Show("Por favor, corrija el correo", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    c.primerNombre = txtPrimerNombre.Text;
                    c.segundoNombre = txtSegundoNombre.Text;
                    c.primerApellido = txtPrimerApellido.Text;
                    c.segundoApellido = txtSegundoApellido.Text;
                    c.dui = txtDui.Text;
                    c.direccion = txtDireccion.Text;
                    c.telefono = txtTelefono.Text;
                    c.correo = txtCorreo.Text;
                    if (id == null)
                    {
                        msj = c2.registrar(c);
                        mw.cargarDatos();
                        MessageBox.Show(msj, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        msj = c2.actualizar(id, c);
                        mw.cargarDatos();
                        MessageBoxResult r =
                        MessageBox.Show(msj + " ¿Desea cerrar el editor?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                        if (r == MessageBoxResult.Yes) Close();
                    }
                    

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            txtPrimerNombre.Text="";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtDui.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtPrimerNombre.Focus();
        }

        private void txtDui_TextChanged(object sender, TextChangedEventArgs e)
        {
            int indice = txtDui.Text.Length;
            if (indice==9)
            {
                string txt = txtDui.Text.Remove(8);
                txtDui.Text = string.Concat(txt, "-");
                txtDui.Select(txtDui.Text.Length, 0);
            }
            
        }
    }
}
