using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        BLUsuario u = new BLUsuario();
        OpenFileDialog ofd = new OpenFileDialog();
        string fileName = "";
        public Perfil()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog()==true)
            {
                fileName = ofd.FileName;
                Uri ur = new Uri(fileName);
                imgAdmin.Source = new BitmapImage(ur);
            }
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Stream stm = File.OpenRead(fileName);
            byte[] binaryImage = new byte[stm.Length];
            stm.Read(binaryImage, 0, (int)stm.Length);
            string msg = u.insertarImagen(4, binaryImage);
            MessageBox.Show(msg, "Aviso");
        }
    }
}
