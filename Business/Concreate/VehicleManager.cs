using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(VehicleValidator))]
        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult Add(Vehicle car)
        {
            _vehicleDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult Delete(Vehicle car)
        {
            Vehicle result = _vehicleDal.Get(v => v.CarId == car.CarId && v.VehicleName == car.VehicleName);
            if (result != null)
            {
                _vehicleDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CarInvalid);
            }
        }

        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult Update(Vehicle car)
        {
            Vehicle result = _vehicleDal.Get(v => v.CarId == car.CarId);
            if (result != null)
            {
                _vehicleDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarInvalid);
            }
        }
        
        [CacheAspect]
        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_vehicleDal.GetCarDetails(c=>c.brandId==brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_vehicleDal.GetCarDetails(c=>c.colorId==colorId));
        }

        [CacheAspect]
        public IDataResult<Vehicle> GetById(int id)
        {
            return new SuccessDataResult<Vehicle>(_vehicleDal.Get(v => v.CarId == id));
        }
      
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_vehicleDal.GetCarDetails());
        }

        [TransactionScopeAspect]
        public IResult AddTransactional(Vehicle car)
        {
            _vehicleDal.Update(car);
            _vehicleDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            if (_vehicleDal.GetCarDetails(c => c.carId == id) != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_vehicleDal.GetCarDetails(c => c.carId == id), Messages.CarListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarInvalid);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_vehicleDal.GetCarDetails(c => c.brandId == brandId && c.colorId == colorId));
        }
    }
}
