using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }

        [Required(ErrorMessage =" please enter a comment")]
        [StringLength(50)]
        public string CommentText { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
