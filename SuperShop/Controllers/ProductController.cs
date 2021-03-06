﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.BLL;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;
using SuperShop.Models.EntityModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperShop.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: /<controller>/
        private readonly IProductManager _productManager;
        private readonly IProductCatagoryManager _productCatagoryManager;
        public ProductController(IProductManager productManager, IProductCatagoryManager productCatagoryManager)
        {
            _productManager = productManager;
            _productCatagoryManager = productCatagoryManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ProductCreateViewModel product = new ProductCreateViewModel();
            product.ProductCatagoryItem = _productCatagoryManager.GetAll()
                                                   .Select( c=> new SelectListItem() { 
                                                       Text=c.Name,
                                                       Value=c.Id.ToString()
                                                   }).ToList();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel entity, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                { 
                    Name = entity.Name,
                    Quantity=entity.Quantity,
                    Code=entity.Code,
                    Price=entity.Price,
                    CategoryId=entity.CategoryId
                };

                if (Image.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        product.Image = stream.ToArray();
                    }
                }

                bool isSave = _productManager.Add(product);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }

        public IActionResult List()
        {
            ICollection<Product> products = _productManager.GetAll();
            return View(products);
        }

        public IActionResult Edit(int? id)
        {
            if(id != null && id > 0)
            {
                Product product = _productManager.GetbById(id);
                if (id != null)
                {
                    return View(product);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            bool isSave = _productManager.Update(product);
            if (isSave)
            {
                return RedirectToAction("List");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                Product product = _productManager.GetbById(id);
                bool isSave = _productManager.Remove(product);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }           
    }
}
