namespace BookShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "LastUpdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "DateOfCreating");
            DropColumn("dbo.Genres", "DateOfCreating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "DateOfCreating", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "DateOfCreating", c => c.DateTime(nullable: false));
            DropColumn("dbo.Genres", "LastUpdate");
            DropColumn("dbo.Books", "LastUpdate");
        }
    }
}
