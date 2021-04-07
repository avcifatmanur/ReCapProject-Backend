using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (rental.RentDate == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);

            }
            else if (rental.ReturnDate==null && rental.RentDate!=null)
            {
                return new ErrorResult(Messages.RentalFailed);
            }
            else
            {
                return new ErrorResult(Messages.RentalFailed);
            }
        }

        public IResult Delete(Rental rental)
        {
            Rental result = _rentalDal.Get(r => r.RentalId == rental.RentalId );
            if (result != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            else
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.GetAll(r => r.RentalId == rentalId && r.ReturnDate!=null).Any();
            if (result == true)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
                
            }
            return new ErrorDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));


        }

        public IResult Update(Rental rental)
        {
            Rental result = _rentalDal.Get(r => r.RentalId == rental.RentalId);
            if (result != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            else
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
        }
    }
}
