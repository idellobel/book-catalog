namespace BookService.Migrations
{
    using BookService.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookService.Models.BookServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookService.Models.BookServiceContext context)
        {
            context.Authors.AddOrUpdate(x => x.Id,
        new Author() { Id = 1, Name = "Jane Austen" },
        new Author() { Id = 2, Name = "Charles Dickens" },
        new Author() { Id = 3, Name = "Miguel de Cervantes" }
        );

            context.Books.AddOrUpdate(x => x.Id,
                new Book()
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Year = 1813,
                    AuthorId = 1,
                    Price = 9.99M,
                    Pagina = 150,
                    Genre = "Comedy of manners"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Northanger Abbey",
                    Year = 1817,
                    AuthorId = 1,
                    Price = 12.95M,
                    Pagina = 210,
                    Genre = "Gothic parody"
                },
                new Book()
                {
                    Id = 3,
                    Title = "David Copperfield",
                    Year = 1850,
                    AuthorId = 2,
                    Price = 15,
                    Pagina = 189,
                    Genre = "Bildungsroman"
                },
                new Book()
                {
                    Id = 4,
                    Title = "Don Quixote",
                    Year = 1617,
                    AuthorId = 3,
                    Price = 8.95M,
                    Pagina = 175,
                    Genre = "Picaresque"
                }
                );

        }
    }
}
