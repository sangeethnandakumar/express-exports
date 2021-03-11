using ExpressData;
using System;
using System.Collections.Generic;

namespace ExpressExportsDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var test = new List<Student>();
            test.Add(new Student
            {
                Name = "Sangeeth",
                Session = Guid.NewGuid(),
                StudentId = 1,
                DOB = DateTime.Now,
                Students = new Student
                {
                    Name = "Sangeeth",
                    Session = Guid.NewGuid(),
                    StudentId = 1,
                    DOB = DateTime.Now
                }
            });
            test.Add(new Student
            {
                Name = "Rahul",
                Session = Guid.NewGuid(),
                StudentId = 1,
                DOB = DateTime.Now
            });
            test.Add(new Student
            {
                Name = "Abhishek",
                Session = Guid.NewGuid(),
                StudentId = 1,
                DOB = DateTime.Now,
                Students = new Student
                {
                    Name = "Sangeeth",
                    Session = Guid.NewGuid(),
                    StudentId = 1,
                    DOB = DateTime.Now
                }
            });
            test.Add(new Student
            {
                Name = "Shashikant",
                Session = Guid.NewGuid(),
                StudentId = 1,
                DOB = DateTime.Now
            });

            //Serialize data to XML
            var metaInfo = new List<Meta>();
            metaInfo.Add(new Meta("Portability", "Tender"));
            metaInfo.Add(new Meta("Expiry", "13"));
            metaInfo.Add(new Meta("RidgeBackPolicy", "A2031"));
            var xml = DataRacks.Export<List<Student>>(test, metaInfo);
            //Save XML to file
            DataRacks.DataRackXMLToFile<List<Student>>(xml, @"C:\TURBOC3");
            //Import XML to object
            var result = DataRacks.Import<List<Student>>(xml);
        }
    }
}