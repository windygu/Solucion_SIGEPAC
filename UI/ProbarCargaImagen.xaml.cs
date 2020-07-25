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
using System.IO;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para ProbarCargaImagen.xaml
    /// </summary>
    public partial class ProbarCargaImagen : Window
    {
        BLUsuario u = new BLUsuario();
        public ProbarCargaImagen()
        {
            InitializeComponent();
            byte[] binarios = u.cargarImagen(2);
            Stream stream = new MemoryStream(binarios);
            BitmapImage bt = new BitmapImage();
            bt.BeginInit();
            bt.StreamSource = stream;
            bt.EndInit();
            imgFoto.Source = bt;
        }
    }
}
