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
    /// Lógica de interacción para NuevoCliente.xaml
    /// </summary>
    public partial class NuevoCliente : Window
    {
        CollectionViewModel cvm;
        List<provincias> listProvincias = new List<provincias>();
        public NuevoCliente(CollectionViewModel coleccion)
        {
            InitializeComponent();
            this.cvm = coleccion;
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
                    listProvincias.Add(prov);
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
                clientes objCliente = new clientes()
                {
                    dni = txtDNI.Text,
                    nombre = txtNombre.Text,
                    apellidos = txtApellidos.Text,
                    email = txtEmail.Text,
                    domicilio = txtDomicilio.Text,
                    localidad = txtLocalidad.Text,
                    provincia = listProvincias[cmbProvincia.SelectedIndex].id_provincia,
                    provincias = listProvincias[cmbProvincia.SelectedIndex]
                };

                cvm.objBD.clientes.Add(objCliente);
                cvm.ListaClientes.Add(objCliente);
                MessageBox.Show("Cliente insertado correctamente", "INSERCCION CORRECTA");
                this.Close();

            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}