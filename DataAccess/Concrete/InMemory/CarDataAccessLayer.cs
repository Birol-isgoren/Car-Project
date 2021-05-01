using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class CarDataAccessLayer : ICarDataAccessLayer
    {
        List<Car> _cars;
        public CarDataAccessLayer()
        {
            _cars = new List<Car> {
                new Car{CarId=1,BrandId="MERC1",ColorId="RED1",DailyPrice=150,ModelYear=2015,Description="MERCEDES C180" },
             new Car{CarId=2,BrandId="MERC2",ColorId="BLK1",DailyPrice=2300,ModelYear=2019,Description="MERCEDES C63 AMG" },
             new Car{CarId=3,BrandId="AUDI1",ColorId="BL1",DailyPrice=250,ModelYear=2017,Description="AUDI A6" },
             new Car{CarId=4,BrandId="BMW1",ColorId="BLK1",DailyPrice=300,ModelYear=2015,Description="BMW F30" },
             new Car{CarId=5,BrandId="AUDI2",ColorId="WH1",DailyPrice=3000,ModelYear=2021,Description="AUDI RS6" }};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carID)
        {
            return _cars.Where(c => c.CarId ==carID).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
