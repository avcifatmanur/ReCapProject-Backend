using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result!=null)
            {
                Console.WriteLine("Bu renk zaten mevcut!");
            }
            else
            {
                _colorDal.Add(color);
                Console.WriteLine("Yeni renk eklendi!");
            }             
        }

        public void Delete(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId && c.ColorName == color.ColorName);
            if (result != null)
            {
                _colorDal.Delete(color);
                Console.WriteLine("Renk silindi!");
            }
            else
            {
                Console.WriteLine("Renk bilgileri hatalı!");
            }
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }

        public void Update(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result != null)
            {
                _colorDal.Update(color);
                Console.WriteLine("Renk güncellendi!");
            }
            else
            {
                Console.WriteLine("Böyle bir renk yok!");
            }
        }
    }
}
