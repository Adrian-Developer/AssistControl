using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistControl
{
    public class StudentDirectory: ObservableBaseObject
    {
        //Coleción de estudiantes
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { students = value; OnPropertyChanged(); }
        }
    }
}
