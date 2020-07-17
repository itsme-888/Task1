namespace Task_1_with_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBalanceColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer", "Balance", c => c.Decimal(storeType: "money",defaultValue:0,nullable:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer", "Balance");
        }
    }
}
