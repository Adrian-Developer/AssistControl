using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AssistControl.Storage.Interfaces;
using SQLite;
using System.IO;
using Xamarin.Forms;
using AssistControl.Droid.Storage.Implementations;

//Para ser utilizado por el Dependency Service es necesario registrarlo.
//Tengo que decirle que sera una dependencia y el tipo de dato que esta usando.
[assembly:Dependency(typeof(SQLiteDroid))]
namespace AssistControl.Droid.Storage.Implementations
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteDroid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            //Inicializar SQLite, este metodo sirve para hacer una inicailizacion interna con base en plataforma en la que se
            //esta ejecutando
            SQLitePCL.Batteries.Init();
            //Asignar el nombre de la base de datos
            var sqliteFileName = "TodoSQLite.db3";
            //La ruta en el que se va a guardar la basde de datos, Documents folder
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            //Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            //Return the database connection
            return conn;
        }
    }
}