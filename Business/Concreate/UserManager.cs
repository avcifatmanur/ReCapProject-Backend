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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            User result = _userDal.Get(u => u.UserId == user.UserId);
            if (result != null)
            {
                return new ErrorResult(Messages.UserAvailable);
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User user)
        {
            User result = _userDal.Get(u => u.UserId == user.UserId);
            if (result != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            else
            {
                return new ErrorResult(Messages.UserInvalid);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            User result = _userDal.Get(u => u.UserId == user.UserId);
            if (result != null)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            else
            {
                return new ErrorResult(Messages.UserInvalid);
            }
        }
    }
}
