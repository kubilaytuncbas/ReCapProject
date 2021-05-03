using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsInfoContext>, ICarDal
    {
        
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsInfoContext context=new CarsInfoContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join k in context.Colors
                             on c.ColorId equals k.ColorId
                             select new CarDetailDto {BrandId=c.BrandId,ColorId=c.ColorId,Id=c.Id,BrandName=b.BrandName,ColorName=k.ColorName,CarName=c.CarName ,DailyPrice=c.DailyPrice};
                return result.ToList();
                 
                          
            }
        }
    }
}
