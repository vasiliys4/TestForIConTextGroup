using System.Collections;
using System.Collections.Generic;
using TestForIConTextGroup;

internal class Program
{
    private static void Main(string[] args)
    {
        string? Path = Console.ReadLine();
        if (Path[0] == '"') 
        {
            Path = Path.Trim(new char[] { '"' });
        }
        Hendler hendler = new Hendler();
        hendler.DeserializeJSON(Path);
        string[] operations = GetComands(args).ToArray();
        for (int i = 0; i < operations.Length; i++)
        {
            switch (operations[i])
            {
                case "-add":
                    hendler.Add(GetByValue(args));
                    hendler.SerializeJSON(Path);
                    break;
                case "-update":
                    hendler.Update(Convert.ToInt32(args[1].Split(':')[1]), GetByValue(args));
                    hendler.SerializeJSON(Path);
                    break;
                case "-get":
                    hendler.Get(GetingId(args));
                    break;
                case "-delete":
                    hendler.Delete(GetingId(args));
                    hendler.SerializeJSON(Path);
                    break;
                case "-getall":
                    hendler.GetAll();
                    break;
            }
        }
    }
    private static Queue<string> GetComands(string[] args)
    {
        var list = new Queue<string>();
        string[] operations = { "-add", "-get", "-getall", "-update", "-delete" };
        foreach (string arg in args)
        {
            foreach (string operation in operations)
            {
                if (arg == operation)
                {
                    list.Enqueue(operation);
                }
            }
        }
        return list;
    }
    private static Employees GetByValue(string[] args)
    {
        Employees employee = new Employees();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Split(":")[0] == "Id")
            {
                employee.Id = Convert.ToInt32(args[i].Split(":")[1]);
            }
            else if (args[i].Split(":")[0] == "FirstName")
            {               
                employee.FirstName = args[i].Split(":")[1];
            }
            else if (args[i].Split(":")[0] == "LastName")
            {
                employee.LastName = args[i].Split(":")[1];
            }
            else if (args[i].Split(":")[0] == "Salary")
            {
                string valueStr = args[i].Split(":")[1];
                valueStr = valueStr.Replace(".", ",");
                if (valueStr[valueStr.Length - 1] == ',')
                {
                    valueStr = valueStr.Remove(valueStr.Length - 1);
                }
                employee.SalaryPerHour = Convert.ToDecimal(valueStr);
            }
        }
        return employee;
    }
    private static int GetingId(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Split(':')[0] == "Id")
            {
                string number = args[i].Split(':')[1];
                int id = int.Parse(number);
                return id;
            }
        }
        return 0;
    }
}