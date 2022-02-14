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
    /// Lógica de interacción para NuevoPedido.xaml
    /// </summary>
    public partial class NuevoPedido : Window
    {

        private PedidoCollectionViewModel pcvm;
        private string modo;

        pedidos copiaPedido;
        pedidos ped;

        public NuevoPedido(String dni,PedidoCollectionViewModel pcvm,String modo)
        {
            InitializeComponent();
            this.pcvm = pcvm;
            this.modo = modo;
            txtDNI.Text = dni;
        }

        public NuevoPedido(String dni, PedidoCollectionViewModel pcvm, String modo, pedidos pedido)
        {
            InitializeComponent();

            ped = pedido;
            copiaPedido = (pedidos)pedido.Clone();
            this.DataContext = copiaPedido;

            this.pcvm = pcvm;
            this.modo = modo;
            txtDNI.Text = dni;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            switch (modo)
            {
                case "nuevo":
                    guardarNuevo();
                    break;

                case "modificar":
                    actualizarProperties(copiaPedido, ped);


                    System.Windows.MessageBox.Show("Pedido Modificado", "Exito");
                    this.Close();
                    break;

            }
        }

        private void actualizarProperties(pedidos pedidoOrigen, pedidos pedidoDestino)
        {
            pedidoDestino.descripcion = pedidoOrigen.descripcion;


        }



        private void guardarNuevo()
        {
            if (txtDescripcion.Text.Trim() != "")
            {
                pcvm.ListaPedidos.Add(new pedidos()
                {
                    cliente = txtDNI.Text,
                    fecha_pedido = DateTime.Now,
                    descripcion = txtDescripcion.Text,
                    fecha_entrega = null,
                    firma = null
                });

                pcvm.objBD.pedidos.Add(new pedidos()
                {
                    cliente = txtDNI.Text,
                    fecha_pedido = DateTime.Now,
                    descripcion = txtDescripcion.Text,
                    fecha_entrega = null,
                    firma = null
                });

                System.Windows.MessageBox.Show("Pedido realizado correctamente", "Exito");
                this.Close();

            }
        }
    }
}
