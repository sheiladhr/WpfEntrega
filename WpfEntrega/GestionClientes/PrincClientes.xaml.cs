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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfEntrega.ViewModels;

namespace WpfEntrega.GestionClientes
{
    /// <summary>
    /// Lógica de interacción para PrincClientes.xaml
    /// </summary>
    public partial class PrincClientes : System.Windows.Controls.UserControl
    {
        CollectionViewModel cvm;
        public PrincClientes()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
        }

        private void compruebaBorrar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listView.SelectedIndex != -1)
            {
                e.CanExecute = true;
            }
        }
        private void ejecutarBorrar(object sender, ExecutedRoutedEventArgs e)
        {
            clientes cl;
            DialogResult dr = (DialogResult)System.Windows.Forms.MessageBox.Show("¿Seguro que desea eliminarlo?", "BORRAR", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                cvm.ListaClientes.RemoveAt(listView.SelectedIndex);
             
             //  cvm.objBD.clientes.Remove((clientes)listView.Items[listView.SelectedIndex]);
                cl = (clientes)listView.SelectedItem;
                  System.Windows.MessageBox.Show("Selected " + listView.SelectedItems.ToString());
                //cvm.objBD.clientes.Add(objCliente);
                //cvm.ListaClientes.Add(objCliente);
            }
        }

        private void CompruebaAñadir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void EjecutarAñadir(object sender, ExecutedRoutedEventArgs e)
        {
            NuevoCliente nm = new NuevoCliente(cvm);
            nm.ShowDialog();

        }
        private void CompruebaModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listView.SelectedIndex != -1)
            {
                e.CanExecute = true;
            }
        }
        private void EjecutarModificar(object sender, ExecutedRoutedEventArgs e)
        {
            int pos = listView.SelectedIndex;
            ModificarCliente mod = new ModificarCliente(cvm.ListaClientes[pos], cvm);
            mod.ShowDialog();


        }
        private void CompruebaGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void EjecutarGuardar(object sender, ExecutedRoutedEventArgs e)
        {
            cvm.GuardarDatos();
            System.Windows.MessageBox.Show("Guardada la base de datos con exito", "Guardado correcto");
        }

    }
    public static class Comandos
    {
        public static readonly RoutedUICommand Aniadir = new RoutedUICommand
                (
            "Añadir.",
            "Añadir",
                typeof(Comandos),
             new InputGestureCollection() {
                 new KeyGesture(Key.A, ModifierKeys.Control)
             }
             );
        public static readonly RoutedUICommand Modificar = new RoutedUICommand
              (
          "Modificar.",
          "Modificar",
              typeof(Comandos),
           new InputGestureCollection() {
                 new KeyGesture(Key.M, ModifierKeys.Control)
           }
           );

        public static readonly RoutedUICommand Borrar = new RoutedUICommand
               (
           "Borrar.",
           "Borrar",
               typeof(Comandos),
            new InputGestureCollection() {
                 new KeyGesture(Key.B, ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand Guardar = new RoutedUICommand
             (
         "Guardar.",
         "Guardar",
             typeof(Comandos),
          new InputGestureCollection() {
                 new KeyGesture(Key.G, ModifierKeys.Control)
          }
          );
    }
}
