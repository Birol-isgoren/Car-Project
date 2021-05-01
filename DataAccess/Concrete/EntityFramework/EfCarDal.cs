using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDataAccessLayer
    {
        public void Add(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                if (entity.Description.Length>=2 && entity.DailyPrice>0)
                {
                    var addedCar = context.Entry(entity);
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                    Console.WriteLine("Araba Eklendi.");
                }
                else
                {
                    Console.WriteLine("Sisteme yeni araba ekleyebilmek için Arabanın açıklaması 2 veya daha uzun olmalı, günlük fiyatı 0 dan büyük olmalıdır.");
                }
              
            }
        }

        public void Delete(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
                Console.WriteLine("Araç silindi.");
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
