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
    public class EFNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EFNotificationDal(SignalRContext context) : base(context)
        {
        }

        public int AllNotificationCount()
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Count();
            return value;
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Where(x => x.Status == false).ToList();
            return value;
        }

        public void NotificationChangeToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationChangeToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Where(x => x.Status == false).Count();
            return value;
        }
    }
}
