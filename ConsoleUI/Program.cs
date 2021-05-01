using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " --------Günlük kira bedeli:" + car.DailyPrice);
            }
            Console.WriteLine();
            Console.WriteLine("----------ID'ye GÖRE LİSTELEME----------");
            Console.WriteLine();
            foreach (var car in carManager.GetByCarId(1))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine();
            Console.WriteLine("----------RENGE GÖRE LİSTELEME----------");
            Console.WriteLine();
            foreach (var car in carManager.GetCarByColorId("1"))
            {
                Console.WriteLine(car.CarId + " no'lu ID ye sahip araç Siyah renktir.");
            }
            Console.WriteLine();
            Console.WriteLine("----------MARKAYA GÖRE LİSTELEME----------");
            Console.WriteLine();

            foreach (var car in carManager.GetCarByBrandId("1"))
            {
                Console.WriteLine(car.BrandId + " Marka ID'li araç--- " + car.Description);
            }
            //Console.WriteLine();
            //Console.WriteLine("----------YENİ ARAÇ EKLEME----------");
            //Console.WriteLine();
            //EfCarDal efCarDal = new EfCarDal();

            //efCarDal.Add(new Entities.Concrete.Car { BrandId = "1", ColorId = "2", ModelYear = 2014, DailyPrice = 10000, Description = "Golf" });
            //efCarDal.Add(new Entities.Concrete.Car { BrandId = "1", ColorId = "4", ModelYear = 2015, DailyPrice = 11000, Description = "Polo" });
            //efCarDal.Add(new Entities.Concrete.Car { BrandId = "2", ColorId = "1", ModelYear = 2016, DailyPrice = 12000, Description = "A3" });
            //efCarDal.Add(new Entities.Concrete.Car { BrandId = "3", ColorId = "5", ModelYear = 2017, DailyPrice = 14000, Description = "A180" });
        }
    }
}
