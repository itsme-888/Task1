namespace Task_1_with_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {

            DropTable("dbo.Messages");

        }
    }
}
