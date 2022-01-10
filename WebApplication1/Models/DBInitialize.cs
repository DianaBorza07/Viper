using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models.AppDBContext;
using WebApplication1.Models;

namespace CarRental.Models
{
    public class DBInitialize
    {
        public static void Initialize(ApplicationDBContext context)
        {
            if (!context.Cars.Any())
            {
                DateTime fabricationDate1 = new DateTime(2015, 3, 3, 7, 0, 0);
                DateTime fabricationDate2 = new DateTime(2020, 1, 10, 7, 0, 0);
                DateTime fabrictaionDate3 = new DateTime(2021, 1, 11, 12, 0, 0);
                DateTime fabrictaionDate4 = new DateTime(2018, 1, 1, 12, 0, 0);
                DateTime fabrictaionDate5 = new DateTime(2020, 8, 1, 12, 0, 0);
                DateTime fabrictaionDate6 = new DateTime(2021, 10, 10, 12, 0, 0);
                var varCars = new Car[]
           {
            new Car{brand = "Ford", model = "Mustang", fabricationDate =fabricationDate1 , photoPath = "../images/2015mustang.jpg",price = 99.99f},
            new Car{brand = "Porsche" , model = "Panamera", fabricationDate = fabricationDate2, photoPath= "../images/2020panamera.jpg", price=155.00f},
            new Car{brand = "Mercedes",model ="Maybach S Line",fabricationDate= fabrictaionDate3,photoPath="../images/maybach2021.jpg",price=89.99f},
            new Car{brand = "Audi",model ="e-tron 55 quattro",fabricationDate= fabrictaionDate4,photoPath="../images/2018audieTron.jpg",price= 129.99f},
            new Car{brand = "Lexus",model ="LS",fabricationDate= fabrictaionDate5,photoPath="../images/2020lexusLS.jpg",price=200.00f},
             new Car{brand = "Maserati",model ="Quattroporte",fabricationDate= fabrictaionDate6,photoPath="../images/2021maseratiQuattroporte.jpg",price=130.00f},
           };

                foreach (Car car in varCars)
                {
                    var aux =  context.Cars.Add(car);
                    Console.WriteLine("-------------------"+aux);
                }
                context.SaveChanges();
            }

        }

    }
}
