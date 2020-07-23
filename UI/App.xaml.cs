using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
                for (int i = 1; i <= 100; i++)
                {
                    //Simulate a part of work being done
                    System.Threading.Thread.Sleep(30);
                    //Porque no estamos en el hilo de la UI necesitamos usar el Dispatcher asociado con la pantalla Splash para
                    //actualizar la barra de progreso
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
                }
                //Una vez hayamos hecho lo necesario para usar el Dispatcher para crear y mostrar la MainWindow
                this.Dispatcher.Invoke(() =>
                    {
                        //Inicializamos la MainWindow , la establecemos como la ventana principal de la aplicacion y
                        //cerramos la pantalla Splash
                        var mainWindow = new MainWindow();
                        this.MainWindow = mainWindow;
                        mainWindow.Show();
                        splashScreen.Close();
                    });
            });
            
        }
    }
}
