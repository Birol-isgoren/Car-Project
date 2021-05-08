using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandData;
        public BrandManager(IBrandDal brandData)
        {
            _brandData = brandData;
        }
        public void Add(Brand brand)
        {
            _brandData.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandData.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandData.GetAll();
        }

        public Brand GetByBrand(string brandName)
        {
            return _brandData.Get(b => b.BrandName == brandName);
        }

        public Brand GetById(string Id)
        {
            return _brandData.Get(b => b.BrandId == Id);
        }

        public void Update(Brand brand)
        {
            _brandData.Update(brand);
        }
    }
}
