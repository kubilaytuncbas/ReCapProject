using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result=rentalManager.Add(new Rental {CustomerId=1,CarId=1,RentDate=DateTime.Now,ReturnDate=new DateTime(2021,4,8) });
            //Console.WriteLine(result.Message);
            //UserManager userManager = new UserManager(new EfUserDal());
            //var result2 =userManager.Add(new User {FirstName="Kubilay",LastName="Tuncbas",Email="tuncbaskubilay@gmail.com",Password="123456Kk.."});
            //Console.WriteLine(result2.Message);
            var result3=carManager.GetCarDetails();
            Console.WriteLine(result3.Message);

            
            
            


          
            
        }
    }
}
