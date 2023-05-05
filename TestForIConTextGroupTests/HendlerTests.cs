using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForIConTextGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForIConTextGroup.Tests
{
    [TestClass()]
    public class HendlerTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            Hendler hendler = new Hendler();
            var employee1 = new Employees()
            {
                Id = 1,
                FirstName = "имя1",
                LastName = "фамилия1",
                SalaryPerHour = 10,
            };
            var employee2 = new Employees()
            {
                Id = 1,
                FirstName = "имя2",
                LastName = "фамилия2",
                SalaryPerHour = 10,
            };

            hendler.ListOfEmployees.Add(employee1);
            var employee3 = hendler.Update(1, employee2);

            Assert.AreEqual(employee2.FirstName, employee3.FirstName);
            Assert.AreEqual(employee2.LastName, employee3.LastName);
            Assert.AreEqual(employee2.SalaryPerHour, employee3.SalaryPerHour);
        }
    }
}