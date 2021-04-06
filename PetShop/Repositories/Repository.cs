using PetShop.Data;
using PetShop.Models;
using PetShop.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Repositories
{
    public class Repository : IRepository
    {
        private PetsContext _myPetsContext;


        public Repository(PetsContext myPetsContext)
        {
            _myPetsContext = myPetsContext;
        }

        public IEnumerable<PresentHomeData> GetTopCommentedAnimals(int amountOfAnimals)
        {

            int countDataToPresent = 0;

            var AnimalIdAndNumComments = _myPetsContext.Comments.GroupBy(c => c.AnimalId)
                                               .Select(c => new { animalId = c.Key, countedComment = c.Count() })
                                               .OrderByDescending(c => c.countedComment)
                                               .ToList();

            List<PresentHomeData> dataForMainPage = new List<PresentHomeData>();

            for (int i = 0; i < AnimalIdAndNumComments.Count; i++)
            {
                if (countDataToPresent >= amountOfAnimals) break;
                var animal = _myPetsContext.Animals.Where(a => a.Id.Equals(AnimalIdAndNumComments[i].animalId))
                                                      .Select(a => a).SingleOrDefault();

                dataForMainPage.Add(new PresentHomeData(animal.PictureName, animal.Name, AnimalIdAndNumComments[i].countedComment, animal.Description));
                countDataToPresent++;
            }

            foreach (var item in _myPetsContext.Animals)
            {
                if (countDataToPresent >= amountOfAnimals) break;
                
                if (!AnimalIdAndNumComments.Exists(x => x.animalId.Equals(item.Id)))
                {
                    countDataToPresent++;
                    dataForMainPage.Add(new PresentHomeData(item.PictureName, item.Name, 0, item.Description));
                }
            }

            return dataForMainPage.OrderByDescending(c => c.CommentCount)
                   .Select(data => data).Take(amountOfAnimals);
        }

        public IEnumerable<Animal> GetAnimalsByCategory(int categoryId)
        {
            return _myPetsContext.Animals.Where(a => a.CategoryId.Equals(categoryId))
                                                       .Select(a => a).ToList();
        }

        public IEnumerable<Category> GetCategories() => _myPetsContext.Categories.Select(c => c).ToList();

        public Animal GetAnimalById(int id) => _myPetsContext.Animals.Where(a => a.Id.Equals(id)).SingleOrDefault();

        public IEnumerable<Comment> GetComments(int animalId) => _myPetsContext.Comments.Where(a => a.Animal.Id.Equals(animalId)).ToList();

        public void AddComment(int animalId, string commentText)
        {
            _myPetsContext.Comments.Add(new Comment { CommentText = commentText, AnimalId = animalId });
            _myPetsContext.SaveChanges();

            var comments = _myPetsContext.Comments.Select(c => c).ToList();
        }

        public AnimalDetail GetAnimalDetail(int animalId)
        {
            var animalQuery = _myPetsContext.Animals.Find(animalId);
            var commentQuery = _myPetsContext.Comments.Where(c => c.AnimalId.Equals(animalId))
                                                      .Select(c => c.CommentText).ToList();
            return new AnimalDetail()
            {
                AnimalId = animalQuery.Id,
                Name = animalQuery.Name,
                Age = animalQuery.Age,
                Description = animalQuery.Description,
                CategoryName = animalQuery.Category.Name,
                CommentsText = new List<string>(commentQuery)
            };






        }

        public void DeleteAnimalById(int animalId)
        {
            _myPetsContext.Animals.Remove(GetAnimalById(animalId));
            _myPetsContext.SaveChanges();
        }

        public void AddAnimal(string animalName, double animalAge, string animalDescription, int ChoosenCategoryId, string Url)
        {
            _myPetsContext.Animals.Add(new Animal
            {
                Name = animalName,
                Age = animalAge,
                CategoryId = ChoosenCategoryId,
                Description = animalDescription,
                PictureName = Url
            });
            _myPetsContext.SaveChanges();
        }

        public void UpdateAnimal(int animalId, string animalName, double animalAge, string animalDescription, int ChoosenCategoryId, string Url)
        {
            Animal animalToUpdate = GetAnimalById(animalId);

            if (animalToUpdate != null)
            {
                animalToUpdate.Name = animalName;
                animalToUpdate.Description = animalDescription;
                animalToUpdate.Age = animalAge;
                animalToUpdate.CategoryId = ChoosenCategoryId;
                animalToUpdate.PictureName = Url;

                _myPetsContext.SaveChanges();
            }
        }

        public string GetCategoryNameById(int CategoryId) => _myPetsContext.Categories.Where(a => a.Id.Equals(CategoryId))
                                                          .Take(1).Select(x => x.Name).FirstOrDefault();

       public int GetCategoryIdByAnimalId(int animalId) => _myPetsContext.Animals.Where(a => a.Id.Equals(animalId))
                                                                 .Select(x => x.CategoryId).FirstOrDefault();
        
           
        
    }
}
