using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            var values = context.Products.Count();
            return values;
        }

        public int ProductCountByCategorynameDrink()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID)).FirstOrDefault()).Count();
            return values;
        }

        public int ProductCountByCategorynameHamburger()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID)).FirstOrDefault()).Count();
            return values;
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return values;
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return values;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            var values = context.Products.Average(x => x.Price);
            return values;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
            return values;
        }

        public decimal ProductPriceBySteakBurger()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
            return values;
        }

        public decimal TotalPriceByDrink()
        {
            using var context = new SignalRContext();
            int id = context.Categories.Where(x => x.CategoryName == "İçecek").Select(y => y.CategoryID).FirstOrDefault();
            var values = context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
            return values;
        }

        public void changeProductStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Products.Find(id);
            value.ProductStatus = true;
            context.SaveChanges();
        }

        public void changeProductStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Products.Find(id);
            value.ProductStatus = false;
            context.SaveChanges();
        }

        public List<Product> GetProductWithStatusTrue()
        {
            using var context = new SignalRContext();
            var value = context.Products.Where(x => x.ProductStatus == true).ToList();
            return value;
        }
    }
}
