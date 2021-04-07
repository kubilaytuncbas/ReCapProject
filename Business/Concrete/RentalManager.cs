using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Silindi");
        }

        public DataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, "asdasdas");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Uptade(rental);
            return new SuccessResult();
        }
        public DataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new DataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), true, "fasfjafkajfa");
        }
    }
}
