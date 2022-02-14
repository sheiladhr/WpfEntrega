using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfEntrega.Models;

namespace WpfEntrega.ViewModels
{
    public class CollectionViewModel : INotifyPropertyChanged
    {
        private entregasEntities1 _objBD = new entregasEntities1();
        private ClienteCollection _listaClientes = new ClienteCollection();


        public event PropertyChangedEventHandler PropertyChanged;
        private void notificarPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public ClienteCollection ListaClientes
        {
            get { return _listaClientes; }
            set
            {
                _listaClientes = value;
                notificarPropertyChanged();
            }
        }

        public entregasEntities1 objBD
        {
            get { return _objBD; }
            set
            {
                _objBD = value;
                notificarPropertyChanged();
            }
        }
        public void GuardarDatos()
        {
            objBD.SaveChanges();
        }

        public CollectionViewModel()
        {
            CargarDatos();

        }

        private void CargarDatos()
        {
            ListaClientes.Clear();

            var qClientes = from c in objBD.clientes orderby c.nombre select c;
            foreach (var client in qClientes.ToList())
            {
                ListaClientes.Add(client);
            }

        }

    }
}


