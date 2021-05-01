using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDataAccessLayer _carData;

        public CarManager(ICarDataAccessLayer carData)
        {
            _carData = carData;
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
    }
}
