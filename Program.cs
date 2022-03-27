using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static ConsoleApp1.datamodal;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Logic

            var cus = new customer();
            cus.firstname = "John";
            cus.age = 3;
            //วิธีที่ 1 extension
            employee emp = new employee
            {
                firstname = cus.firstname,
                age = cus.age
            };
            //วิธีที่ 2 ฟังชั้น
            employee emp2 = cus.Cast<employee>();

            //วิธีที่ 3 partial class
            employee emp3 = (employee)cus;

            //วิธีที่ 4 แปลงตรง ๆ
            employee emp4 = JsonConvert.DeserializeObject<employee>(JsonConvert.SerializeObject(cus));


            //วิธีที่ 5 ฟังชั้น
            employee emp5 = utility.ConvertClass<employee>(cus);

            //วิธีที่ 6 ฟังชั้น
            employee emp6 = utility.ConvertGlobloClass<employee>(cus);

            //วิธีที่ 7 ฟังชั้น
            employee emp7 = cus.ConvertGlobloClass<employee>();


            Console.WriteLine(emp);
            Console.WriteLine("emp2 => {0} " + emp2);
            Console.WriteLine("emp3 => {0} " + emp3);


            #endregion

            Console.ReadLine();
        }


    }
}
