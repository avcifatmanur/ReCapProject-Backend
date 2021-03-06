using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int carId { get; set; }
        public string carName { get; set; }
        public string brandName { get; set; }
        public string colorName { get; set; }
        public decimal DailyPrice { get; set; }

    }
}
