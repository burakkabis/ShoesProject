
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Shoe:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string ShoeName { get; set; }
        public int ShoeNo { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
        public string Description { get; set; }




    }
}
