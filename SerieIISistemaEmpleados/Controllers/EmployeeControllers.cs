using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace SerieIISistemaEmpleados.Controllers
{
    class EmployeeControllers
    {
        static string configFolder = "C:\\Users\\" + Environment.UserName + "\\EmployeeApp";
        static string configFilename = "\\config.txt";
        static string configPath = configFolder + configFilename;
        public void CreateFile(string path)
        {
            if (File.Exists(path)) throw new Exception("Ya existe un archivo con este directorio");
            if(!Directory.Exists(configFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(configFolder);
            }
            if (!File.Exists(configPath))
            {
                using var file = File.Create(configPath);
                file.Close();
            }
            using var nfile = File.Create(path);
            nfile.Close();
            using StreamWriter sr = File.CreateText(configPath);
            sr.Write(path);
            sr.Close();
            return;
        }
        public void CreateEmployee(Models.Employee Employee)
        {
            string path = GetDataDirectory();
            if (path == null || path == "") throw new Exception("No has creado un archivo para almacenar tu información aún");
            if (!File.Exists(path))
            {
                using StreamWriter stream = File.CreateText(path);
                stream.WriteLine(Employee.GetLine());
                stream.Close();
            }
            else
            {
                using StreamWriter stream = File.AppendText(path);
                stream.WriteLine(Employee.GetLine());
                stream.Close();
            }
        }
        public static string GetDataDirectory()
        {
            string path = null;
            if (!Directory.Exists(configFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(configFolder);
            }
            if (!File.Exists(configPath))
            {
                using var file = File.Create(configPath);
                file.Close();
            }
            using StreamReader sr = File.OpenText(configPath);
            string line = "";
            while ((line = sr.ReadLine()) != null) path = line;
            sr.Close();
            return path;
        }
        public List<Models.Employee> FetchEmployees()
        {
            List<Models.Employee> Employees = new List<Models.Employee>();
            string path = GetDataDirectory();
            if (!File.Exists(path)) throw new Exception("No existe un listado de empleados aún");
            foreach(string Employee in File.ReadAllLines(path))
            {
                Models.Employee model = new Models.Employee();
                string[] delimitedField = Employee.Split(",");
                if (delimitedField.Length != 5) throw new Exception("No hemos encontrado ningún registro");
                model.SetAll(delimitedField);
                Employees.Add(model);
            }
            return Employees;
        }

    }
}
