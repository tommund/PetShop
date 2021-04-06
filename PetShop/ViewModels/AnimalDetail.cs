using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.ViewModels
{
    public class AnimalDetail
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string Description { get; set; }
        [DisplayName("category name:")]
        public string CategoryName { get; set; }

        [MinLength(1)]
        [Required]
        [DisplayName("comment to add:")]
        public string CommentToAdd { get; set; }

        [DisplayName("list of comments: ")]
        public List<string> CommentsText{ get; set; }
    }
}
