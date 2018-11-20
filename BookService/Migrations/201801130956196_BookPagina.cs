namespace BookService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookPagina : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Pagina", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Pagina");
        }
    }
}
