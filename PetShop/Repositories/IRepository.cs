using PetShop.Models;
using PetShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<PresentHomeData>> GetTopCommentedAnimals(int amountOfAnimals);
        string GetCategoryNameById(int CategoryId);
        int GetCategoryIdByAnimalId(int animalId);
        Task <IEnumerable<Animal>> GetAnimalsByCategory(int categoryId);
        Animal GetAnimalById(int animalId);
        Task<IEnumerable<Category>> GetCategories();
        Task <IEnumerable<Comment>> GetComments(int animalId);
        AnimalDetail GetAnimalDetail(int animalId);
        void AddComment(int animalId, string commentText);
        void AddAnimal(string animalName, double animalAge, string animalDescription, int ChoosenCategoryId, string Url);
        void DeleteAnimalById(int animalId);
        void UpdateAnimal(int animalId, string animalName, double animalAge, string animalDescription, int ChoosenCategoryId, string Url);










    }
}
