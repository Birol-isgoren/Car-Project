using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            GetAllCars(carManager);
            //GetCarById(carManager,1002);
            //GetAllCars(carManager);
            //GetCarsByColor(carManager);
            //GetCarsByBrand(carManager);
            //AddCar(carManager);

            //GetAllColors();
            //GetallBrands();
            //AddColor();
            GetCarsDetails(carManager);

        }

        private static void GetCarsDetails(CarManager carManager)
        {
            foreach (var carDetails in carManager.GetCarDetails())
            {
                Console.WriteLine(string.Format("CarName {0} BrandName {1} ColorName {2} DailyPrice {3}", carDetails.CarName, carDetails.BrandName, carDetails.ColorName, carDetails.DailyPrice));
            }
        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = "5", ColorName = "Kırmızı" });
        }

        private static void GetallBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Id " + brand.BrandId + " Name " + brand.BrandName);
            }
        }

        private static void GetAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Id " + color.ColorId + " Name " + color.ColorName);
            }
        }

        private static void DeleteCar(CarManager carManager, Car car)
        {
            carManager.Delete(car);
        }

        private static void AddCar(CarManager carManager)
        {
            Console.WriteLine();
            Console.WriteLine("----------YENİ ARAÇ EKLEME----------");
            Console.WriteLine();

            carManager.Add(new Car { BrandId = "1", ColorId = "2", ModelYear = 2018, DailyPrice = 10000, Description = "Passat" });
        }

        private static void GetCarsByBrand(CarManager carManager)
        {
            Console.WriteLine();
            Console.WriteLine("----------MARKAYA GÖRE LİSTELEME----------");
            Console.WriteLine();

            foreach (var car in carManager.GetCarByBrandId("1"))
            {
                Console.WriteLine(car.BrandId + " Marka ID'li araç--- " + car.Description);
            }
        }

        private static void GetCarsByColor(CarManager carManager)
        {
            Console.WriteLine();
            Console.WriteLine("----------RENGE GÖRE LİSTELEME----------");
            Console.WriteLine();
            foreach (var car in carManager.GetCarByColorId("1"))
            {
                Console.WriteLine(car.CarId + " no'lu ID ye sahip araç Siyah renktir.");
            }
        }

        private static void GetCarById(CarManager carManager, int carId)
        {
            Console.WriteLine();
            Console.WriteLine("----------ID'ye GÖRE LİSTELEME----------");
            Console.WriteLine();
            foreach (var car in carManager.GetByCarId(carId))
            {
                Console.WriteLine(car.Description);
                DeleteCar(carManager,car);
            }

        }

        private static void GetAllCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " --------Günlük kira bedeli:" + car.DailyPrice + car.ToString());
            }
        }
    }
}
