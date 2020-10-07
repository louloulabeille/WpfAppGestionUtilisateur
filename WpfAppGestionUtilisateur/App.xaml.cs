using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfAppGestionUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            this.Dispatcher.UnhandledException += App_DispatcherUnhandledException;
;
        }
        /// <summary>
        /// gestion des exceptions non géré par le système
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void App_DispatcherUnhandledException(object sender , DispatcherUnhandledExceptionEventArgs e  )
        {
            string messageError = string.Format(CultureInfo.CurrentCulture, "Une erreur est survenue de type : {0}", e.Exception.Message);
            MessageBox.Show(messageError, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            
            e.Handled = true;
        }
    }
}
