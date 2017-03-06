using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssistControl
{
    //Clase base de la cual tienen que heredar todos los que requieran implementar esta interfaz. 
    public class ObservableBaseObject : INotifyPropertyChanged
    {
        //Esta propiedad sera un delagado
        public event PropertyChangedEventHandler PropertyChanged = delegate {

        };

        //Recibira como parametro el nombre de la propiedad que cambio.
        //Funcionalidad del CallerMembreName es que cuando sea invocado el metodo de manera automatica obtendra el
        //nombre del propiedad que lo invoco.
        public void OnPropertyChanged([CallerMemberName] string name="")
        {
            if (PropertyChanged == null)
                return;

            //Propiedad sender: Esta clase.
            //Los argumentos: El nombre de la propiedad que cambio.
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
