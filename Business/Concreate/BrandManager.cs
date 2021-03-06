using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            Brand result = _brandDal.Get(b => b.BrandId == brand.BrandId);
            if (result != null)
            {
                Console.WriteLine("Bu marka id si zaten mevcut!");
            }
            else
            {
                _brandDal.Add(brand);
                Console.WriteLine("Yeni marka eklendi!");
            }
        }

        public void Delete(Brand brand)
        {
            Brand result = _brandDal.Get(b => b.BrandId == brand.BrandId && b.BrandName == brand.BrandName);
            if (result != null)
            {
                _brandDal.Delete(brand);
                Console.WriteLine("Marka silindi!");
            }
            else
            {
                Console.WriteLine("Marka bilgileri hatalı!");
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            Brand result = _brandDal.Get(b => b.BrandId == brand.BrandId);
            if (result != null)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka güncellendi!");
            }
            else
            {
                Console.WriteLine("Marka bilgileri hatalı!");
            }
        }
    }
}
