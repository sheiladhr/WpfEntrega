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
using WpfEntrega.GestionClientes;

namespace WpfEntrega
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        

            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnGestClientes_Click(object sender, RoutedEventArgs e)
        {
            MostrarVentana(new PrincClientes());
        }

        private void MostrarVentana(PrincClientes princClientes)
        {
            this.grdPrincipal.Children.Clear();
            this.grdPrincipal.Children.Add(princClientes);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGestPedidos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
