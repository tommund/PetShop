using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Animal
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [DisplayName("Age By Years:")]

        public double Age { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Portrait")]
        public string PictureName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public  virtual Category Category { get; set; }
        
    }
}
