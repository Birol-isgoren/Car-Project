using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carData;

        public CarManager(ICarDal carData)
        {
            _carData = carData;
        }

        public void Add(Car car)
        {
            _carData.Add(car);
        }

        public void Delete(Car car)
        {
            _carData.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carData.GetAll();
        }

        public List<Car> GetByCarId(int id)
        {
            return _carData.GetAll(c => c.CarId == id);
        }

        public List<Car> GetCarByBrandId(string id)
        {
            return _carData.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarByColorId(string id)
        {
            return _carData.GetAll(c => c.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carData.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carData.Update(car);
        }
    }
}
