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

        public IDataResult<List<Vehicle>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Vehicle>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(c => c.ColorId == id));
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
    }
}
