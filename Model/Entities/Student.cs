using AssistControl.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistControl
{
    //En esta entidad estudiante se agregar la Interfaz "IKeyObject" para que funcione con las basde de datos
    public class Student: ObservableBaseObject, IkeyObject
    {
        //Esta interfaz "IkeyObject" lo unico que require es que yo genere la siguiente propiedad con el nombre "Key".
        public string Key { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            //Para que funcione "ObservableBaseObject" hay que implementar la invocacion a "OnPropertyChange".
            //Esto se hace dentro del "set" para asegurar que cada que hay un cambio se pueda ver reflegado en la interfaz.
            set { name = value; OnPropertyChanged(); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(); }
        }

        private string group;
        public string Group
        {
            get { return group; }
            set { group = value; OnPropertyChanged(); }
        }

        private string studentNumber;
        public string StudentNumber
        {
            get { return studentNumber; }
            set { studentNumber = value; OnPropertyChanged(); }
        }

        private double average;
        public double Average
        {
            get { return average; }
            set { average = value; OnPropertyChanged(); }
        }
    }
}
