namespace Task_1_with_Identity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Buyer")]
    public partial class Buyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Buyer()
        {
            Buy = new HashSet<Buy>();
            Carts = new HashSet<Cart>();
            Balance = 0;
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
        
        [StringLength(20)]
        public string Surname { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }


        public string Email { get; set; }

        public string Address { get; set; }

        
        [Column(TypeName = "money")]
        [DefaultValue(0)]
        
        public decimal? Balance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buy> Buy { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
