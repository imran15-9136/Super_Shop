using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;
using SuperShop.Models.EntityModels;
using SuperShop.Models.ResponseModel;

namespace SuperShop.Controllers
{
    public class ProductCatagoryController : Controller
    {
        IProductCatagoryManager _catagoryManager;
        public ProductCatagoryController(IProductCatagoryManager productCatagoryManager)
        {
            _catagoryManager = productCatagoryManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCatagoryCreateViewModel productCatagory)
        {
            ProductCatagory catagory = new ProductCatagory() 
            { Id = productCatagory.Id,
              Name = productCatagory.Name };

            if (ModelState.IsValid)
            {
                bool isSave = _catagoryManager.Add(catagory);
                if (isSave)
                {
                    return RedirectToAction("List","ProductCatagory",null);
                }
            }
            return View();
        }

        public IActionResult List()
        {
            ICollection<ProductCatagory> catagory = _catagoryManager.GetAll();
            return View(catagory);
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                ProductCatagory catagory = _catagoryManager.GetById(id);
                return View(catagory);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ProductCatagory catagory)
        {
            bool isSave = _catagoryManager.Update(catagory);
            if (isSave)
            {
                return RedirectToAction("List");
            }
            return View(catagory);
        }

        public IActionResult Delete(int? id)
        {
            if(id!=null && id > 0)
            {
                ProductCatagory catagory = _catagoryManager.GetById(id);
                bool isSave = _catagoryManager.Remove(catagory);
                if (isSave)
                {
                    return RedirectToAction("List","ProductCatagory",null);
                }
            }
            return View("List");
        }
    }
}