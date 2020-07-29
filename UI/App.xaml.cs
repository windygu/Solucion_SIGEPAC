using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Inicializamos la pantalla splash y la establecemos como la ventana principal
            var splashScreen = new Splash();
            this.MainWindow = splashScreen;
            splashScreen.Show();
            //En orden para asegurar que la UI se mantiene activa, necesitamos hacer un trabajo en un hilo diferente
            Task.Factory.StartNew(() =>
            {
                //Necesitamos hacer el trabajo en ramas para que podamos reportar el progreso
                /*
                for (int i = 0; i <= 4; i++)
                {
                    //Simulate a part of work being done
                    Thread.Sleep(15);
                    //Porque no estamos en el hilo de la UI necesitamos usar el Dispatcher asociado con la pantalla Splash para
                    //actualizar la barra de progreso
                    //splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
                }
                */

                Ellipse[] elipses = new Ellipse[4];
                elipses[0] = splashScreen.elipse1;
                elipses[1] = splashScreen.elipse2;
                elipses[2] = splashScreen.elipse3;
                elipses[3] = splashScreen.elipse4;

                for (int i = 0; i < 4; i++)
                {
                    Thread.Sleep(4);
                    splashScreen.Dispatcher.Invoke(() => elipses[i].Fill= Brushes.LightGreen);
                }

                //Una vez hayamos hecho lo necesario para usar el Dispatcher para crear y mostrar la MainWindow
                this.Dispatcher.Invoke(() =>
                    {
                        //Inicializamos la MainWindow , la establecemos como la ventana principal de la aplicacion y
                        //cerramos la pantalla Splash
                        MainWindow mainWindow = new MainWindow();
                        MainWindow = mainWindow;
                        mainWindow.Show();
                        splashScreen.Close();
                    });
            });
            
        }
    }
}
