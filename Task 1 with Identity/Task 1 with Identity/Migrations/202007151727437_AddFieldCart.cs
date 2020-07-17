namespace Task_1_with_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Count");
        }
    }
}
