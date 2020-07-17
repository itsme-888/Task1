namespace Task_1_with_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        buyer_Id = c.Int(),
                        phone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyer", t => t.buyer_Id)
                .ForeignKey("dbo.Phone", t => t.phone_Id)
                .Index(t => t.buyer_Id)
                .Index(t => t.phone_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "phone_Id", "dbo.Phone");
            DropForeignKey("dbo.Carts", "buyer_Id", "dbo.Buyer");
            DropIndex("dbo.Carts", new[] { "phone_Id" });
            DropIndex("dbo.Carts", new[] { "buyer_Id" });
            DropTable("dbo.Carts");
        }
    }
}
