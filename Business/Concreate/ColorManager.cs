using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result!=null)
            {
                return new ErrorResult(Messages.ColorAvailable);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }             
        }

        public IResult Delete(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId && c.ColorName == color.ColorName);
            if (result != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            else
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result != null)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
        }
    }
}
