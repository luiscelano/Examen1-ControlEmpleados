using System;
using System.Collections.Generic;
using System.Linq;
using SerieIISistemaEmpleados.Controllers;
using SerieIISistemaEmpleados.Models;
namespace SerieIISistemaEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo opt;
            do
            {
                ShowMenu();
                opt = Console.ReadKey();
                switch (opt.Key)
                {
                    case ConsoleKey.NumPad1: 
                    case ConsoleKey.D1:
                        CreateNewFile();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        CreateNewEmployee();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        ListAllEmployees();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("VUELVA PRONTO!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("ESTA OPCIÓN NO EXISTE, INTENTE DE NUEVO!!");
                        Console.ReadKey();
                        break;

                }
            } while (!opt.Key.Equals(ConsoleKey.Escape));
        }
        static void ShowMenu()
        {
            //menu
            CenterText("CONTROL DE EMPLEADOS");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Curso: PROGRAMACIÓN I");
            Console.WriteLine("Nombre: Luis Eduardo Alvarado Celano");
            Console.WriteLine("Carnet: 0900-20-7376");
            Console.WriteLine("Sección: C");
            Console.WriteLine("\n");
            CenterText("-------------------------------------");
            CenterText("MENÚ PRINCIPAL");
            CenterText("-------------------------------------");
            CenterLeftText("(1). CREAR ARCHIVO PARA EMPLEADOS");
            CenterLeftText("(2). AGREGAR NUEVO EMPLEADO");
            CenterLeftText("(3). VER EMPLEADOS REGISTRADOS");
            CenterLeftText("(Esc). SALIR DEL SISTEMA");
            CenterText("-------------------------------------");
            CenterText("ELIJA EL NÚMERO DE OPCIÓN [ ]");
            CenterText("-------------------------------------");

        }
        static void CreateNewFile()
        {
            EmployeeControllers controllers = new EmployeeControllers();
            string path;
            Console.Clear();
            CenterText("CREAR UN ARCHIVO");
            Console.SetCursorPosition(20, 10); Console.WriteLine("PATH DEL ARCHIVO:   [____________________________________________]");
            Console.SetCursorPosition(52, 10);
            path = Console.ReadLine();
            try
            {
                controllers.CreateFile(path);
                Console.SetCursorPosition(5, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 15); Console.WriteLine("ARCHIVO REGISTRADO CORRECTAMENTE");
                Console.SetCursorPosition(5, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.SetCursorPosition(5, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 15); Console.WriteLine("ERROR AL CREAR ARCHIVO: " + e.Message);
                Console.SetCursorPosition(5, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void ListAllEmployees()
        {
            Console.Clear();
            CenterText("LISTADO DE EMPLEADOS");
            try {
                EmployeeControllers controllers = new EmployeeControllers();
                List<Employee> employees = controllers.FetchEmployees();
                if (employees.Count == 0) throw new Exception("NO HAY EMPLEADOS REGISTRADOS");
                Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 6); Console.WriteLine("NO. EMPLEADO");
                Console.SetCursorPosition(20, 6); Console.WriteLine("NOMBRE");
                Console.SetCursorPosition(40, 6); Console.WriteLine("DEPARTAMENTO");
                Console.SetCursorPosition(60, 6); Console.WriteLine("SALARIO");
                Console.SetCursorPosition(80, 6); Console.WriteLine("DPI");
                Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 8);
                int curPos = 9;
                foreach (Employee employee in employees)
                {
                    Console.SetCursorPosition(5, curPos); Console.WriteLine(employee.Id);
                    Console.SetCursorPosition(20, curPos); Console.WriteLine(employee.Name);
                    Console.SetCursorPosition(40, curPos); Console.WriteLine(employee.Depto);
                    Console.SetCursorPosition(60, curPos); Console.WriteLine(employee.Salary);
                    Console.SetCursorPosition(80, curPos); Console.WriteLine(employee.Dpi);
                    curPos++;
                }
                Console.SetCursorPosition(5, curPos); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void CreateNewEmployee()
        {
            ConsoleKeyInfo opt;
            EmployeeControllers controllers = new EmployeeControllers();
            Employee employee = new Employee();
            Console.Clear();
            CenterText("INFORMACIÓN A COMPLETAR DEL EMPLEADO");
            try
            {
                Console.SetCursorPosition(20, 7); Console.WriteLine("---------------------------------------------------------------------");
                Console.SetCursorPosition(20, 8); Console.WriteLine("DATOS GENERALES");
                Console.SetCursorPosition(20, 9); Console.WriteLine("---------------------------------------------------------------------");
                Console.SetCursorPosition(20, 10); Console.WriteLine("NO. EMPLEADO:       [____________________________________________]");
                Console.SetCursorPosition(52, 10);
                employee.Id = Console.ReadLine();
                Console.SetCursorPosition(20, 11); Console.WriteLine("NOMBRE DEL EMPLEADO:   [____________________________________________]");
                Console.SetCursorPosition(52, 11);
                employee.Name = Console.ReadLine();
                Console.SetCursorPosition(20, 12); Console.WriteLine("DEPARTAMENTO:[____________________________________________]");
                Console.SetCursorPosition(52, 12);
                employee.Depto = Console.ReadLine();
                Console.SetCursorPosition(20, 13); Console.WriteLine("SALARIO:     [____________________________________________]");
                Console.SetCursorPosition(52, 13);
                employee.Salary = Console.ReadLine();
                Console.SetCursorPosition(20, 13); Console.WriteLine("DPI:     [____________________________________________]");
                Console.SetCursorPosition(52, 13);
                employee.Dpi = Console.ReadLine();
                controllers.CreateEmployee(employee);
                Console.SetCursorPosition(5, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 15); Console.WriteLine("EMPLEADO INGRESADO CORRECTAMENTE");
                Console.SetCursorPosition(5, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 17);Console.WriteLine("DESEAS AGREGAR OTRO EMPLEADO?(S/N) [ ]");
                Console.SetCursorPosition(41, 17);
                opt = Console.ReadKey(true);
                AskAgain(opt);
            }
            catch(Exception e)
            {
                Console.SetCursorPosition(5, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 15); Console.WriteLine("ERROR AL CREAR EMPLEADO: "+e.Message);
                Console.SetCursorPosition(5, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void AskAgain(ConsoleKeyInfo opt)
        {
            switch (opt.Key)
            {
                case ConsoleKey.S:
                    CreateNewEmployee();
                    break;
                case ConsoleKey.N:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("ESA OPCIÓN NO ESTÁ DISPONIBLE");
                    Console.SetCursorPosition(5, 17); Console.WriteLine("DESEAS AGREGAR OTRO EMPLEADO?(S/N) [ ]");
                    Console.SetCursorPosition(41, 17);
                    opt = Console.ReadKey(true);
                    AskAgain(opt);
                    break;
            }
        }
        static void CenterLeftText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + text.Length - 15) + "}", text));
        }
        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
    }
}
