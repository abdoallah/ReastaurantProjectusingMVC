using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Core.Interfaces;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Project.web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //this method retun all Categories
        public List<Category> GetCategories()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            return categories;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult FoodList()
        {

            var list = _unitOfWork.FoodList.GetFood();
            //     var food1 = _unitOfWork.FoodList.GetById(f => f.Id == 2);

            return View(list);
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            ViewData["categories"] = GetCategories();
            Food food = new();
            return View(food);
        }
        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            _unitOfWork.FoodList.Add(food);
            _unitOfWork.Complete();
            return RedirectToAction("FoodList");
        }
        /////Edit Food
        [HttpGet]
        public IActionResult EditFood(int id)
        {
            ViewData["categories"] = GetCategories();
            Food food = _unitOfWork.FoodList.GetById(id);
            return View(food);
        }
        [HttpPost]

        public IActionResult EditFood(Food food)
        {
            _unitOfWork.FoodList.Update(food);
            _unitOfWork.Complete();
            return RedirectToAction("FoodList");
        }
        //...........................................................
        // Delete Food
        public IActionResult DeleteFood(int id)
        {
            Food food = _unitOfWork.FoodList.GetById(id);
            _unitOfWork.FoodList.Delete(food);
            _unitOfWork.Complete();
            return RedirectToAction("FoodList");
        }



    }


}
