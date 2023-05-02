using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace TestForIConTextGroup
{
    internal class Hendler
    {
        List<Employees> ListOfEmployees = new List<Employees>();
        public void DeserializeJSON(string path)
        {
            ListOfEmployees = System.Text.Json.JsonSerializer.Deserialize<List<Employees>>(File.ReadAllText(path));
            if (ListOfEmployees == null)
            {
                throw new Exception("Файл с сотрудниками пустой");
            }
        }
        public void SerializeJSON(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                new Newtonsoft.Json.JsonSerializer().Serialize(writer, ListOfEmployees);
            }
        }
        public void Add(Employees employee)
        {
            employee.Id = ListOfEmployees.Max(x => x.Id) + 1;
            ListOfEmployees.Add(employee);
        }
        public void GetAll()
        {
            for (int i = 0; i < ListOfEmployees.Count; i++)
            {
                Console.WriteLine($"Id = {ListOfEmployees[i].Id}, FirstName = {ListOfEmployees[i].FirstName}, LastName = {ListOfEmployees[i].LastName}, SalaryPerHour = {ListOfEmployees[i].SalaryPerHour}");
            }
        }
        public Employees Get(int id)
        {
            ListOfEmployees.FirstOrDefault(x => x.Id == id);
            foreach (var employee in ListOfEmployees)
            {
                if (employee.Id == id)
                {
                    Console.WriteLine($"Id = {ListOfEmployees[id].Id}, FirstName = {ListOfEmployees[id].FirstName}, LastName = {ListOfEmployees[id].LastName}, SalaryPerHour = {ListOfEmployees[id].SalaryPerHour}");
                    return ListOfEmployees[id];
                }
            }
            Console.WriteLine("нет такого сотрудника");
            return null;
        }
        public void Update(int id, Employees Employee)
        {
            var employee = ListOfEmployees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                if (Employee.Id != 0)
                {
                    employee.Id = Employee.Id;
                }
                if(Employee.FirstName != null)
                {
                    employee.FirstName = Employee.FirstName;
                }
                if(Employee.LastName != null)
                {
                    employee.LastName = Employee.LastName;
                }
                if (Employee.SalaryPerHour != 0)
                {
                    employee.SalaryPerHour = Employee.SalaryPerHour;
                }               
            }
            else
            {
                Console.WriteLine("Такого id нет");
            }
        }
        public void Delete(int id)
        {
            foreach (var employee in ListOfEmployees)
            {
                if (employee.Id == id)
                {
                    ListOfEmployees.RemoveAll(x => x.Id == id);
                    return;
                }
            }
            Console.WriteLine("Нет такого сотрудника");
        }
    }
}
