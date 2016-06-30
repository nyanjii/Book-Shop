namespace BookShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyResolution : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Books", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "GenreId" });
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Books", "Genre_Id");
        }
    }
}
