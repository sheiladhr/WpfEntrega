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

namespace WpfEntrega.GestionPedidos
{
    /// <summary>
    /// Lógica de interacción para SeleccionClientesPedido.xaml
    /// </summary>
    public partial class SeleccionClientesPedido : Window
    {

        private List<clientes> listaDni = new List<clientes>();

        public SeleccionClientesPedido()
        {
            InitializeComponent();
            cargarClientes();
        }

        private void cargarClientes()
        {

            using (entregasEntities1 objBD = new entregasEntities1())
            {
                var qClientes = from cli in objBD.clientes
                                orderby cli.nombre, cli.apellidos ascending
                                select cli;


                foreach (var cli in qClientes.ToList())
                {
                    cbClientes.Items.Add(cli.apellidos + ", " + cli.nombre);
                    listaDni.Add(cli);
                }

            }
        }

        private void cbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestionarPedido gestion = new GestionarPedido(listaDni[cbClientes.SelectedIndex]);
            gestion.ShowDialog();

        }
    }
}
