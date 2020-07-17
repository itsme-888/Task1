using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1_with_Identity.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual Buyer buyer { get; set; }
        public virtual Phone phone { get; set; }

        public int Count { get; set; }

    }
}