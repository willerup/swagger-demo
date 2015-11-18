namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweaks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Gold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Joined", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropColumn("dbo.Customers", "Joined");
            DropColumn("dbo.Customers", "Gold");
        }
    }
}
