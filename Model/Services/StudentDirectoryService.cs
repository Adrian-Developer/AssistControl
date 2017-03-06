using AssistControl.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistControl
{
    public class StudentDirectoryService
    {
        //Método usado para obtener un directorio de 20 estudiantes generados de manera aleatoria.
        public static StudentDirectory LoadStudentDirectory()
        {
            //Se agregara una logica la cual permitira trabajar con la base de datos.
            DatabaseManager dbManager = new DatabaseManager();
            //Obtenemos todos los estudiantes que esten almacenados localmente.
            ObservableCollection<Student> students = new ObservableCollection<Student>(dbManager.GetAllItems<Student>());
            StudentDirectory studentDirectory = new StudentDirectory();
            //Validar si la lista "Students" contienen algun elemento
            if (students.Any())
            {
                studentDirectory.Students = students;
                return studentDirectory;
            }

            //En caso de que no haya estudiantes almacenados localmente, generarlos aleatoriamente y almacenarlos
            students = new ObservableCollection<Student>();
            string[] names = { "José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio", "Sofía", "Camila", "Valentina",
            "Isabella","Ximena" };
            string[] lastNames = { "Hernández", "García", "Martínez", "López", "González" };

            Random rdm = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 20; i++)
            {
                Student student = new Student();
                student.Name = names[rdm.Next(0, 9)];
                student.LastName = $"{lastNames[rdm.Next(0, 5)]} {lastNames[rdm.Next(0, 5)]}";
                string group = rdm.Next(456, 458).ToString();
                student.Group = group;
                student.StudentNumber = rdm.Next(12384748, 32384748).ToString();
                student.Average = rdm.Next(100, 1000) / 10;
                student.Key = student.StudentNumber;
                students.Add(student);
                //Si es necesario crear de manera aleatoria a los estudiantes por que no hay en la base de datos, 
                //entoces hay que alamcenarlos en la tabla.
                dbManager.SaveValue<Student>(student);
            }

            studentDirectory.Students = students;
            return studentDirectory;
        }
    }
}
