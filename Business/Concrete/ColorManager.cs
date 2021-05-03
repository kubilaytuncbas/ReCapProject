using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
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

            _colorDal.Add(color);
            return new Result(true,"Renk Başarıyla eklendi");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, "Renk Başarıyla silindi");
        }

       

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, "Renk Başarıyla güncellendi");
        }

        IDataResult<List<Color>> IColorService.GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
    }
}
