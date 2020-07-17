namespace Task_1_with_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer", "Email", c => c.String());
            AddColumn("dbo.Buyer", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer", "Address");
            DropColumn("dbo.Buyer", "Email");
        }
    }
}
