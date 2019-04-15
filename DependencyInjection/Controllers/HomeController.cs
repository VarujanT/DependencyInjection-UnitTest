using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyInjection.Models;
using Ninject;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        Book[] books =
        {
            new Book {Author = "Shakespiear", Title = "Hamlet", Category = BookCategory.Gexarvetakan, Price = 33.54m},
            new Book {Author = "Duma", Title = "Three Musk", Category = BookCategory.Gexarvetakan, Price = 13.54m},
            new Book {Author = "Sevak", Title = "Zangagatun", Category = BookCategory.Gexarvetakan, Price = 33.54m},
            new Book {Author = "Lipman", Title = "C++", Category = BookCategory.Programming, Price = 25.77m},
            new Book {Author = "Straustrup", Title = "OOP", Category = BookCategory.Programming, Price = 43.44m},

        };

        ITotalValueCalculator calc;
        public HomeController(ITotalValueCalculator clc)
        {
            calc = clc;
        }

        // GET: Home
        public ActionResult Index()
        {
            //IKernel kernel = new StandardKernel();

            //kernel.Bind<ITotalValueCalculator>().To<TotalValueCalculator>();

            //ITotalValueCalculator iCacl = kernel.Get<ITotalValueCalculator>();

            ////ITotalValueCalculator calc = new TotalValueCalculator();
            Library lib = new Library(calc) { Books = books };
            decimal totalPrice = lib.TotalPrice();
            return View(totalPrice);
        }
    }
}