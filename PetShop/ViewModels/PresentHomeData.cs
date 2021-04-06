using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.ViewModels
{
    public class PresentHomeData
    {
        public PresentHomeData(string imagePath, string animalName, int commentCount, string animalDescription)
        {
            ImagePath = imagePath;
            AnimalName = animalName;
            CommentCount = commentCount;
            AnimalDescription = animalDescription;
        }
        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [DisplayName("Name")]
        public string AnimalName { get; set; }

        [DisplayName("number of comments")]
        public int  CommentCount { get; set; }

        [DisplayName("Description")]
        public string AnimalDescription { get; set; }
    }
}
