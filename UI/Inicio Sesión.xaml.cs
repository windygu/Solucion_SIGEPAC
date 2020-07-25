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
    /// Lógica de interacción para Inicio_Sesión.xaml
    /// </summary>
    public partial class Inicio_Sesión : Window
    {
        BLUsuario u = new BLUsuario();
        ENUsuario u2 = new ENUsuario();
        public Inicio_Sesión()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            u2 = u.buscarUsuario(txtUsuario.Text, pswClave.Password);
            if (u2 != null)
            {
                ProbarCargaImagen mw = new ProbarCargaImagen();
                mw.Show();
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrecta", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
