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
using WpfEntrega.ViewModels;

namespace WpfEntrega.GestionClientes
{
    /// <summary>
    /// Lógica de interacción para ModificarCliente.xaml
    /// </summary>
    public partial class ModificarCliente : Window
    {
        private clientes cliente;
        private clientes copiacliente;
        CollectionViewModel cvm;
        public ModificarCliente(clientes cl, CollectionViewModel cvm)
        {
            InitializeComponent();
            this.cliente = cl;
            copiacliente = (clientes)cliente.Clone();
            this.DataContext = copiacliente;
            this.cvm = cvm;
            CargarProvincias();
        }

        private void CargarProvincias()
        {
            using (entregasEntities1 objBD = new entregasEntities1())
            {
                this.cmbProvincia.Items.Clear();
                var qProvincias = from p in objBD.provincias orderby p.nombre_provincia select p;
                foreach (var prov in qProvincias.ToList())
                {
                    this.cmbProvincia.Items.Add(prov.nombre_provincia);

                }
                cmbProvincia.SelectedIndex = 0;
            }
        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtDNI.Text.Trim() != "" &&
              this.txtNombre.Text.Trim() != "" &&
              this.txtApellidos.Text.Trim() != "" &&
              this.txtEmail.Text.Trim() != "" &&
              this.txtDomicilio.Text.Trim() != "" &&
              this.txtLocalidad.Text.Trim() != "" &&
              this.cmbProvincia.SelectedIndex != -1
            )
            {
                ActualizarProperties(copiacliente, cliente);

                this.Close();
                MessageBox.Show("Cliente modificado correctamente", "MODIFICACION CORRECTA");
            }
            else
            {
                MessageBox.Show("Inserte todos los campos del cliente", "MODIFICACION INCORRECTA");
            }

        }
        private void ActualizarProperties(clientes copiaCliente, clientes clienteDestino)
        {
            clienteDestino.dni = copiaCliente.dni;
            clienteDestino.nombre = copiaCliente.nombre;
            clienteDestino.apellidos = copiaCliente.apellidos;
            clienteDestino.email = copiaCliente.email;
            clienteDestino.domicilio = copiaCliente.domicilio;
            clienteDestino.localidad = copiaCliente.localidad;
            clienteDestino.provincia = copiaCliente.provincia;
   
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
