using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int RentalId { get; set; }
        public int BrandId { get; set; }
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public DateTime RentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; }
    }
}
