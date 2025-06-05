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
    public class EFOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EFOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            var values = context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
            return values;
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            var values = context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
            return values;
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            var values = context.Orders.Where(x => x.Date == DateTime.Today).Sum(y => y.TotalPrice);
            return values;
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            var values = context.Orders.Count();
            return values;
        }
    }
}
