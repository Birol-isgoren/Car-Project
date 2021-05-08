using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDbContext db = new CarDbContext())
            {
                var result = from car in db.Car
                             join brand in db.Brand
                             on car.BrandId equals brand.BrandId
                             join color in db.Color
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 CarName = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
