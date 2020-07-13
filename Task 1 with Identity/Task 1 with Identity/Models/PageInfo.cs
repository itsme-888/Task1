using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1_with_Identity.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel_
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
