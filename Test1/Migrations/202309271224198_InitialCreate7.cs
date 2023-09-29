namespace Test1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "ProductName");
        }
    }
}
