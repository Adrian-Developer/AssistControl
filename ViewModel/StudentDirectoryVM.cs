using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AssistControl
{
    //Esta clase tambien hereda de "ObservableBaseObject" ya que tambien tiene que informar de los cambios.
    public class StudentDirectoryVM: ObservableBaseObject
    {
        //Propiedad usada para mostrar el listado de estudiantes en pantalla.
        //En caso de la coleccion "Students" no es necesario que se coloque el "OnPropertyChanged()" porque el 
        //"ObservableCollection", ya esta listo para informar a los elementos que controlan colecciones cuando haya un 
        //cambio referente a que se agrego un elemento o se quito un elemento.
        public ObservableCollection<Student> Students { get; set; }

        bool isBusy = false;
        //Propiedad que tendra la funcionalidad de que se este ejecutando al mismo tiempo una acción.
        //Segunda funcionalidad: Conectarse a la interfaz de usuario para mostrar un indicador de actividad en pantalla.
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        //Los comandos van a funcionar para conectarse a algunos elementos de las interfaz de usuario que lo permiten(Button).
        public Command LoadDirectoryCommand { get; set; }

        public StudentDirectoryVM()
        {
            Students = new ObservableCollection<Student>();
            IsBusy = false;
            //La nueva instancia de Command espera como parámetro la acción que debe ejecutar.
            LoadDirectoryCommand = new Command((obj) => LoadDirectory());
        }

        async void LoadDirectory()
        {
            //Evaluar que no este ocupada la aplicación.
            if (!IsBusy)
            {
                IsBusy = true;
                //Simulación de una transacción con el servidor.
                await Task.Delay(3000);
                //Generar un directorio nuevo de estudiantes.
                var loadedDirectory = StudentDirectoryService.LoadStudentDirectory();
                //Para cada uno de los estudiantes del directorio generado...
                foreach (var student in loadedDirectory.Students)
                {
                    //...agregarlos al directio que esta en esta clase.
                    Students.Add(student);
                }
                IsBusy = false;
            }
        }
    }
}
