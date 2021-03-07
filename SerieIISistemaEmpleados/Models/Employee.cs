using System;
using System.Collections.Generic;
using System.Text;

namespace SerieIISistemaEmpleados.Models
{
    class Employee
    {
        private string id;
        private string name;
        private string depto;
        private string salary;
        private string dpi;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Depto { get => depto; set => depto = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Dpi { get => dpi; set => dpi = value; }

        public void SetAll(string[] values)
        {
            id = values[0];
            name = values[1];
            depto = values[2];
            salary = values[3];
            dpi = values[4];
        }
        public string GetLine()
        {
            return id + "," + name + "," + depto + "," + salary + "," + dpi;
        }
    }
}
