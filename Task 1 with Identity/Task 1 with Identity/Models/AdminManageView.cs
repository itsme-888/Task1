using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Task_1_with_Identity.Models
{
    public class AdminManageView
    {
        public AdminManageView()
        {
            Model1 model1 = new Model1();
            Buyer = model1.Buyer.ToList<Buyer>();
        }

        public List<Buyer> Buyer { get;  }

    }
}