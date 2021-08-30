using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _env;
        private IRepository _myRepository;

        public HomeController(IRepository myRepository, IWebHostEnvironment env)
        {
            _myRepository = myRepository;
            _env = env;
        }

        public async Task<IActionResult> IndexAsync()
        {
           
            return View(await _myRepository.GetTopCommentedAnimals(2));
        }

        public async Task<IActionResult> Catalog(int id)
        {
            ViewBag.ChoosenCategory = _myRepository.GetCategoryNameById(id);
            ViewBag.Categories = await _myRepository.GetCategories();
            return View( await _myRepository.GetAnimalsByCategory(id));
        }

        public IActionResult AnimalDetails(int id)
        {
            return View(_myRepository.GetAnimalDetail(id));
        }
        [HttpPost]
        public IActionResult AddComment(int id, string comment)
        {
            if(!string.IsNullOrEmpty(comment)) _myRepository.AddComment(id, comment);
            return RedirectToAction("AnimalDetails", new { id = id});
        }

        public async Task<IActionResult> Administrator(int id)
        {
            ViewBag.ChoosenCategory = _myRepository.GetCategoryNameById(id);
            ViewBag.Categories = await _myRepository.GetCategories();
            return View(await _myRepository.GetAnimalsByCategory(id));
        }

        [HttpGet]
        public async Task<IActionResult> AddAnimal()
        {
            ViewBag.Categories = await _myRepository.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(string animalName,double animalAge,string animalDescription,int ChoosenCategoryId,IFormFile file)
        {

            //validation form!!!!
            var dir1 = _env.WebRootPath;
            string[] permittedExtensions = { ".jpg", ".png", ".gif", ".jpeg" };
            
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext) || string.IsNullOrEmpty(animalName)  || animalAge <= 0  || ChoosenCategoryId < 1)
            {
                return RedirectToAction("Administrator", new { id = 1 });
            }

            using (var filestream = new FileStream(Path.Combine(dir1,"Images", $"{animalName}‪.JPG"),FileMode.Create,FileAccess.Write))
            {
                file.CopyTo(filestream);
            }
            _myRepository.AddAnimal(animalName, animalAge, animalDescription, ChoosenCategoryId, $"/Images/{animalName}‪.JPG");
            return RedirectToAction("Administrator", new { id = ChoosenCategoryId });
        }

        public IActionResult DeleteAnimal(int id)
        {
           int categoryId =  _myRepository.GetCategoryIdByAnimalId(id);
            _myRepository.DeleteAnimalById(id);
            return RedirectToAction("Administrator", new { id =categoryId  });
        }

        [HttpGet]
        public IActionResult UpdateAnimal(int id)
        {
            ViewBag.Categories = _myRepository.GetCategories();
            return View(_myRepository.GetAnimalById(id));
        }

        [HttpPost]
        public IActionResult UpdateAnimal(int id,string animalName, double animalAge, string animalDescription, int ChoosenCategoryId, IFormFile file)
        {

            //validation form!!!!
            var dir1 = _env.WebRootPath;
            string[] permittedExtensions = { ".jpg", ".png", ".gif", ".jpeg" };

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext) || string.IsNullOrEmpty(animalName) || animalAge <= 0 || ChoosenCategoryId < 1)
            {
                return RedirectToAction("Administrator", new { id = 1 });
            }

            using (var filestream = new FileStream(Path.Combine(dir1, "Images", $"{animalName}‪.JPG"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(filestream);
            }


            _myRepository.UpdateAnimal(id, animalName, animalAge, animalDescription, ChoosenCategoryId ,$"/Images/{animalName}‪.JPG");
            
            return RedirectToAction("Administrator", new { id = ChoosenCategoryId });
        }













    }
}
