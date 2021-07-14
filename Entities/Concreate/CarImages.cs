using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concreate
{
    public class CarImages:IEntity
    {
        public CarImages()
        {
            Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }

    }
}
