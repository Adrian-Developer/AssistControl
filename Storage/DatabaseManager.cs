using AssistControl.Storage.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AssistControl.Storage
{
    public interface IkeyObject
    {
        //Propiedad usada como identicador para todos los objetos de los cuales se creo una tabla
        string Key { get; set; }
    }

    public class DatabaseManager
    {
        //Intancia de mi base de datos
        SQLiteConnection database;

        public DatabaseManager()
        {
            //Para inicializar este "database" se ocupara el DependencyService para traer las instancias especificas de cada
            //platforma, esta parte de SQLite tiene una implementacion especifica por platforma por eso es que se hace uso de
            //este DependencyService.
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Student>();
        }

        //La caracteristica que tienen estos metodos es que estan usando genericos para que sin importar el tipo de objeto
        //que yo este utilizando se pueda utilizar esta misma logica.
        //Y la unica caracteristica que deben tener es que implementen la interfaz "IkeyObject", es decir que tengan definida
        //llave y que tengan un constructor sin parametros.
        public void SaveValue<T>(T value) where T : IkeyObject, new()
        {

            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();

            if (all.Count == 0)
                database.Insert(value);
            else
                database.Update(value);
        }

        public void DeleteValue<T>(T value) where T : IkeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();

            if (all.Count == 1)
                database.Delete(value);
            else
                throw new Exception("The DB doesn´t contain a entry with the specified key");
        }

        public List<TSource> GetAllItems<TSource>() where TSource : IkeyObject, new()
        {
            return database.Table<TSource>().AsEnumerable<TSource>().ToList();
        }

        public TSource GetItem<TSource>(string key) where TSource : IkeyObject, new()
        {
            var result = (from entry in database.Table<TSource>().AsEnumerable<TSource>()
                          where entry.Key == key
                          select entry).FirstOrDefault();
            return result;
        }
    }
}
