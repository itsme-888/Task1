namespace Task_1_with_Identity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Buy")]
    public partial class Buy
    {
        public int Id { get; set; }

        public int? BuyerId { get; set; }

        public int? PhoneId { get; set; }

        public DateTime? Date { get; set; }

        public int? Count { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Phone Phone { get; set; }
    }
}
