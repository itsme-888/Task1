namespace Task_1_with_Identity.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Buy> Buy { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Message> Messages { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Phone>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Phone>()
                .Property(e => e.Description)
                .IsFixedLength();
        }
    }
}
