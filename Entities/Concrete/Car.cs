using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : ICar
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
