namespace BookShop.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        DateOfCreating = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropColumn("dbo.Books", "Genre_Id");
            DropTable("dbo.Genres");
        }
    }
}
