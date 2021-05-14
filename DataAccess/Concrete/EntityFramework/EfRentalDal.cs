using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,CarsInfoContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsInfoContext context = new CarsInfoContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on  c.BrandId equals b.BrandId
                             join k in context.Colors
                             on  c.ColorId equals k.ColorId
                             join r in context.Rentals
                             on  c.Id equals r.CarId
                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId
                             join u in context.Users
                             on m.UserId equals u.Id

                             select new RentalDetailDto { CustomerId=m.CustomerId,RentalId=r.RentalId,RentDate=r.RentDate};
                return result.ToList();
            }
        }
    }
}
