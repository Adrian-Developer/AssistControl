using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AssistControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //A la propiedad "BindingContext" se le asiganara una nueva instancia del View Model "StudentDirectoryVM" que
            //sera el contexto de datos con el cual trabajara esta pagina.
            this.BindingContext = new StudentDirectoryVM();
            lvStudents.ItemSelected += LvStudents_ItemSelected;
        }

        private void LvStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Obtenemos el estudiante seleccionado
            Student selectedStudent = (Student)e.SelectedItem;
            //Verificamos que sea nulo
            if (selectedStudent == null)
                return;
            //Navegamos a "StudentDetailPage" pasando como argumento al estudiante seleccionado.
            //Para evitar excepciones al momento de navegar es neceario modificar el archivo "App.xaml.cs"
            Navigation.PushAsync(new StudentDetailPage(selectedStudent));
            lvStudents.SelectedItem = null;
        }
    }
}
