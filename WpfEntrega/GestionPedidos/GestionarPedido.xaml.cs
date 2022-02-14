using WpfEntrega.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfEntrega
{
    /// <summary>
    /// Lógica de interacción para GestionarPedido.xaml
    /// </summary>
    /// 
    
    public partial class GestionarPedido : Window
    {

        private string dni;
        private PedidoCollectionViewModel pcvm;

        public GestionarPedido(clientes cliente)
        {
            

            InitializeComponent();

            this.DataContext = cliente;

            pcvm = (PedidoCollectionViewModel)((ObjectDataProvider)this.Resources["CollectionVM"]).ObjectInstance;
            pcvm.cargarDatos(cliente.dni);
            
            dni = cliente.dni;
            txtNombreCli.Text = cliente.apellidos + ", " + cliente.nombre;
            
        }

        private void CompruebaBorrar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dtgPedidos != null)
            {
                if (dtgPedidos.SelectedIndex != -1)
                {
                    e.CanExecute = true;
                }
            }
        }

        private void EjecutarBorrar(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("Borrado", "Exito", MessageBoxButton.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                pcvm.objBD.pedidos.Remove((pedidos)dtgPedidos.SelectedItem);
                pcvm.ListaPedidos.RemoveAt(dtgPedidos.SelectedIndex);


            }
        }

        private void CompruebaModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dtgPedidos != null)
            {
                if (dtgPedidos.SelectedIndex != -1)
                {
                    e.CanExecute = true;
                }
            }
        }

        private void EjecutarModificar(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("¿Desea modificar el pedido?", "Modificar", MessageBoxButton.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                NuevoPedido nuevo = new NuevoPedido(dni, pcvm, "modificar", (pedidos)dtgPedidos.SelectedItem);
                nuevo.ShowDialog();
            }
        }


        private void CompruebaNuevo(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;     
        }

        private void EjecutarNuevo(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("¿Desea crear un nuevo pedido?", "Nuevo", MessageBoxButton.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                NuevoPedido nuevo = new NuevoPedido(dni, pcvm, "nuevo");
                nuevo.ShowDialog();
            }
        }


        private void CompruebaGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
                e.CanExecute = true;        
        }

        private void EjecutarGuardar(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("¿Desea guardar los cambios?", "Nuevo", MessageBoxButton.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                pcvm.objBD.SaveChanges();
                System.Windows.MessageBox.Show("Cambios guardados", "Exito");
            }
        }

    }


    public static class Comandos
    {
        public static readonly RoutedUICommand Borrar = new RoutedUICommand(
            "Crear pedido",
            "Crear",
            typeof(Comandos),
            new InputGestureCollection()
            { new KeyGesture(Key.D,ModifierKeys.Control) }
            );

        public static readonly RoutedUICommand Modificar = new RoutedUICommand(
            "Modificar el pedido",
            "Modificar",
            typeof(Comandos),
            new InputGestureCollection()
            { new KeyGesture(Key.W,ModifierKeys.Control) }
            );

        public static readonly RoutedUICommand Nuevo = new RoutedUICommand(
            "Crear nuevo pedido",
            "Nuevo",
            typeof(Comandos),
            new InputGestureCollection()
            { new KeyGesture(Key.A,ModifierKeys.Control) }
            );

        public static readonly RoutedUICommand Guardar = new RoutedUICommand(
            "Crear nuevo pedido",
            "Nuevo",
            typeof(Comandos),
            new InputGestureCollection()
            { new KeyGesture(Key.S,ModifierKeys.Control) }
            );

    }
}
