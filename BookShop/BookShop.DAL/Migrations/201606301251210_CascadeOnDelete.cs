namespace BookShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeOnDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
