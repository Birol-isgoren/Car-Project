using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarByBrandId(string id);
        List<Car> GetCarByColorId(string id);
        List<Car> GetByCarId(int id);
    }
}
