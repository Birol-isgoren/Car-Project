using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorData;
        public ColorManager(IColorDal colorData)
        {
            _colorData = colorData;
        }
        public void Add(Color color)
        {
            _colorData.Add(color);
        }

        public void Delete(Color color)
        {
            _colorData.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorData.GetAll();
        }

        public Color GetByColor(string colorName)
        {
            return _colorData.Get(c => c.ColorName == colorName);
        }

        public Color GetById(string Id)
        {
            return _colorData.Get(c => c.ColorId == Id);
        }

        public void Update(Color color)
        {
            _colorData.Update(color);
        }

    }
}
