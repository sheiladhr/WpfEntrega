using EntregasWPF_JOSEPART.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace EntregasWPF_JOSEPART.viewModel
{
    public class PedidoCollectionViewModel : ObjectDataProvider,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PedidoCollection _listaPedidos = new PedidoCollection();
        public entregasEntities1 _objBD = new entregasEntities1();


        private void raisePropertyChanged()
        {
            throw new NotImplementedException();
        }

        public PedidoCollection ListaPedidos
        {
            get { return _listaPedidos; }
            set
            {
                _listaPedidos = value;
                raisePropertyChanged();
            }
        }


        public entregasEntities1 objBD
        {
            get { return _objBD; }
            set
            {
                _objBD = value;
                raisePropertyChanged();
            }
        }

       




        public PedidoCollectionViewModel()
        {
           //cargarDatos();
        }

        public PedidoCollectionViewModel(TextBlock dni)
        {
            
        }

        public void cargarDatos(string dni)
        {
            ListaPedidos.Clear();


            var qPedidos = from pedi in this.objBD.pedidos where pedi.cliente.Equals(dni)  select pedi;
            foreach (var ped in qPedidos.ToList())
            {
                ListaPedidos.Add(ped);
            }

        }
    }
}
