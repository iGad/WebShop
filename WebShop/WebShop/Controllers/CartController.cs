using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        
        IQueryable<VacuumCleaner> repository;
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public CartController(IQueryable<VacuumCleaner> repo)
        {            
            repository = repo;
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            VacuumCleaner product = repository
            .FirstOrDefault(p => p.id == productId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            VacuumCleaner product = repository
            .FirstOrDefault(p => p.id == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
    


    

