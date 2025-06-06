﻿using SignalR.DataAccessLayer.Abstract;
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
    public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
        public EFContactDal(SignalRContext context) : base(context)
        {
        }

        public Contact GetFirstContact()
        {
            using var context = new SignalRContext();
            var value = context.Contacts.FirstOrDefault();
            return value;
        }
    }
}
