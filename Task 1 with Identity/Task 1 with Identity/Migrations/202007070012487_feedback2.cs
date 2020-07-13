namespace Task_1_with_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "dateTime");
        }
    }
}
