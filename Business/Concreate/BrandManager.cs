﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            Brand result = _brandDal.Get(b => b.BrandId == brand.BrandId);
            if (result != null)
            {
                return new ErrorResult(Messages.BrandAvailable);
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        
        public IResult Delete(Brand brand)
        {
            Brand result = _brandDal.Get(b => b.BrandId == brand.BrandId && b.BrandName == brand.BrandName);
            if (result != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            else
            {
                return new ErrorResult(Messages.BrandInvalid);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

       
        public IResult Update(Brand brand)
        {
            Brand result = _brandDal.Get(b => b.BrandId == brand.BrandId);
            if (result != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            else 
            {
                return new ErrorResult(Messages.BrandInvalid);
            }
        }
    }
}
